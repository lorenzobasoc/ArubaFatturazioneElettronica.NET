using ArubaFatturazioneElettronica.NET.Dtos.SendOutcomeClient.Request;
using ArubaFatturazioneElettronica.NET.Dtos.SendOutcomeClient.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISendOutcomeClient
{
    Task<SendOutcomeClientResDto> SendEsitoCommittente(SendOutcomeClientReqDto dto);
    Task<SendInvoiceOutcomeClientReqDto> StateOfSendEsitoCommittente(string filename);
}
