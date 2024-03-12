using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Header;

namespace ArubaFatturazioneElettronica.NET.Invoices.Resource;

public class FatturaElettronicaHeader
{
    public DatiTrasmissione DatiTrasmissione { get; set; }
    public CedentePrestatore CedentePrestatore { get; set; }
    public DatiEconomici CessionarioCommittente { get; set; }
}
