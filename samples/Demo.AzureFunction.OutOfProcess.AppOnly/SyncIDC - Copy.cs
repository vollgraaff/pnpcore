using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using PnP.Core;
using PnP.Core.Model.SharePoint;
using PnP.Core.QueryModel;
using PnP.Core.Services;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MIOnline
{
    public class SyncIDC
    {
        const string path = ".\\DailyDownload";

        private readonly ILogger logger;
        private readonly IPnPContextFactory contextFactory;
        private readonly AzureFunctionSettings azureFunctionSettings;

        public SyncIDC(IPnPContextFactory pnpContextFactory, ILoggerFactory loggerFactory, AzureFunctionSettings settings)
        {
            logger = loggerFactory.CreateLogger<SyncIDC>();
            contextFactory = pnpContextFactory;
            azureFunctionSettings = settings;
        }


        /// <summary>
        /// Dsdfassets and creates a page with an image web part
        /// GET/POST url: http://localhost:7071/api/SyncIDC
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Function("SyncIDC")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            logger.LogInformation("SyncIDC function starting...");

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");

            try
            {
                // Connect to sftp
                var connectionInfo = new ConnectionInfo(
                       azureFunctionSettings.IDCConnect.serverUrl,
                       azureFunctionSettings.IDCConnect.serverPort,
                       azureFunctionSettings.IDCConnect.usr,
                       new PasswordAuthenticationMethod(azureFunctionSettings.IDCConnect.usr, azureFunctionSettings.IDCConnect.pwd));

                using (var sftpClient = new SftpClient(connectionInfo))
                {
                    response.Body.Write(Encoding.UTF8.GetBytes("\rConnecting to SFTP"));
                    sftpClient.Connect();
                    response.Body.Write(Encoding.UTF8.GetBytes("\rGet remote version"));
                    DateTime remote = sftpClient.GetAttributes("/day.zip").LastWriteTime;

                    //Check if daily zip is more recent than local storage folder
                    if (Directory.Exists(path))
                    {
                        if ((Directory.GetCreationTime(path) == remote))
                        {
                            response.Body.Write(Encoding.UTF8.GetBytes("\rIDC synchronization is up to date"));
                            return response;
                        }
                        else
                        {
                            Directory.Delete(path, true);
                        }
                    }

                    response.Body.Write(Encoding.UTF8.GetBytes("\rInitialize local storage"));

                    Directory.CreateDirectory(path);
                    // Get SP context in order to save file to sharepoint IDC library
                    using (var context = await contextFactory.CreateAsync("MIOnline"))
                    {
                        string spPath = "Documents/IDC";
                        string localPath = Path.Combine(path, "temp.tmp");

                        // Load the default documents folder of the site
                        IFolder documentsFolder = context.Web.GetFolderByServerRelativeUrlAsync(spPath).Result;
                        var documentsList = await context.Web.Lists.GetByTitleAsync("Documents", p => p.Fields);

                        #region Sharepoint list lookups
                        // Assume the fields where not yet loaded, so loading them with the list
                        //var myList = context.Web.Lists.GetByTitle("OmdiaRefData", p => p.Title,
                        //                                                     p => p.Fields.QueryProperties(p => p.InternalName,
                        //                                                                                   p => p.FieldTypeKind,
                        //                                                                                   p => p.TypeAsString,
                        //                                                                                   p => p.Title));
                        //string lookupValue = string.Empty;
                        //// Build a query that only returns the Title field for items where the Title field starts with "Item1"
                        //string viewXml = @$"<View>
                        //    <ViewFields>
                        //      <FieldRef Name='Title' />
                        //      <FieldRef Name='ID' />
                        //    </ViewFields>
                        //    <Query>
                        //      <Where>
                        //        <Equals>
                        //          <FieldRef Name='Title'/>
                        //          <Value Type='text'>{lookupValue}</Value>
                        //        </Equals>
                        //      </Where>
                        //    </Query>
                        //    <RowLimit>1</RowLimit>
                        //   </View>";

                        //// Execute the query
                        //await myList.LoadItemsByCamlQueryAsync(new CamlQueryOptions()
                        //{
                        //    ViewXml = viewXml,
                        //    DatesInUtc = true
                        //}, p => p.RoleAssignments.QueryProperties(p => p.PrincipalId, p => p.RoleDefinitions));

                        //int id = myList.Items.AsRequested().FirstOrDefault().Id;
                        //// Iterate over the retrieved list items
                        //foreach (var listItem in myList.Items.AsRequested())
                        //{
                        //    // Do something with the list item and the per 
                        //    // item loaded RoleAssignments and RoleDefinitions
                        //}
                        #endregion

                        response.Body.Write(Encoding.UTF8.GetBytes("\rProcessing daily updates"));
                        // Process day.zip xml files
                        using (Stream stream = sftpClient.OpenRead("/day.zip"))
                        using (var fixedStream = new FixStream(stream))
                        using (var archive = new ZipArchive(fixedStream, ZipArchiveMode.Read))
                        {
                            foreach (var entry in archive.Entries.Where(w => w.FullName.Contains(".xml")).ToList())
                            {
                                // Open xml file stream to text model: get all documents referenced
                                response.Body.Write(Encoding.UTF8.GetBytes($"\rProcessing {entry.FullName}: ..."));
                                idccontainer xml = (idccontainer)new XmlSerializer(typeof(idccontainer)).Deserialize(entry.Open());
                                foreach (idccontainerContainerheaderContainerattachmentlink doc in xml.containerheader.idccontainerattachment)
                                {
                                    response.Body.Write(Encoding.UTF8.GetBytes($"\r\tSaving {doc.Value}.{doc.format} document to sp { doc.src}"));
                                    //Check if new version of file in archive
                                    ZipArchiveEntry file = archive.Entries.Where(w => w.Name == doc.src).First();
                                    IFile addedFile = documentsFolder.Files.Where(w => w.Name == doc.src).First();
                                    DateTime addedFileLastWriteTime = DateTime.MinValue;
                                    if (addedFile != null) addedFileLastWriteTime = await GetFileLastWriteTime(addedFile);

                                    if (addedFile == null || addedFileLastWriteTime != file.LastWriteTime.DateTime)
                                    {
                                        //Upload a file by adding it to the folder's files collection
                                        file.ExtractToFile(localPath, true);
                                        using (FileStream sFile = new FileStream(localPath, FileMode.Open))
                                            addedFile = await documentsFolder.Files.AddAsync(doc.src, sFile, true);

                                        try
                                        {
                                            /*
                                             * compile property list associated with document to be linked to reference data lookup values OmdiaRefData
                                             * Provide lookup list of category/title and either find in list or create & return list of ID lookup values
                                            */

                                            var refDataList = await context.Web.Lists.GetByTitleAsync("OmdiaRefData", p => p.Fields);

                                            Dictionary<string, object> refdata = new Dictionary<string, object>();
                                            foreach (var item in GetRefDataFromXML(xml))
                                            {
                                                var Key = item.Key.Split(":").First();
                                                refdata.Add(item.Key, await GetOmdiaRefLookupValue(Key, item.Value, refDataList));
                                            }

                                            await SetFileRecordProperties(addedFile, xml, doc.src, file.LastWriteTime.DateTime, refdata);

                                        }
                                        catch (SharePointRestServiceException ex)
                                        {
                                            var error = ex.Error as SharePointRestError;

                                            // Indicates the file did not exist
                                            if (error.HttpResponseCode == 404 && error.ServerErrorCode == -2130575338)
                                            {
                                                response = req.CreateResponse(HttpStatusCode.NotFound);
                                                response.Headers.Add("Content-Type", "application/json");
                                                await response.WriteStringAsync(JsonSerializer.Serialize(new { error = $"File does not exist. {ex.Message}" }));
                                            }
                                            else
                                            {
                                                throw;
                                            }
                                        }
                                        catch (ServiceException ex)
                                        {
                                            response = req.CreateResponse(HttpStatusCode.InternalServerError);
                                            response.Headers.Add("Content-Type", "application/json");
                                            if (ex is SharePointRestServiceException)
                                            {

                                                await response.WriteStringAsync(JsonSerializer.Serialize(new { error = $"SharePoint REST exception: {(ex.Error as SharePointRestError).ToString()}" }));
                                            }
                                            else
                                                await response.WriteStringAsync(JsonSerializer.Serialize(new { error = $"SharePoint REST exception: {ex.ToString()}\r\r{ex.Error.ToString()}" }));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    response.Body.Write(Encoding.UTF8.GetBytes("\rIDC Synchronization Complete."));
                    Directory.SetCreationTime(path, remote);
                }
            }
            catch (Exception ex)
            {
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Content-Type", "application/json");
                await response.WriteStringAsync(JsonSerializer.Serialize(new { error = ex.Message }));
            }

            return response;
        }

        private async Task<Microsoft.SharePoint.Client.FieldLookupValue> GetOmdiaRefLookupValue(string Category, string Title, IList refDataList)
        {
            string viewXml = @$"<View>
                            <ViewFields>
                              <FieldRef Name='ID' />
                              <FieldRef Name='Category' />
                              <FieldRef Name='Title' />
                            </ViewFields>
                            <Query>
                              <Where>
                                <And>
                                    <Eq>
                                      <FieldRef Name='Title'/>
                                      <Value Type='text'>{Title}</Value>
                                    </Eq>
                                    <Eq>
                                      <FieldRef Name='Category'/>
                                      <Value Type='text'>{Category}</Value>
                                    </Eq>
                                </And>
                              </Where>
                            </Query>
                            <RowLimit>1</RowLimit>
                        </View>";


            // Execute the query
            await refDataList.LoadItemsByCamlQueryAsync(new CamlQueryOptions()
            {
                ViewXml = viewXml,
                DatesInUtc = true
            }, p => p.RoleAssignments.QueryProperties(p => p.PrincipalId, p => p.RoleDefinitions));

            if (!refDataList.Items.AsRequested().Any())
            {
                Dictionary<string, object> item = new Dictionary<string, object>()
                {
                    { "Category", Category },
                    { "Title", Title },
                };
                // Persist the item
                IListItem listItem = await refDataList.Items.AddAsync(item);
                return new Microsoft.SharePoint.Client.FieldLookupValue() { LookupId = listItem.Id };
            }
            else
            {
                return new Microsoft.SharePoint.Client.FieldLookupValue() { LookupId = refDataList.Items.AsRequested().First().Id };
            }
        }



        private Dictionary<string, string> GetRefDataFromXML(idccontainer xml)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("content_type:", xml.containertype.ToString()));
            result.Add(new KeyValuePair<string, string>("content_subtype:", xml.containerheader.documentsubtype.ToString()));
            result.Add(new KeyValuePair<string, string>("geography:", xml.containerheader.regionofpublication.ToString()));
            result.Add(new KeyValuePair<string, string>("product:", xml.containergroup.ToString()));
            result.AddRange(xml.containerheader.authors.Select(s => new KeyValuePair<string, string>($"author:{s.authorname.ToString()}", s.authorname.ToString())).ToList());
            result.AddRange(xml.containerheader.services.Select(s => new KeyValuePair<string, string>($"service_area:{s.ToString()}", s.ToString())).ToList());

            return result.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private async Task SetFileRecordProperties(IFile spFile, idccontainer IDC_XML, string Title, DateTime LastWriteTime, Dictionary<string, object> refdata)
        {
            try
            {
                // Load the file metadata again to get the ListItemFields populated
                await spFile.LoadAsync(p => p.ListItemAllFields);

                // Update addedFile properties
                spFile.ListItemAllFields["ArticleId"] = IDC_XML.containerid;
                spFile.ListItemAllFields["ArticleTitle"] = IDC_XML.containerheader.documenttitle;
                spFile.ListItemAllFields["Synopsis"] = IDC_XML.containerheader.abstract1;
                spFile.ListItemAllFields["Title"] = Title;
                spFile.ListItemAllFields["PublicationDate"] = IDC_XML.containerheader.publicationdate;
                spFile.ListItemAllFields["Created"] = LastWriteTime;
                spFile.ListItemAllFields["Modified"] = LastWriteTime;

                // Iterate over the retrieved list items
                foreach (KeyValuePair<string, object> lookupValue in refdata)
                {
                    switch (lookupValue.Key.Split(":").First())
                    {
                        case "content_type":
                            spFile.ListItemAllFields["ContentTypesId"] = lookupValue.Value;
                            break;
                        case "content_subtype":
                            spFile.ListItemAllFields["ContentSubTypesId"] = lookupValue.Value;
                            break;
                        case "geography":
                            spFile.ListItemAllFields["GeographiesId"] = lookupValue.Value;
                            break;
                        case "product":
                            spFile.ListItemAllFields["ProductsId"] = lookupValue.Value;
                            break;
                        case "author":
                            spFile.ListItemAllFields["AuthorsId"] = lookupValue.Value;
                            break;
                        case "service_area":
                            spFile.ListItemAllFields["ServiceAreasId"] = lookupValue.Value;
                            break;
                        default:
                            break;
                    }
                }

                // Persist the updated properties
                await spFile.ListItemAllFields.UpdateOverwriteVersionAsync();
            }
            catch (Exception ex)
            {
                //throw;
            }
            finally { 
            }
        }

        private async Task<DateTime> GetFileLastWriteTime(IFile spFile)
        {
            try
            {
                // Load the file metadata again to get the ListItemFields populated
                await spFile.LoadAsync(p => p.ListItemAllFields);
                DateTime result = ((DateTime)spFile.ListItemAllFields["Created"]);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task<List<SftpFile>> GetFiles(SftpClient sftpClient, string directory, List<SftpFile> files)
        {
            foreach (SftpFile sftpFile in sftpClient.ListDirectory(directory))
            {
                if (sftpFile.Name.StartsWith('.')) { continue; }

                if (sftpFile.IsDirectory)
                {
                    await GetFiles(sftpClient, sftpFile.FullName, files);
                }
                else
                {
                    files.Add(sftpFile);
                }
            }
            return files;
        }



        /// <summary>
        /// Unfortunately, there's a bug in the library. https://stackoverflow.com/q/54145842/850848
        /// </summary>
        private class FixStream : Stream
        {
            public override long Seek(long offset, SeekOrigin origin)
            {
                long result;
                // workaround for SSH.NET bug in implementation of SeekOrigin.End
                if (origin == SeekOrigin.End)
                {
                    result = _stream.Seek(Length + offset, SeekOrigin.Begin);
                }
                else
                {
                    result = _stream.Seek(offset, origin);
                }
                return result;
            }

            // passthrough implementation of the rest of Stream interface

            public override bool CanRead => _stream.CanRead;

            public override bool CanSeek => _stream.CanSeek;

            public override bool CanWrite => _stream.CanWrite;

            public override long Length => _stream.Length;

            public override long Position
            {
                get => _stream.Position; set => _stream.Position = value;
            }

            public FixStream(Stream stream)
            {
                _stream = stream;
            }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                _stream.Write(buffer, offset, count);
            }

            private Stream _stream;
        }
    }
}