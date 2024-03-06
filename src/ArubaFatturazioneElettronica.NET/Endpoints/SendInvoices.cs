using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendInvoices : ISendInvoices
{
    private readonly HttpService _requester;

    public SendInvoices(HttpService requester) {
        _requester = requester;
    }
}
