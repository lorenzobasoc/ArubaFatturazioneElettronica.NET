using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoices : ISearchSentInvoices
{
    private readonly HttpService _requester;

    public SearchSentInvoices(HttpService requester) {
        _requester = requester;
    }
}
