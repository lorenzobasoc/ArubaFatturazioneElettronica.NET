using System.Net.Http.Headers;
using ArubaFatturazioneElettronica.NET.Exceptions;
using ArubaFatturazioneElettronica.NET.Utilities;

using static ArubaFatturazioneElettronica.NET.Constants.HttpConstants.Auth;

namespace ArubaFatturazioneElettronica.NET.Comunication;

public class HttpHandler
{
    private readonly HttpClient _client;

    public HttpHandler() {
        _client = new HttpClient();
    }

    public async Task<HttpResponseMessage> Send(HttpRequestMessage request) {
        var response = await _client.SendAsync(request);
        if (!response.IsSuccessStatusCode) {
            await HandleRequestFailure(response);
        }
        return response;
    }

    public static HttpRequestMessage PrepareGetRequest(string url, List<string> queryParameters, string accessToken) {
        var fullPath = queryParameters == null ? url : $"{url}?{BuildArgumentsString(queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Get, fullPath);
        request.Headers.Authorization = new AuthenticationHeaderValue(AUTH_BEARER, accessToken);
        return request;
    }

    public HttpRequestMessage PreparePostRequest(string url, Dictionary<string, string> data, string accessToken, bool isUrlEncodedBody = false) {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        if (isUrlEncodedBody) {
            request.Content = new FormUrlEncodedContent(data);
        } else {
            request.Content = HttpContentFactory.CreateAsJson(data);
        }
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

    private static async Task HandleRequestFailure(HttpResponseMessage response) {
        var content = await response.Content.ReadAsStringAsync();

        throw new ArubaFatturazioneElettronicaException(response.StatusCode.ToString(), content);
    }
}
