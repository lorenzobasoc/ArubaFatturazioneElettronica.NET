using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendOutcomeClient : ISendOutcomeClient
{
    private readonly HttpHandler _requester;

    public SendOutcomeClient(HttpHandler requester) {
        _requester = requester;
    }
}
