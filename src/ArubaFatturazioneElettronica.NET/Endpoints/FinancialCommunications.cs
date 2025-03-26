using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos;
using ArubaFatturazioneElettronica.NET.Dtos.FinancialComunications.Request;
using ArubaFatturazioneElettronica.NET.Dtos.FinancialComunications.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class FinancialCommunications(HttpService httpService) : IFinancialCommunications
{
    private readonly HttpService _httpService = httpService;

    public async Task<CreateTransmissionResDto> CreateTransmissionRequest(CreateTransmissionReqtDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendPostRequest<CreateTransmissionResDto>(baseUrl + Urls.FinancialCommunications.CreateTransmissionReq, data);
        return responseDto;
    }
    
    public async Task<GetTransmissionInfoResDto> GetTransmissionInfoRequest(GetTransmissionInfoReqDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendPostRequest<GetTransmissionInfoResDto>(baseUrl + Urls.FinancialCommunications.GetTransmissionInfoReq, data);
        return responseDto;
    }

    public async Task<StreamResultDto> Pdd(PddReqDto dto) {
        var data = HttpUtils.ComposePostBody(dto);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendStreamPostRequest(baseUrl + Urls.FinancialCommunications.Pdd, data);
        return responseDto;
    }
}
