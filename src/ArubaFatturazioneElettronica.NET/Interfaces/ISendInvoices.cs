using ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;
using ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISendInvoices
{
    Task<UploadInvoiceResponseDto> UploadInvoice(UploadInvoiceReqDto dto);
    Task<UploadInvoiceSignedResDto> UploadInvoiceSigned(UploadInvoiceSignedReqDto dto);
    Task<UploadInvoiceResponseDto> UploadInvoice(UploadInvoiceXmlReqDto dto);
    Task<UploadInvoiceSignedResDto> UploadInvoiceSigned(UploadInvoiceSignedXmlReqDto dto);
}
