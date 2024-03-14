namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class UploadInvoiceReqDto
{
    public InoviceDataDto Data { get; set; }
    public string Credential { get; set; }
    public string Domain { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
