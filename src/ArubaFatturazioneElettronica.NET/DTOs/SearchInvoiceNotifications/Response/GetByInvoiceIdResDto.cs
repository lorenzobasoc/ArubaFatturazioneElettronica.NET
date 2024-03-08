namespace ArubaFatturazioneElettronica.NET.DTOs.SearchInvoiceNotifications.Response;

public class GetByInvoiceIdNotifyResDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public double Count { get; set; }
    public Notification[] Notifications { get; set; }
}
