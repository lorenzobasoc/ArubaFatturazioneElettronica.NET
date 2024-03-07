using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoiceNotifications(HttpService requester) : ISearchReceivedInvoiceNotifications
{
    private readonly HttpService _requester = requester;
}
