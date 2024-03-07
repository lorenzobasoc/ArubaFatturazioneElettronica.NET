using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoiceNotification(HttpService requester) : ISearchSentInvoiceNotifications
{
    private readonly HttpService _requester = requester;
}
