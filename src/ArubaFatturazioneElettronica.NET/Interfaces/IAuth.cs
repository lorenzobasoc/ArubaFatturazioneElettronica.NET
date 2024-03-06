using ArubaFatturazioneElettronica.NET.DTOs.Auth.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface IAuth
{
    Task<UserInfoDto> GetUserInfo();
    Task<MulticedentiDto> GetMulticedenti(string countryCode = null, string vatCode = null, string status = null, int size = 10, int page = 1);
    Task<MulticedenteDto> GetMulticedenteById(string id);
}
