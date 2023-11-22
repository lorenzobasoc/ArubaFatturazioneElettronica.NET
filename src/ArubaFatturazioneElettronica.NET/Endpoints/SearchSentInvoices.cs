using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoices : ISearchSentInvoices
{
    private readonly HttpHandler _requester;

    public SearchSentInvoices(HttpHandler requester) {
        _requester = requester;
    }
}
