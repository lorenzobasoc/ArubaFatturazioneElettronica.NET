namespace ArubaFatturazioneElettronica.NET.DTOs.FinancialComunications.Response;

public class GetTransmissionInfoResDto
{
    public string Result { get; set; }
    public string NotifyResult { get; set; }
    public string ElaboratedResult { get; set; }
    public string ReceiptTimestamp { get; set; }
    public string FileID { get; set; }
    public string FileName { get; set; }
    public bool PddAvailable { get; set; }
    public string Error { get; set; }
}
