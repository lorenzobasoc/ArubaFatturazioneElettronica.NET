using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class Auth : IAuth
{
    private readonly HttpHandler _requester;
    private readonly string _username;
    private readonly string _password;

    public Auth(HttpHandler requester, string username, string password) {
        _requester = requester;
        _username = username;
        _password = password;
    }
}
