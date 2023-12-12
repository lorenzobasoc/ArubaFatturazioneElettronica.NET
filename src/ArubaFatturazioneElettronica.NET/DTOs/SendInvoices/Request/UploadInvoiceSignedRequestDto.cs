namespace ArubaFatturazioneElettronica.NET.DTOs.SendInvoices.Request;

public class UploadInvoiceSignedRequestDto
{
    public string DataFile { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
