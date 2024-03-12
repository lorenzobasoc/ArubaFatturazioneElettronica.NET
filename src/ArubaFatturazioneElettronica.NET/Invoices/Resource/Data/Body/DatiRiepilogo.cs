using System.Xml.Serialization;

namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;

public class DatiRiepilogo
{
    public decimal AliquotaIVA { get; set; }
    [XmlElement(DataType = "string")]
    public string Natura { get; set; }
    public decimal ImponibileImporto { get; set; }
    public decimal Imposta { get; set; }
    public string EsigibilitaIVA { get; set; }
    public string RiferimentoNormativo { get; set; }
}
