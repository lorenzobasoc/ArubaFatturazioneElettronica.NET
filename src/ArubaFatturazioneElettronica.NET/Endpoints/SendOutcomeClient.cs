using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendOutcomeClient(HttpService requester) : ISendOutcomeClient
{
    private readonly HttpService _requester = requester;
}
