namespace ArubaFatturazioneElettronica.NET.Constants;

public class InvoiceConstants
{
    public const string XML_ROOT_NAMESPACE = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2";
    public const string XML_INVOICE_HEADER = "FatturaElettronicaHeader";
    public const string XML_INVOICE_BODY = "FatturaElettronicaBody";
    public const string XML_ATTRIBUTE_VERSION = "versione";
    public const string XML_PREFIX = "q1";
    public const string ESC_DESCRIPTION = "Non soggette - altri casi";
    public const string EX_ART_15_DESCRIPTION = "Operazioni escluse ai sensi dell ex art 15 DPR 633/1972";
    public const string VERSIONE_PR = "FPR12";
    public const string VERSIONE_PA = "FPA12";
    public const string NATURA_ESC = "N2.2";
    public const string NATURA_EX_ART_15 = "N1";
    public const decimal STARNDAR_VAT = 1.22M;
    public const decimal STARNDAR_VAT_PERC = 22.00M;

}
