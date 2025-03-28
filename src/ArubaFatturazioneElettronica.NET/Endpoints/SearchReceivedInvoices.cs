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
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<FindByUsernameResDto>(baseUrl + Urls.SearchReceivedInvoices.FindByUsername, queryString);
        return responseDto;
    }

    public async Task<GetByFilenameResDto> GetByFilename(string filename, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(filename), filename},
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<GetByFilenameResDto>(baseUrl + Urls.SearchReceivedInvoices.GetByFilename, queryString);
        return responseDto;
    }

    public async Task<StreamResultDto> GetZipByFilename(string filename) {
        var queryParams = new Dictionary<string, string> {
            {nameof(filename), filename},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendStreamGetRequest(baseUrl + Urls.SearchReceivedInvoices.GetZipByFilename, queryString);
        return responseDto;
    }

    public async Task<GetByInvoiceIdResDto> GetByInvoiceId(string invoiceId, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<GetByInvoiceIdResDto>(baseUrl + Urls.SearchReceivedInvoices.GetByInvoiceId + $"/{invoiceId}", queryString);
        return responseDto;
    }

    public async Task<GetByIdSdiResDto> GetByIdSdi(string idSdi, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(idSdi), idSdi},
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<GetByIdSdiResDto>(baseUrl + Urls.SearchReceivedInvoices.GetByIdSdi, queryString);
        return responseDto;
    }

    public async Task<GetInvoiceWithUnsignedFileResDto> GetInvoiceWithUnsignedFile(string invoiceFilename, string invoiceId, bool includeFile = false) {
        if (string.IsNullOrEmpty(invoiceFilename) && string.IsNullOrEmpty(invoiceId)) {
            return new GetInvoiceWithUnsignedFileResDto {
                ErrorDescription = $"Please insert at least one between {nameof(invoiceFilename)} and {nameof(invoiceId)}",
            };
        }
         var queryParams = new Dictionary<string, string> {
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<GetInvoiceWithUnsignedFileResDto>(baseUrl + Urls.SearchReceivedInvoices.GetWithUnsignedFile, queryString);
        return responseDto;
    }

    public async Task<StreamResultDto> Pdd(string invoiceFilename, string invoiceId) {
        if (string.IsNullOrEmpty(invoiceFilename) && string.IsNullOrEmpty(invoiceId)) {
            return new StreamResultDto {
                Message = $"Please insert at least one between {nameof(invoiceFilename)} and {nameof(invoiceId)}",
            };
        }
        var queryParams = new Dictionary<string, string> {
            {nameof(invoiceFilename), invoiceFilename},
            {nameof(invoiceId), invoiceId},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var stream = await _httpService.SendStreamGetRequest(baseUrl + Urls.SearchReceivedInvoices.Pdd, queryString);
        return stream;
    }
}
