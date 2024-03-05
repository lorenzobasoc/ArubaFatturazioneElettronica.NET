namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface IArubaApi
{
    IAuth Auth { get; }
    IFinancialCommunications FinancialCommunications { get; }
    ISendInvoices SendInvoices { get; }
    ISearchSentInvoices SearchSentInvoices { get; }
    ISearchReceivedInvoices SearchReceivedInvoices { get; }
    ISendOutcomeClient SendOutcomeClient { get; }
    ISearchSentInvoiceNotifications SearchNotificationSentInvoices { get; }
    ISearchReceivedInvoiceNotifications SearchNotificationReceivedInvoices { get; }
}
