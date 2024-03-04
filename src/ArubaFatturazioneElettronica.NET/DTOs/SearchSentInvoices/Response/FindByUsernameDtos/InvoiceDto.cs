namespace ArubaFatturazioneElettronica.NET.DTOs.SearchSentInvoices.Response;

public class InvoiceDto
{
    public string InvoiceDate { get; set; }
    public string Number { get; set; }
    public string Status { get; set; }
    public string StatusDescription { get; set; }
}
