using CsbEcommerce.Enumerations;

namespace ArubaFatturazioneElettronica.NET.Utilities;

public static class VatDictionary
{
    public const decimal VENTIDUE = 22.00M;  
    public const decimal DIECI = 10.00M;
    public const decimal CINQUE = 5.00M;
    public const decimal QUATTRO = 4.00M;
    public const decimal ZERO = 0.00M;

    public static IReadOnlyDictionary<VatTypes, decimal> VAT_VALUES = new Dictionary<VatTypes, decimal> {
        {VatTypes.VENTIDUE, VENTIDUE},
        {VatTypes.DIECI, DIECI},
        {VatTypes.CINQUE, CINQUE},
        {VatTypes.QUATTRO, QUATTRO},
        {VatTypes.ZERO, ZERO},
        {VatTypes.EX_ART_15, ZERO},
    };
}
