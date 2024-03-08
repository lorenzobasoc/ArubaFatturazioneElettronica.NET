using ArubaFatturazioneElettronica.NET.DTOs.SendOutcomeClient.Request;
using ArubaFatturazioneElettronica.NET.DTOs.SendOutcomeClient.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISendOutcomeClient
{
    Task<SendOutcomeClientResDto> SendEsitoCommittente(SendOutcomeClientReqDto dto);
    Task<SendInvoiceOutcomeClientReqDto> StateOfSendEsitoCommittente(string filename);
}
