namespace ArubaFatturazioneElettronica.NET.Utilities;

public class HttpUtils
{
    public static List<string> ComposeQueryString(Dictionary<string, string> keyValues) {
        return keyValues
            .Where(kv => kv.Value != null)
            .Select(kv => $"{kv.Key}={kv.Value}")
            .ToList();
    }
}
