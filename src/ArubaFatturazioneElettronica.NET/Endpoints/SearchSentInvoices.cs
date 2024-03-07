using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoices(HttpService requester) : ISearchSentInvoices
{
    private readonly HttpService _requester = requester;
}
