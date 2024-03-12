using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body.DatiGenerali;
using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;

namespace ArubaFatturazioneElettronica.NET.Invoices.Resource;

public class FatturaElettronicaBody
{
    public DatiGenerali DatiGenerali { get; set; }
    public DatiBeniServizi DatiBeniServizi { get; set; }
    public DatiPagamento DatiPagamento { get; set; }
}
