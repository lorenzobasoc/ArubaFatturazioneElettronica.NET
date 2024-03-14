namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class InoviceDataDto
{
    public CustomerDataDto CustomerData { get; set; }
    public TransmissionDataDto TransmissionData { get; set; }
    public SupplierDataDto SupplierData { get; set; }
    public GeneralDataDto GeneralData { get; set; }
    public PaymentDataDto PaymentData { get; set; }
    public List<ItemDto> Items { get; set; }
    public decimal TransportCost { get; set; }
    public bool IsPaInvoice { get; set; }
}
