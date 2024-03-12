using ArubaFatturazioneElettronica.NET.Dtos.FinancialComunications.Request;
using ArubaFatturazioneElettronica.NET.Dtos.FinancialComunications.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface IFinancialCommunications
{
    Task<CreateTransmissionResDto> CreateTransmissionRequest(CreateTransmissionReqtDto dto);
    Task<GetTransmissionInfoResDto> GetTransmissionInfoRequest(GetTransmissionInfoReqDto dto);
}
