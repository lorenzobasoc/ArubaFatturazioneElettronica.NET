using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos;
using ArubaFatturazioneElettronica.NET.Dtos.SearchInvoices.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchSentInvoices(HttpService httpService) : ISearchSentInvoices
{
    private readonly HttpService _httpService = httpService;

    public async Task<FindByUsernameResDto> FindByUsername(string username, string countrySender, string vatcodeSender, string fiscalcodeSender = null, string countryReceiver = null, string vatcodeReceiver = null, string fiscalcodeReceiver = null, int page = 1, int size = 10, DateTime? startDate = null, DateTime? endDate = null) {
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
        var responseDto = await _httpService.SendGetRequest<FindByUsernameResDto>(baseUrl + Urls.SearchSentInvoices.FindByUsername, queryString);
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
        var responseDto = await _httpService.SendGetRequest<GetByFilenameResDto>(baseUrl + Urls.SearchSentInvoices.GetByFilename, queryString);
        return responseDto;
    }

    public async Task<StreamResultDto> GetZipByFilename(string filename) {
        var queryParams = new Dictionary<string, string> {
            {nameof(filename), filename},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendStreamGetRequest(baseUrl + Urls.SearchSentInvoices.GetZipByFilename, queryString);
        return responseDto;
    }

    public async Task<GetByInvoiceIdResDto> GetByInvoiceId(string invoiceId, bool includePdf = false, bool includeFile = true) {
        var queryParams = new Dictionary<string, string> {
            {nameof(includePdf), includePdf.ToString()},
            {nameof(includeFile), includeFile.ToString()},
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var baseUrl = Urls.GetBaseUrl(_httpService.Env);
        var responseDto = await _httpService.SendGetRequest<GetByInvoiceIdResDto>(baseUrl + Urls.SearchSentInvoices.GetByInvoiceId + $"/{invoiceId}", queryString);
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
        var responseDto = await _httpService.SendGetRequest<GetByIdSdiResDto>(baseUrl + Urls.SearchSentInvoices.GetByIdSdi, queryString);
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
        var stream = await _httpService.SendStreamGetRequest(baseUrl + Urls.SearchSentInvoices.Pdd, queryString);
        return stream;
    }
}
