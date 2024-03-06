using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.DTOs.Auth.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class Auth : IAuth
{
    private readonly HttpService _httpService;

    public Auth(HttpService httpService) {
        _httpService = httpService;
    }

    // public async Task<AccessTokenDto> SignIn() {
    //     var dto = await _httpService.SignIn();
    //     return dto;
    // }

    // public async Task RefreshToken() {

    // }

    public async Task<UserInfoDto> GetUserInfo() {
        var responseDto = await _httpService.SendGetRequest<UserInfoDto>(Urls.Auth.UserInfo, null);
        return responseDto;
    }

    public async Task<MulticedentiDto> GetMulticedenti() {
        var responseDto = await _httpService.SendGetRequest<MulticedentiDto>(Urls.Auth.Multicedenti, null);
        return responseDto;
    }

    public async Task<MulticedenteDto> GetMulticedenteById(string id) {
        var responseDto = await _httpService.SendGetRequest<MulticedenteDto>(Urls.Auth.Multicedenti + $"/{id}", null);
        return responseDto;
    }
}
