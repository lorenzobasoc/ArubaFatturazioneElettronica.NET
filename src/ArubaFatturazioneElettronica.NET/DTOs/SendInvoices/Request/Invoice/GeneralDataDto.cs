namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class GeneralDataDto
{
    public string DocumentType { get; set; }
    public string Currency { get; set; }
    public string Date { get; set; }
    public string InvoiceNumber { get; set; }
    public string Causal { get; set; }
    public string DocumentId { get; set; }
    public string CupCode { get; set; }
    public string CigCode { get; set; }
}
