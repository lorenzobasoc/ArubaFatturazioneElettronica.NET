namespace ArubaFatturazioneElettronica.NET.Utilities;

public class HttpUtils
{
    public static List<string> ComposeQueryString(Dictionary<string, string> keyValues) {
        return keyValues
            .Where(kv => kv.Value != null)
            .Select(kv => $"{kv.Key}={kv.Value}")
            .ToList();
    }

    public static Dictionary<string, string> ComposePostBody<T>(T dto) {
       var json = JsonUtils.Serialize(dto);
       var dictionary = JsonUtils.Deserialize<Dictionary<string, string>>(json);
       return dictionary;
    }

    public static string Convert(byte[] bytes) { 
        if (bytes == null || bytes.Length == 0) {
            return string.Empty;
        }
        return System.Convert.ToBase64String(bytes);
    }
}
