using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendInvoices(HttpService requester) : ISendInvoices
{
    private readonly HttpService _requester = requester;
}
