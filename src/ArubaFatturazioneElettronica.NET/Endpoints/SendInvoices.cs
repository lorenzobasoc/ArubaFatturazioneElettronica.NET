using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;
using ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendInvoices(HttpService httpService) : ISendInvoices
{
    private readonly HttpService _httpService = httpService;

    public async Task<UploadInvoiceResponseDto> UploadInvoice(UploadInvoiceReqDto dto) {
        var fatturaElettronica = InvoiceUtilities.CreateFatturaElettronica(dto.Data);
        var xml = await InvoiceUtilities.CreateXml(fatturaElettronica);
        var data = HttpUtils.ComposePostBody(new { xml, dto.SenderPIVA, dto.SkipExtraSchema, dto.Credential, dto.Domain });
        var responseDto = await _httpService.SendPostRequest<UploadInvoiceResponseDto>(Urls.SendInvoices.Upload, data);
        return responseDto;
    }

    public async Task<UploadInvoiceSignedResDto> UploadInvoiceSigned(UploadInvoiceSignedReqDto dto) {
        var fatturaElettronica = InvoiceUtilities.CreateFatturaElettronica(dto.Data);
        var xml = await InvoiceUtilities.CreateXml(fatturaElettronica);
        var data = HttpUtils.ComposePostBody(new { xml, dto.SenderPIVA, dto.SkipExtraSchema });
        var responseDto = await _httpService.SendPostRequest<UploadInvoiceSignedResDto>(Urls.SendInvoices.UploadSigned, data);
        return responseDto;
    }

    public async Task<UploadInvoiceResponseDto> UploadInvoice(UploadInvoiceXmlReqDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var responseDto = await _httpService.SendPostRequest<UploadInvoiceResponseDto>(Urls.SendInvoices.Upload, data);
        return responseDto;
    }

    public async Task<UploadInvoiceSignedResDto> UploadInvoiceSigned(UploadInvoiceSignedXmlReqDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var responseDto = await _httpService.SendPostRequest<UploadInvoiceSignedResDto>(Urls.SendInvoices.UploadSigned, data);
        return responseDto;
    }
}
