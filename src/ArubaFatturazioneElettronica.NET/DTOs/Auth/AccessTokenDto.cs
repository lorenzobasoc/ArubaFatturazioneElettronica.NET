using System.Text.Json.Serialization;
using ArubaFatturazioneElettronica.NET.Constants;

namespace ArubaFatturazioneElettronica.NET.DTOs.Auth;

public class ArubaAccessTokenDto
{
    public string Access_token { get; set; }
    public string Token_type { get; set; }
    public int Expires_in { get; set; }
    public string Refresh_token { get; set; }
    public string UserName  { get; set; }
    [JsonPropertyName(DtosConstants.JSON_PROP_CLIENT_ID)]
    public string ClientRequestToken { get; set; }
    [JsonPropertyName(DtosConstants.JSON_PROP_ISSUED)]
    public string CreationDate { get; set; }
    [JsonPropertyName(DtosConstants.JSON_PROP_EXPIRES)]
    public string ExpirationDate { get; set; }
}
