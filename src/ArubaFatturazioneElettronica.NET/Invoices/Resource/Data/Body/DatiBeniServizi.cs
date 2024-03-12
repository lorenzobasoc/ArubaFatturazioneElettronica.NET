using System.Xml.Serialization;

namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;

public class DatiBeniServizi
{
    [XmlElement]
    public DettaglioLinee[] DettaglioLinee { get; set; }
    [XmlElement]
    public DatiRiepilogo[] DatiRiepilogo { get; set; }
}
