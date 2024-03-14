namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class UploadInvoiceSignedXmlReqDto
{
    public string Xml { get; set; }
    public string SenderPIVA { get; set; }
    public bool SkipExtraSchema { get; set; }
}
