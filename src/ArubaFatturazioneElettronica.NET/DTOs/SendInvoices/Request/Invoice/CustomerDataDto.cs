namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class CustomerDataDto
{
    public string VatNumOrFiscalCode { get; set; }
    public string Country { get; set; }
    public string Denomination { get; set; }
    public string SiteStreet { get; set; }
    public string SiteCity { get; set; }
    public string SitePostalCode { get; set; }
    public string SiteProvince { get; set; }
    public string SiteCountry { get; set; }
}
