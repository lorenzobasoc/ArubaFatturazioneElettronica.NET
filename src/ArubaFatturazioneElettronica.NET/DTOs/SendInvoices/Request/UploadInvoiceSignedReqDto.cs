namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class UploadInvoiceSignedReqDto
{
    public InoviceDataDto Data { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
