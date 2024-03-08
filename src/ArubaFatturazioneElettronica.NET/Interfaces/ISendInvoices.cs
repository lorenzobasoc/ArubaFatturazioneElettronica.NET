using ArubaFatturazioneElettronica.NET.DTOs.SendInvoices.Request;
using ArubaFatturazioneElettronica.NET.DTOs.SendInvoices.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISendInvoices
{
    Task<UploadInvoiceResponseDto> UploadInvoice(UploadInvoiceReqDto dto);
    Task<UploadInvoiceSignedResDto> UploadInvoiceSigned(UploadInvoiceSignedReqDto dto);
}
