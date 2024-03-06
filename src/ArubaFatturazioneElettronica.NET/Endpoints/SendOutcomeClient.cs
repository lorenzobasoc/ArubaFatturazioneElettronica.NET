using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendOutcomeClient : ISendOutcomeClient
{
    private readonly HttpService _requester;

    public SendOutcomeClient(HttpService requester) {
        _requester = requester;
    }
}
