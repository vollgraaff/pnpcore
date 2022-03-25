using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using PnP.Core.Model.SharePoint;
using PnP.Core.QueryModel;
using PnP.Core.Services;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace MIOnline
{
    public class CreateFile
    {
        private readonly ILogger logger;
        private readonly IPnPContextFactory contextFactory;
        private readonly AzureFunctionSettings azureFunctionSettings;

        public CreateFile(IPnPContextFactory pnpContextFactory, ILoggerFactory loggerFactory, AzureFunctionSettings settings)
        {
            logger = loggerFactory.CreateLogger<CreateFile>();
            contextFactory = pnpContextFactory;
            azureFunctionSettings = settings;
        }


        /// <summary>
        /// Demo function that creates a site collection, uploads an image to site assets and creates a page with an image web part
        /// GET/POST url: http://localhost:7071/api/CreateFile?sitename=mionlinefullPath='C:\Users\MartiensV\Desktop\tmp.txt'
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Function("CreateFile")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            logger.LogInformation("CreateFile function starting...");

            // Parse the url parameters
            NameValueCollection parameters = HttpUtility.ParseQueryString(req.Url.Query);
            var siteName = parameters["siteName"];
            var fullPath = parameters["fullPath"];

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");

            try
            {
                using (var context = await contextFactory.CreateAsync($"{siteName}"))
                {
                    var siteCollections = await context.GetSiteCollectionManager().GetSiteCollectionsAsync();
                    // Get a reference to a folder
                    IFolder idcFolder = await context.Web.Folders.Where(f => f.Name == "Documents/IDC").FirstOrDefaultAsync();
                    //Upload a file by adding it to the folder's files collection
                    IFile addedFile = await idcFolder.Files.AddAsync("test.png", File.OpenRead($"{fullPath}"));
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");
                await response.WriteStringAsync(JsonSerializer.Serialize(new { error = ex.Message }));
                return response;
            }
        }
    }
}
