namespace ArubaFatturazioneElettronica.NET.DTOs.SearchInvoices.Response;

public class GetInvoiceWithUnsignedFileResDto : GetByResDto
{
    public string UnsignedFile { get; set; }
    public bool Signed { get; set; }
}
