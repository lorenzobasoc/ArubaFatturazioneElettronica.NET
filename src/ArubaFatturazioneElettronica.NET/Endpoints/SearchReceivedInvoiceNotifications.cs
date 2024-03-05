using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoiceNotifications : ISearchReceivedInvoiceNotifications
{
    private readonly HttpHandler _requester;

    public SearchReceivedInvoiceNotifications(HttpHandler requester) {
        _requester = requester;
    }
}
