using ArubaFatturazioneElettronica.NET.Enumerations;

namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class ItemDto
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string MeasureUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public VatTypes Vat { get; set; }
}
