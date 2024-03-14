namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class PaymentDataDto
{
    public string PaymentConditions { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentDueDate { get; set; }
    public decimal Total { get; set; }
    public string Bank { get; set; }
    public string IBAN { get; set; }
    public string BIC { get; set; }
}
