using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Invoices.Resource;
using System.Xml.Serialization;

namespace ArubaFatturazioneElettronica.NET.Invoices;

[XmlRoot(Namespace = InvoiceConstants.XML_ROOT_NAMESPACE)]
public class FatturaElettronica
{
    [XmlElement(ElementName = InvoiceConstants.XML_INVOICE_HEADER, Namespace = "")]
    public FatturaElettronicaHeader FatturaElettronicaHeader { get; set; }
    [XmlElement(ElementName = InvoiceConstants.XML_INVOICE_BODY, Namespace = "")]
    public FatturaElettronicaBody FatturaElettronicaBody { get; set; }
    
    [XmlAttribute(AttributeName = InvoiceConstants.XML_ATTRIBUTE_VERSION)]
    public string Versione = InvoiceConstants.VERSIONE_PR;

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces xmlns = new();
    public FatturaElettronica() {
        xmlns.Add(InvoiceConstants.XML_PREFIX, InvoiceConstants.XML_ROOT_NAMESPACE);
    }
}
    