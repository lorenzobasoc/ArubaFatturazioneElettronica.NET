using ArubaFatturazioneElettronica.NET.DTOs.SearchInvoiceNotifications.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISearchSentInvoiceNotifications
{
    Task<GetByFilenameNotifyResDto> GetByFilename(string filename);
    Task<GetByInvoiceFilenameNotifyResDto> GetByInvoiceFilename(string invoiceFilename);
    Task<GetByInvoiceIdNotifyResDto> GetByInvoiceId(string invoiceId);
}
