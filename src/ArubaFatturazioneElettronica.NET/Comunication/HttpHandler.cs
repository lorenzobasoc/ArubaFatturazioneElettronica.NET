using System.Net.Http.Headers;

using static ArubaFatturazioneElettronica.NET.Constants.HttpConstants.Auth;

namespace ArubaFatturazioneElettronica.NET.Comunication;

public class HttpHandler
{
    private readonly HttpClient _client;

    public HttpHandler() {
        _client = new HttpClient();
    }

    protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) {
        var response = await _client.SendAsync(request);
        if (!response.IsSuccessStatusCode) {
            HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
        }
        return response;
    }

    public static HttpRequestMessage PrepareGetRequest(string baseUrl, string relativeUrl, List<string> queryParameters, string accessToken) {
        var url = queryParameters == null ?
            $"https://{baseUrl}{relativeUrl}" :
            $"https://{baseUrl}{relativeUrl}?{BuildArgumentsString(queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue(AUTH_BEARER, accessToken);
        return request;
    }

    public static HttpRequestMessage PreparePostRequest(string baseUrl, string relativeUrl, Dictionary<string, string> data, string accessToken = null) {
        var url = $"https://{baseUrl}{relativeUrl}";
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
