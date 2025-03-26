using ArubaFatturazioneElettronica.NET.Enumerations;

namespace ArubaFatturazioneElettronica.NET.Constants;

public static class Urls
{
    private static class BaseUrls
    {
        public const string AuthSandbox = "https://demoauth.fatturazioneelettronica.aruba.it";
        public const string AuthProduciton = "https://auth.fatturazioneelettronica.aruba.it";
        
        public const string OthersSandbox = "https://demows.fatturazioneelettronica.aruba.it";
        public const string OthersProduciton = "https://ws.fatturazioneelettronica.aruba.it";
    }

    public static class Auth 
    {
        public const string SingIn = "/auth/signin";
        public const string UserInfo = "/auth/userInfo";
        public const string Multicedenti = "/auth/multicedenti";
    }

    public static class FinancialCommunications
    {
        public const string CreateTransmissionReq = "/services/ClientRequest/CreateTransmissionRequest";
        public const string GetTransmissionInfoReq = "/services/ClientRequest/GetTransmissionInfoRequest";
        public const string Pdd = "/services/ClientRequest/pdd";
    }

    public static class SendInvoices
    {
        public const string Upload = "/services/invoice/upload";
        public const string UploadSigned = "/services/invoice/uploadSigned";
    }

    public static class SearchSentInvoices
    {
        public const string FindByUsername = "/services/invoice/out/findByUsername";
        public const string GetByFilename = "/services/invoice/out/getByFilename";
        public const string GetZipByFilename = "/services/invoice/out/getZipByFilename";
        public const string GetByInvoiceId = "/services/invoice/out";
        public const string GetByIdSdi = "/services/invoice/out/getByIdSdi";
        public const string Pdd = "/services/invoice/out/pdd";
    }

    public static class SearchReceivedInvoices
    {
        public const string FindByUsername = "/services/invoice/in/findByUsername";
        public const string GetByFilename = "/services/invoice/in/getByFilename";
        public const string GetZipByFilename = "/services/invoice/in/getZipByFilename";
        public const string GetByInvoiceId = "/services/invoice/in";
        public const string GetByIdSdi = "/services/invoice/in/getByIdSdi";
        public const string Pdd = "/services/invoice/in/pdd";
        public const string GetWithUnsignedFile = "/services/invoice/in/getInvoiceWithUnsignedFile";
    }

    public static class SendOutcomeClient
    {
        public const string Send = "/services/invoice/in/sendEsitoCommittente";
    }

    public static class SearchSentInvoiceNotification
    {
        public const string GetByFilename = "/services/notification/out/getByFilename";
        public const string GetByInvoiceFilename = "/services/notification/out/getByInvoiceFilename";
        public const string GetByInvoiceId = "/services/notification/out";
    }

    public static class SearchReceivedInvoiceNotification
    {
        public const string GetByFilename = "/services/notification/in/getByFilename";
        public const string GetByInvoiceFilename = "/services/notification/in/getByInvoiceFilename";
        public const string GetByInvoiceId = "/services/notification/in";
    }

    public static string GetBaseAuthUrl(string env) {
        return env switch
        {
            AppEnvironments.Sandbox => BaseUrls.AuthSandbox,
            AppEnvironments.Produciton => BaseUrls.AuthProduciton,
            _ => throw new ArgumentException("Invalid environment"),
        };
    }

    public static string GetBaseUrl(string env) {
        return env switch
        {
            AppEnvironments.Sandbox => BaseUrls.OthersSandbox,
            AppEnvironments.Produciton => BaseUrls.OthersProduciton,
            _ => throw new ArgumentException("Invalid environment"),
        };
    }
}
