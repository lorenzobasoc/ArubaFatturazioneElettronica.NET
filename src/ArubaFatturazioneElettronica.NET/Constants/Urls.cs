namespace ArubaFatturazioneElettronica.NET.Constants;

public static class Urls
{
    public const string Id = "/{id}";

    private static class BaseUrls
    {
        // Prod: https://auth.fatturazioneelettronica.aruba.it
        public const string Auth = "https://demoauth.fatturazioneelettronica.aruba.it";
        
        // Prod: https://ws.fatturazioneelettronica.aruba.it
        public const string Others = "https://demows.fatturazioneelettronica.aruba.it";
    }

    public static class Auth 
    {
        private const string _base = BaseUrls.Auth;

        public const string SingIn = _base + "/auth/signin";
        public const string UserInfo = _base + "/auth/userInfo";
        public const string Multicedenti = _base + "/auth/multicedenti";
    }

    public static class FinancialCommunications
    {
        private const string _base = BaseUrls.Others;

        public const string CreateTransmissionReq = _base + "/services/ClientRequest/CreateTransmissionRequest";
        public const string GetTransmissionInfoReq = _base + "/services/ClientRequest/GetTransmissionInfoRequest";
        public const string Pdd = _base + "/services/ClientRequest/pdd";
    }

    public static class SendInvoices
    {
        private const string _base = BaseUrls.Others;

        public const string Upload = _base + "services/invoice/upload";
        public const string UploadSigned = _base + "/services/invoice/uploadSigned";
    }

    public static class SearchSentInvoices
    {
        private const string _base = BaseUrls.Others;

        public const string FindByUsername = _base + "/services/invoice/out/findByUsername";
        public const string GetByFilename = _base + "/services/invoice/out/getByFilename";
        public const string GetZipByFilename = _base + "/services/invoice/out/getZipByFilename";
        public const string GetByInvoiceId = _base + "/services/invoice/out";
        public const string GetByIdSdi = _base + "/services/invoice/out/getByIdSdi";
        public const string GetByPdd = _base + "/services/invoice/out/pdd";
    }

    public static class SearchReceivedInvoices
    {
        private const string _base = BaseUrls.Others;

        public const string FindByUsername = _base + "/services/invoice/in/findByUsername";
        public const string GetByFilename = _base + "/services/invoice/in/getByFilename";
        public const string GetZipByFilename = _base + "/services/invoice/in/getZipByFilename";
        public const string GetByInvoiceId = _base + "/services/invoice/in";
        public const string GetByIdSdi = _base + "/services/invoice/in/getByIdSdi";
        public const string GetByPdd = _base + "/services/invoice/in/pdd";
        public const string GetWithUnsignedFile = _base + "/services/invoice/in/getInvoiceWithUnsignedFile";
    }

    public static class SendOutcomeClient
    {
        private const string _base = BaseUrls.Others;

        public const string Send = _base + "/services/invoice/in/sendEsitoCommittente";
    }

    public static class SearchSentInvoiceNotification
    {
        private const string _base = BaseUrls.Others;

        public const string GetByFilename = _base + "/services/notification/out/getByFilename";
        public const string GetByInvoiceFilename = _base + "/services/notification/out/getByInvoiceFilename";
        public const string GetByInvoiceId = _base + "/services/notification/out";
    }
}
