using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Endpoints;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;

namespace ArubaFatturazioneElettronica.NET;

public class ArubaApi : IArubaApi
{
    public IAuth Auth { get; }
    public IFinancialCommunications FinancialCommunications { get; }
    public ISendInvoices SendInvoices { get; }
    public ISearchSentInvoices SearchSentInvoices { get; }
    public ISearchReceivedInvoices SearchReceivedInvoices { get; }
    public ISendOutcomeClient SendOutcomeClient { get; }
    public ISearchSentInvoiceNotifications SearchNotificationSentInvoices { get; }
    public ISearchReceivedInvoiceNotifications SearchNotificationReceivedInvoices { get; }

    public ArubaApi(string username, string password) {
        var requester = new HttpHandler();
        var httpService = new HttpService(username, password, requester);
        Auth = new Auth(httpService);
        FinancialCommunications = new FinancialCommunications(httpService);
        SendInvoices = new SendInvoices(httpService);
        SearchSentInvoices = new SearchSentInvoices(httpService);
        SearchReceivedInvoices = new SearchReceivedInvoices(httpService);
        SendOutcomeClient = new SendOutcomeClient(httpService);
        SearchNotificationSentInvoices = new SearchSentInvoiceNotification(httpService);
        SearchNotificationReceivedInvoices = new SearchReceivedInvoiceNotifications(httpService);
    }
}
