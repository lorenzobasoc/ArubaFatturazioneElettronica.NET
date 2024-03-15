using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos;
using ArubaFatturazioneElettronica.NET.Dtos.SearchInvoices.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoices(HttpService http_Service) : ISearchReceivedInvoices
{
    private readonly HttpService _httpService = http_Service;

    public async Task<FindByUsernameResDto> FindByUsername(string username, string countryReceiver, string vatcodeReceiver, string fiscalcodeSender = null, string countrySender = null, string vatcodeSender = null, string fiscalcodeReceiver = null, int page = 1, int size = 10, DateTime? startDate = null, DateTime? endDate = null) {
        var queryParams = new Dictionary<string, string> {
            { nameof(username), username },
            { nameof(countrySender), countrySender },
            { nameof(vatcodeSender), vatcodeSender },
            { nameof(fiscalcodeSender), fiscalcodeSender },
            { nameof(countryReceiver), countryReceiver },
            { nameof(vatcodeReceiver), vatcodeReceiver },
            { nameof(fiscalcodeReceiver), fiscalcodeReceiver },
            { nameof(page), page.ToString() },
            { nameof(size), size.ToString() },
            { nameof(startDate), (startDate ?? DateTime.MinValue).ToString("o") },
            { nameof(endDate), (endDate ?? DateTime.Now).ToString("o") },
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<FindByUsernameResDto>(Urls.SearchReceivedInvoices.FindByUsername, queryString);
        return responseDto;
    }

    public async Task<GetByFilenameResDto> GetByFilename(string filename, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(filename), filename},
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetByFilenameResDto>(Urls.SearchReceivedInvoices.GetByFilename, queryString);
        return responseDto;
    }

    public async Task<StreamResultDto> GetZipByFilename(string filename) {
        var queryParams = new Dictionary<string, string> {
            {nameof(filename), filename},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendStreamGetRequest(Urls.SearchReceivedInvoices.GetZipByFilename, queryString);
        return responseDto;
    }

    public async Task<GetByInvoiceIdResDto> GetByInvoiceId(string invoiceId, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetByInvoiceIdResDto>(Urls.SearchReceivedInvoices.GetByInvoiceId + $"/{invoiceId}", queryString);
        return responseDto;
    }

    public async Task<GetByIdSdiResDto> GetByIdSdi(string idSdi, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(idSdi), idSdi},
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetByIdSdiResDto>(Urls.SearchReceivedInvoices.GetByIdSdi, queryString);
        return responseDto;
    }

    public async Task<GetInvoiceWithUnsignedFileResDto> GetInvoiceWithUnsignedFile(bool includeFile = false) {
         var queryParams = new Dictionary<string, string> {
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetInvoiceWithUnsignedFileResDto>(Urls.SearchReceivedInvoices.GetWithUnsignedFile, queryString);
        return responseDto;
    }

    public async Task<StreamResultDto> Pdd(string invoiceFilename, string invoiceId) {
        var queryParams = new Dictionary<string, string> {
            {nameof(invoiceFilename), invoiceFilename},
            {nameof(invoiceId), invoiceId},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var stream = await _httpService.SendStreamGetRequest(Urls.SearchReceivedInvoices.Pdd, queryString);
        return stream;
    }
}
