using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoices : ISearchReceivedInvoices
{
    private readonly HttpService _requester;

    public SearchReceivedInvoices(HttpService requester) {
        _requester = requester;
    }
}
