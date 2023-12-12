namespace ArubaFatturazioneElettronica.NET.DTOs.Auth.Response;

public class UserInfoDto
{
    public string Username { get; set; }
    public string Pec { get; set; }
    public string UserDescription { get; set; }
    public string CountryCode { get; set; }
    public string VatCode { get; set; }
    public string FiscalCode { get; set; }
    public AccountStatusDto AccountStatus { get; set; }
    public UsageStatusDto UsageStatus { get; set; }
}
