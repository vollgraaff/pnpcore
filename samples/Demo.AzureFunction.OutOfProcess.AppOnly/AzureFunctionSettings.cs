using System.Security.Cryptography.X509Certificates;

namespace MIOnline
{
    public class AzureFunctionSettings
    {
        public string SiteUrl { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public StoreName CertificateStoreName { get; set; }
        public StoreLocation CertificateStoreLocation { get; set; }
        public string CertificateThumbprint { get; set; }

        public connection IDCConnect { get { return new connection("intranet.idc.com", "ftp060", "knXP4JJW4KBp", 9922); } }
        public connection FrostConnect { get { return new connection("ftp://ftp.frost.com/", "TelkomSA", "20@N@v2017"); } }
        public connection MasonConnect { get { return new connection("ftp://ftp.analysysmason.com", "ftpTSA", "wil)Copper15"); } }
    }

    public class connection
    {
        public string serverUrl;
        public int serverPort;
        public string usr;
        public string pwd;

        public connection(string serverUrl, string usr, string? pwd, int? serverPort = 0)
        {
            if (string.IsNullOrEmpty(serverUrl)) throw new System.ArgumentException($"'{nameof(serverUrl)}' cannot be null or empty.", nameof(serverUrl));
            if (string.IsNullOrEmpty(usr)) throw new System.ArgumentException($"'{nameof(usr)}' cannot be null or empty.", nameof(usr));

            this.serverUrl = serverUrl;
            this.usr = usr;
            this.pwd = pwd;
            this.serverPort = serverPort ?? throw new System.ArgumentNullException(nameof(serverPort));
        }
    }
}
