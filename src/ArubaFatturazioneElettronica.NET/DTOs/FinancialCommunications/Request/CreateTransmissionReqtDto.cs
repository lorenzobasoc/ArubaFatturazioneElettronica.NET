namespace ArubaFatturazioneElettronica.NET.Dtos.FinancialComunications.Request;

public class CreateTransmissionReqtDto
{
    public string UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ComunicationType { get; set; }
    public string DataFile { get; set; }
}
