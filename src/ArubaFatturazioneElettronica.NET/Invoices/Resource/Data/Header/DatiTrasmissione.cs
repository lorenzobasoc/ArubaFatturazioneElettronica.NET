namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Header;

public class DatiTrasmissione
{
    public IdFiscale IdTrasmittente { get; set; }
    public string ProgressivoInvio { get; set; }
    public string FormatoTrasmissione { get; set; }
    public string CodiceDestinatario { get; set; }
}
