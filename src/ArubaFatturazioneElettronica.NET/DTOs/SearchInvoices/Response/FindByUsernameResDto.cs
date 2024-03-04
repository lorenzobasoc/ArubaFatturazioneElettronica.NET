namespace ArubaFatturazioneElettronica.NET.DTOs.SearchInvoices.Response;

public class FindByUsernameResDto
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public SearchInvoiceContentDto[] Content { get; set; }
    public bool Last { get; set; }
    public int TotalElements { get; set; }
    public int TotalPages { get; set; }
    public int Size { get; set; }
    public int Number { get; set; }
    public bool First { get; set; }
    public int NumberOfELements { get; set; }
}
