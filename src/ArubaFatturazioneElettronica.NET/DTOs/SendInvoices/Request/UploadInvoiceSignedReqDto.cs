namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class UploadInvoiceSignedReqDto
{
    public string DataFile { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
