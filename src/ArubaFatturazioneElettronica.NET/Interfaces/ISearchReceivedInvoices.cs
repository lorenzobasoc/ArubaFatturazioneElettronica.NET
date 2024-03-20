using ArubaFatturazioneElettronica.NET.Dtos;
using ArubaFatturazioneElettronica.NET.Dtos.SearchInvoices.Response;

namespace ArubaFatturazioneElettronica.NET.Interfaces;

public interface ISearchReceivedInvoices
{
    Task<FindByUsernameResDto> FindByUsername(string username, string countrySender, string vatcodeSender, string fiscalcodeSender = null, string countryReceiver = null, string vatcodeReceiver = null, string fiscalcodeReceiver = null, int page = 1, int size = 10, DateTime? startDate = null, DateTime? endDate = null);
    Task<GetByFilenameResDto> GetByFilename(string filename, bool includePdf = false, bool includeFile = true);
    Task<StreamResultDto> GetZipByFilename(string filename);
    Task<GetByInvoiceIdResDto> GetByInvoiceId(string invoiceId, bool includePdf = false, bool includeFile = true);
    Task<GetByIdSdiResDto> GetByIdSdi(string idSdi, bool includePdf = false, bool includeFile = true);
    Task<GetInvoiceWithUnsignedFileResDto> GetInvoiceWithUnsignedFile(string invoiceFilename, string invoiceId, bool includeFile = false);
    Task<StreamResultDto> Pdd(string invoiceFilename, string invoiceId);
}
