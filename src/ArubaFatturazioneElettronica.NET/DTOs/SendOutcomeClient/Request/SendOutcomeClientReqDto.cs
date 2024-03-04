namespace ArubaFatturazioneElettronica.NET.DTOs.SendOutcomeClient.Request;

public class SendOutcomeClientReqDto
{
    public string Filename { get; set; }
    public double SdiId { get; set; }
    public string Esito { get; set; }
    public string Numero { get; set; }
    public int Anno { get; set; }
    public double Posizione { get; set; }
    public string Descrizione { get; set; }
    public string MessageId { get; set; }
}
