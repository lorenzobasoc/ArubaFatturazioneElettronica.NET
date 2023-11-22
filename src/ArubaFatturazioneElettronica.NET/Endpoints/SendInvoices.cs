using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SendInvoices : ISendInvoices
{
    private readonly HttpHandler _requester;

    public SendInvoices(HttpHandler requester) {
        _requester = requester;
    }
}
