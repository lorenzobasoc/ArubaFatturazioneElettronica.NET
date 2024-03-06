using System.Text;

namespace ArubaFatturazioneElettronica.NET.Utilities;

public static class HttpContentFactory
{
    public static StringContent CreateAsJson(object data) {
        var json = JsonUtils.Serialize(data);
        return CreateAsString(json);
    }

    public static FormUrlEncodedContent CreateAsForm(Dictionary<string, string> data) {
        return new FormUrlEncodedContent(data);
    }

    public static StringContent CreateAsString(string data) { 
        return new StringContent(data, Encoding.UTF8, "application/json");
    }
}
