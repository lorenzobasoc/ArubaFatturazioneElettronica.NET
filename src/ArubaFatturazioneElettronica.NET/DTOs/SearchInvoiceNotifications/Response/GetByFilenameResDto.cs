namespace ArubaFatturazioneElettronica.NET.DTOs.SearchInvoiceNotifications.Response;

public class GetByFilenameResDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public string Date { get; set; }
    public string DocType { get; set; }
    public string File { get; set; }
    public string Filename { get; set; }
    public string InvoiceId { get; set; }
    public string NotificationState { get; set; }
    public string Number { get; set; }
    public string Result { get; set; }
}
