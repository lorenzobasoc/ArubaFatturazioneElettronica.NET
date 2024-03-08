namespace ArubaFatturazioneElettronica.NET.DTOs.SendInvoices.Request;

public class UploadInvoiceReqDto
{
    public string DataFile { get; set; }
    public string Credential { get; set; }
    public string Domain { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
