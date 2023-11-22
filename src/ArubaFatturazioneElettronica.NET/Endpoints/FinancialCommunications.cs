using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class FinancialCommunications : IFinancialCommunications
{
    private readonly HttpHandler _requester;

    public FinancialCommunications(HttpHandler requester) {
        _requester = requester;
    }
}
