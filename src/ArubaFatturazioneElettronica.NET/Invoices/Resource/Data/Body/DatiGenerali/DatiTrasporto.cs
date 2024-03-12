namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body.DatiGenerali;

public class DatiTrasporto
{
    public DatiAnagraficiVett DatiAnagraficiVettore { get; set; }
    public DateTime DataOraConsegna { get; set; }

    public class DatiAnagraficiVett
    {
        public IdFiscale IdFiscaleIVA { get; set; }
        public Anagrafica Anagrafica { get; set; }
    }
}
