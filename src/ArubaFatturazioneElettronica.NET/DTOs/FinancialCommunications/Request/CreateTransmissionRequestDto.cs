namespace ArubaFatturazioneElettronica.NET.DTOs.FinancialComunications.Request;

public class CreateTransmissionRequest
{
    public string UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ComunicationType { get; set; }
    public string DataFile { get; set; }
}
