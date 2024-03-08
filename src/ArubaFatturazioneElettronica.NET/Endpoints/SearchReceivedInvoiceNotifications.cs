using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.DTOs.SearchInvoiceNotifications.Response;
using ArubaFatturazioneElettronica.NET.Interfaces;
using ArubaFatturazioneElettronica.NET.Services;
using ArubaFatturazioneElettronica.NET.Utilities;

namespace ArubaFatturazioneElettronica.NET.Endpoints;

public class SearchReceivedInvoiceNotifications(HttpService httpService) : ISearchReceivedInvoiceNotifications
{
    private readonly HttpService _httpService = httpService;

    public async Task<GetByFilenameNotifyResDto> GetByFilename(string filename) {
        var queryParams = new Dictionary<string, string> {
            { nameof(filename), filename },
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetByFilenameNotifyResDto>(Urls.SearchReceivedInvoiceNotification.GetByFilename, queryString);
        return responseDto;
    }

    public async Task<GetByInvoiceFilenameNotifyResDto> GetByInvoiceFilename(string invoiceFilename) {
        var queryParams = new Dictionary<string, string> {
            { nameof(invoiceFilename), invoiceFilename },
        };
        var queryString = HttpUtils.ComposeQueryString(queryParams);
        var responseDto = await _httpService.SendGetRequest<GetByInvoiceFilenameNotifyResDto>(Urls.SearchReceivedInvoiceNotification.GetByInvoiceFilename, queryString);
        return responseDto;
    }

    public async Task<GetByInvoiceIdNotifyResDto> GetByInvoiceId(string invoiceId) {
        var responseDto = await _httpService.SendGetRequest<GetByInvoiceIdNotifyResDto>(Urls.SearchReceivedInvoiceNotification.GetByInvoiceId + $"/{invoiceId}", null);
        return responseDto;
    }
}
