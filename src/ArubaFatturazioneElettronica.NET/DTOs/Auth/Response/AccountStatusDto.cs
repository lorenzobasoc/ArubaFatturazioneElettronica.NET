namespace ArubaFatturazioneElettronica.NET.Dtos.Auth.Response;

public class AccountStatusDto
{
    public bool Expired { get; set; }
    public string ExpirationDate { get; set; }
}
