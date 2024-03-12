namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Header;

public class DatiAnagrafici
{
    public IdFiscale IdFiscaleIVA { get; set; }
    public string CodiceFiscale { get; set; }
    public Anagrafica Anagrafica { get; set; }
    public string RegimeFiscale { get; set; }
}
