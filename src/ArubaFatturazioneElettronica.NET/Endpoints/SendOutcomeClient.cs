using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos.SendOutcomeClient.Request;
using ArubaFatturazioneElettronica.NET.Dtos.SendOutcomeClient.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendOutcomeClient(HttpService httpService) : ISendOutcomeClient
{
    private readonly HttpService _httpService = httpService;

    public async Task<SendOutcomeClientResDto> SendEsitoCommittente(SendOutcomeClientReqDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var responseDto = await _httpService.SendPostRequest<SendOutcomeClientResDto>(Urls.SendOutcomeClient.Send, data);
        return responseDto;
    }

    public async Task<SendInvoiceOutcomeClientReqDto> StateOfSendEsitoCommittente(string filename) {
        var responseDto = await _httpService.SendGetRequest<SendInvoiceOutcomeClientReqDto>(Urls.SendOutcomeClient.Send + $"/{filename}", null);
        return responseDto;
    }
}
