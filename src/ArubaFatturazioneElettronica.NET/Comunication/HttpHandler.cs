using System.Net.Http.Headers;
using ArubaFatturazioneElettronica.NET.Utilities;
using static ArubaFatturazioneElettronica.NET.Constants.HttpConstants.Auth;

namespace ArubaFatturazioneElettronica.NET.Comunication;

public class HttpHandler
{
    private readonly HttpClient _client;

    public HttpHandler() {
        _client = new HttpClient();
    }

    public async Task<T> SendGetRequest<T>(string url, List<string> parameters, string accessToken) {
        var request = PrepareGetRequest(url, parameters, accessToken);
        var response = await Send(request);
        var content = await response.Content.ReadAsStringAsync();
        var responseDto = JsonUtils.Deserialize<T>(content);
        return responseDto;
    }


    public async Task<HttpResponseMessage> Send(HttpRequestMessage request) {
        var response = await _client.SendAsync(request);
        if (!response.IsSuccessStatusCode) {
            // HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
        }
        return response;
    }

    public HttpRequestMessage PrepareGetRequest(string url, List<string> queryParameters, string accessToken) {
        var fullPath = queryParameters == null ? url : $"{url}?{BuildArgumentsString(queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Get, fullPath);
        request.Headers.Authorization = new AuthenticationHeaderValue(AUTH_BEARER, accessToken);
        return request;
    }

    public HttpRequestMessage PreparePostRequest(string url, Dictionary<string, string> data, string accessToken) {
        var request = new HttpRequestMessage(HttpMethod.Post, url) {
            Content = new FormUrlEncodedContent(data)
        };
        if (accessToken != null) {
            request.Headers.Authorization = new AuthenticationHeaderValue(AUTH_BEARER, accessToken);
        }
        return request;
    }

    private static string BuildArgumentsString(List<string> arguments) {
        return arguments
            .Where(arg => !string.IsNullOrWhiteSpace(arg))
            .Aggregate(string.Empty, (current, arg) => current + "&" + arg);
    }

    private void HandleRequestFailure(HttpResponseMessage response) {
        throw new NotImplementedException();
    }
}
