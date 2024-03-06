using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class FinancialCommunications : IFinancialCommunications
{
    private readonly HttpService _requester;

    public FinancialCommunications(HttpService requester) {
        _requester = requester;
    }
}
