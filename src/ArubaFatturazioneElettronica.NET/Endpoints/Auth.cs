using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos.Auth.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class Auth(HttpService httpService) : IAuth
{
    private readonly HttpService _httpService = httpService;

    public async Task<UserInfoDto> GetUserInfo() {
        var responseDto = await _httpService.SendGetRequest<UserInfoDto>(Urls.Auth.UserInfo, null);
        return responseDto;
    }

    public async Task<MulticedentiDto> GetMulticedenti(string countryCode = null, string vatCode = null, string status = null, int size = 10, int page = 1) {
        var queryParams = new Dictionary<string, string> {
            {nameof(countryCode), countryCode},
            {nameof(vatCode), vatCode},
            {nameof(status), status},
            {nameof(size), size.ToString()},
            {nameof(page), page.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<MulticedentiDto>(Urls.Auth.Multicedenti, queryString);
        return responseDto;
    }

    public async Task<MulticedenteDto> GetMulticedenteById(string id) {
        var responseDto = await _httpService.SendGetRequest<MulticedenteDto>(Urls.Auth.Multicedenti + $"/{id}", null);
        return responseDto;
    }
}
