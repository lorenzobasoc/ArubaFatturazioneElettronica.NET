using ArubaFatturazioneElettronica.NET.Comunication;
using ArubaFatturazioneElettronica.NET.Endpoints;
using ArubaFatturazioneElettronica.NET.Interfaces;

namespace ArubaFatturazioneElettronica.NET;

public class ArubaApi : IArubaApi
{
    public IAuth Auth { get; }
    public IFinancialCommunications FinancialCommunications { get; }
    public ISendInvoices SendInvoices { get; }
    public ISearchSentInvoices SearchSentInvoices { get; }
    public ISearchReceivedInvoices SearchReceivedInvoices { get; }
    public ISendOutcomeClient SendOutcomeClient { get; }
    public ISearchNotificationSentInvoices SearchNotificationSentInvoices { get; }
    public ISearchNotificationReceivedInvoices SearchNotificationReceivedInvoices { get; }

    public ArubaApi(string username, string password) {
        var requester = new HttpHandler();

        Auth = new Auth(requester, username, password);
        FinancialCommunications = new FinancialCommunications(requester);
        SendInvoices = new SendInvoices(requester);
        SearchSentInvoices = new SearchSentInvoices(requester);
        SearchReceivedInvoices = new SearchReceivedInvoices(requester);
        SendOutcomeClient = new SendOutcomeClient(requester);
        SearchNotificationSentInvoices = new SearchNotificationSentInvoices(requester);
        SearchNotificationReceivedInvoices = new SearchNotificationReceivedInvoices(requester);
    }
}
