using ArubaFatturazioneElettronica.NET.DTOs.FinancialComunications.Request;
using ArubaFatturazioneElettronica.NET.DTOs.FinancialComunications.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface IFinancialCommunications
{
    Task<CreateTransmissionResDto> CreateTransmissionRequest(CreateTransmissionReqtDto dto);
    Task<GetTransmissionInfoResDto> GetTransmissionInfoRequest(GetTransmissionInfoReqDto dto);
}
