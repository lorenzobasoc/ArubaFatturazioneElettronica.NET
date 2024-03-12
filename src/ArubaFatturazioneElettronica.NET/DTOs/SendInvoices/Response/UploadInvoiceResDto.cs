namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Response;

public class UploadInvoiceResponseDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public string UploadFileName { get; set; }
}
