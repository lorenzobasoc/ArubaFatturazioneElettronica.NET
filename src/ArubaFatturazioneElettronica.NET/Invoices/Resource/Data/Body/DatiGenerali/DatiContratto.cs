namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body.DatiGenerali;

public class DatiContratto
{
    public int RiferimentoNumeroLinea { get; set; }
    public string IdDocumento { get; set; }
    public DateOnly Data { get; set; }
    public int NumItem { get; set; }
    public string CodiceCUP { get; set; }
    public string CodiceCIG { get; set; }
}
