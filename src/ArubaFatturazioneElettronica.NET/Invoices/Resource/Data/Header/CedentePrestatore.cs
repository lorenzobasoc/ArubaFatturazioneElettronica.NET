namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Header;

public class CedentePrestatore
{
    public DatiAnagrafici DatiAnagrafici { get; set; }
    public Sede Sede { get; set; }
    public IscrizioneREA IscrizioneREA { get; set; }
    public Contatti Contatti { get; set; }
}
