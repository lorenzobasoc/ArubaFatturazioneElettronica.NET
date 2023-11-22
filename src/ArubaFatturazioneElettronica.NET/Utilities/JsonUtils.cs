using System.Text.Json;

namespace ArubaFatturazioneElettronica.NET.Utilities;

public static class JsonUtils
{
    private static readonly JsonSerializerOptions OPTIONS = new() {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public static T Deserialize<T>(string json) {
        return JsonSerializer.Deserialize<T>(json, OPTIONS);
    }

    public static string Serialize(object data) {
        return JsonSerializer.Serialize(data, OPTIONS);
    }
}
