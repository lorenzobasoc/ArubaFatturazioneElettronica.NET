namespace ArubaFatturazioneElettronica.NET.Constants;

public class Regexes
{
    public const string VAT_NUMBER_PATTERN = @"(IT)?[0-9]{11}";
    public const string FISCAL_CODE_PATTERN = "^[A-Z]{6}[0-9]{2}[ABCDEHLMPRST]{1}[0-9]{2}([A-Z]{1}[0-9]{3})[A-Z]{1}$";
}
