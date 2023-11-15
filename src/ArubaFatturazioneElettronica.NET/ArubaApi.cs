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

    public ArubaApi() {
        Auth = new Auth();
        FinancialCommunications = new FinancialCommunications();
        SendInvoices = new SendInvoices();
        SearchSentInvoices = new SearchSentInvoices();
        SearchReceivedInvoices = new SearchReceivedInvoices();
        SendOutcomeClient = new SendOutcomeClient();
        SearchNotificationSentInvoices = new SearchNotificationSentInvoices();
        SearchNotificationReceivedInvoices = new SearchNotificationReceivedInvoices();
    }
}
