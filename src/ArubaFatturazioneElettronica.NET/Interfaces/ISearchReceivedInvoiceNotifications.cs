using ArubaFatturazioneElettronica.NET.Dtos.SearchInvoiceNotifications.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISearchReceivedInvoiceNotifications
{
    Task<GetByFilenameNotifyResDto> GetByFilename(string filename);
    Task<GetByInvoiceFilenameNotifyResDto> GetByInvoiceFilename(string invoiceFilename);
    Task<GetByInvoiceIdNotifyResDto> GetByInvoiceId(string invoiceId);
}
