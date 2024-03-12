namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;

public class DettaglioLinee
{
    public int NumeroLinea { get; set; }
    public string Descrizione { get; set; }
    public decimal Quantita { get; set; }
    public string UnitaMisura { get; set; }
    public decimal PrezzoUnitario { get; set; }
    public decimal PrezzoTotale { get; set; }
    public decimal AliquotaIVA { get; set; }
    public string Natura { get; set; }
}
