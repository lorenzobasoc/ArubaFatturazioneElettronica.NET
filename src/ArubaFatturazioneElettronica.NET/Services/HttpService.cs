using System.Net;
using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos;
using ArubaFatturazioneElettronica.NET.Dtos.Auth.Response;
using ArubaFatturazioneElettronica.NET.Utilities;
using static ArubaFatturazioneElettronica.NET.Constants.HttpConstants;

namespace ArubaFatturazioneElettronica.NET.Services;

public class HttpService
{
    private readonly string _username;
    private readonly string _password;
    private readonly HttpHandler _requester;

    public HttpService(string username, string password, HttpHandler requester) {
        _username = username;
        _password = password;
        _requester = requester;
    }

    public async Task<T> SendGetRequest<T>(string url, List<string> parameters) {
        var tokenDto = await SignIn();
        var request = _requester.PrepareGetRequest(url, parameters, tokenDto.Access_token);
        var responseDto = await GetResponseDto<T>(request);
        return responseDto;
    }

    public async Task<T> SendPostRequest<T>(string url, Dictionary<string, string> data, bool isUrlEncodedBody = false) {
        var tokenDto = await SignIn();
        var request = _requester.PreparePostRequest(url, data, tokenDto.Access_token, isUrlEncodedBody);
        var responseDto = await GetResponseDto<T>(request);
        return responseDto;
    }

    public async Task<StreamResultDto> SendStreamGetRequest(string url, List<string> parameters) {
        var tokenDto = await SignIn();
        var request = _requester.PrepareGetRequest(url, parameters, tokenDto.Access_token);
        var result = await GetStreamResponse(request);
        return result;
    }

    public async Task<StreamResultDto> SendStreamPostRequest(string url, Dictionary<string, string> data) {
        var tokenDto = await SignIn();
        var request = _requester.PreparePostRequest(url, data, tokenDto.Access_token);
        var stream = await GetStreamResponse(request);
        return stream;
    }

    private async Task<StreamResultDto> GetStreamResponse(HttpRequestMessage request) {
        var response = await _requester.Send(request);
        var stream = await response.Content.ReadAsStreamAsync();
        var result = new StreamResultDto {
            Result = stream,
            StatusCode = (int)response.StatusCode,
            Message = response.ReasonPhrase,
        };
        return result;
    }

    private async Task<T> GetResponseDto<T>(HttpRequestMessage request) {
        var response = await _requester.Send(request);
        var content = await response.Content.ReadAsStringAsync();
        var responseDto = JsonUtils.Deserialize<T>(content);
        return responseDto;
    }

    private async Task<AccessTokenDto> SignIn() {
        var data = new Dictionary<string, string> {
            { BodyContent.GRANT_TYPE, BodyContent.PASSWORD },
            { BodyContent.USERNAME, _username },
            { BodyContent.PASSWORD, _password },
        };
        var request = _requester.PreparePostRequest(Urls.Auth.SingIn, data, null, true);
        var responseDto = await GetResponseDto<AccessTokenDto>(request);
        return responseDto;
    }
}
