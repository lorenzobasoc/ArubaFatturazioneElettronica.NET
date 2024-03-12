namespace ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;

public class DettaglioPagamento
{
    public string ModalitaPagamento { get; set; }
    public string DataScadenzaPagamento  { get; set; }
    public decimal ImportoPagamento { get; set; }
    public string IstitutoFinanziario { get; set; }
    public string IBAN { get; set; }
    public string BIC { get; set; }
}
