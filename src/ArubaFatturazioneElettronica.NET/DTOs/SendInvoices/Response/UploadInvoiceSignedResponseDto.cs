namespace ArubaFatturazioneElettronica.NET.DTOs.SendInvoices.Response;

public class UploadInvoiceSignedResponseDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public string UploadFileName { get; set; }
}
