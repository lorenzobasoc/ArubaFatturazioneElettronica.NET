using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoiceNotifications : ISearchReceivedInvoiceNotifications
{
    private readonly HttpService _requester;

    public SearchReceivedInvoiceNotifications(HttpService requester) {
        _requester = requester;
    }
}
