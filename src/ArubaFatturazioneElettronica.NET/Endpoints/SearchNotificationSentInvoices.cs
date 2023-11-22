using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchNotificationSentInvoices : ISearchNotificationSentInvoices
{
    private readonly HttpHandler _requester;

    public SearchNotificationSentInvoices(HttpHandler requester) {
        _requester = requester;
    }
}
