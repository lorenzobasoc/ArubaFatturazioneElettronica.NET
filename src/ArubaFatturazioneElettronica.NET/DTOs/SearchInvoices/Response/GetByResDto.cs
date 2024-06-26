namespace ArubaFatturazioneElettronica.NET.Dtos.SearchInvoices.Response;

public class GetByResDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public string Id { get; set; }
    public CompanyDto Sender { get; set; }
    public CompanyDto Receiver { get; set; }
    public string InvoiceType { get; set; }
    public string DocType { get; set; }
    public string File { get; set; }
    public string Filename { get; set; }
    public InvoiceDto[] Invoices { get; set; }
    public string Username { get; set; }
    public string LastUpdate { get; set; }
    public string CreationDate { get; set; }
    public string IdSdi { get; set; }
    public bool PdfAvailable { get; set; }
    public string PdfFile { get; set; }
}
