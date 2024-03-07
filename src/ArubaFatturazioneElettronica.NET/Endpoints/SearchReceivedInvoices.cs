using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoices(HttpService requester) : ISearchReceivedInvoices
{
    private readonly HttpService _requester = requester;
}
