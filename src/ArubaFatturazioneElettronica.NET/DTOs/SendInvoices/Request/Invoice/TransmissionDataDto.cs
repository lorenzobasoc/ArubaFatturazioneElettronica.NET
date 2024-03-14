namespace ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;

public class TransmissionDataDto
{
    public string TransmitterCountry { get; set; }
    public string TransmitterVatCode { get; set; }
    public string ProgressiveCode { get; set; }
    public string TransmissionFormat { get; set; }
    public string RecipientCode { get; set; }
}
