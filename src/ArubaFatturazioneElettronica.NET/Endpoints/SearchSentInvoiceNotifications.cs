using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoiceNotification : ISearchSentInvoiceNotifications
{
    private readonly HttpService _requester;

    public SearchSentInvoiceNotification(HttpService requester) {
        _requester = requester;
    }
}
