<h1 align="center">ArubaFatturazioneElettronica.NET</h1>

**ArubaFatturazioneElettronica.NET** is a Aruba Fatturazione Elettronica API client for C# developers.

<hr>

## 🔧 Installation

- .NET CLI

```bash
dotnet add package ArubaFatturazioneElettronica.NET
```

- Package Manager Console

```bash
Install-Package ArubaFatturazioneElettronica.NET
```

## 🚀 How to use it
```c#
class Program
{
    static async Task Main(string[] args) {
        var client = new ArubaApi("username", "password");

        // Get user's infos
        var userInfo = await arubaApi.Auth.GetUserInfo();

        // Get transmission info request
        var multicedente = await arubaApi.FinancialCommunications.GetTransmissionInfoRequest(
            new GetTransmissionInfoReqDto {
                UserName = "username2",
                Password = "psw",
                RequestID = "976",
            }
        );

        // Search sent invoices pdd
        var stream = await arubaApi.SearchSentInvoices.Pdd("IT01879020517A2024_aaa2m.xml.p7m", null);
        var fileStreamResult = new FileStreamResult(stream.Result, "application/zip") {
            FileDownloadName = "pdd.zip",
        };

        // Upload invoice
        var response = await arubaApi.SendInvoices.UploadInvoice(new UploadInvoiceReqDto {
            Data = new InoviceDataDto {
                IsPaInvoice = false,
                TransportCost = 12.3M,
                Items = [
                    new ItemDto {
                        Description = "description 1",
                        Quantity = 3,
                        MeasureUnit = "NR",
                        UnitPrice = 21.00M,
                        Vat = VatTypes.VENTIDUE,
                    },
                    new ItemDto {
                        Description = "description 2",
                        Quantity = 4,
                        MeasureUnit = "pz",
                        UnitPrice = 22247,
                        Vat = VatTypes.DIECI,
                    },
                ],
                CustomerData = new CustomerDataDto {
                    VatNumOrFiscalCode = "11111111112",
                    Country = "IT",
                    Denomination = "Customer Denomination",
                    SiteStreet = "viale Trieste 34",
                },
                TransmissionData = new TransmissionDataDto {
                    TransmitterCountry = "IT",
                    TransmitterVatCode = "01879020517",
                    ..
                },
                SupplierData = new SupplierDataDto {
                    SupplierCountry = "IT",
                    SupplierVat = "00123456787",
                    SupplierName = "Name",
                    ...
                },
                GeneralData = new GeneralDataDto {
                    DocumentType = "TD01",
                    ...
                },
                PaymentData = new PaymentDataDto {
                    PaymentConditions = "TP02",
                    ...
                },
            },
        });
    }  
}
```

# 🧰 All covered API endpoints

1. Auth
    - userInfo
    - multicedenti
    - multicedenteById

2. Comunicazioni finanziarie
    - CreateTransmissionRequest
    - GetTransmissionInfoRequest
    - pdd

3. Invio Fatture Elettroniche
    - upload
    - uploadSigned

4. Ricerca Fatture Inviate
    - findByUsername
    - getByFilename
    - getZipByFilename
    - getByInvoiceId
    - getByIdSdi
    - pdd

5. Ricerca Fatture Ricevute
    - findByUsername
    - getByFilename
    - getZipByFilename
    - getByIdSdi
    - getInvoiceWithUnsignedFile
    - pdd

6. Invio Esito Committente
    - sendEsitoCommittente
    - Stato sendEsitoCommittente

7. Ricerca Notifiche su Fatture Inviate
    - getByFilename
    - getByInvoiceFilename
    - getByInvoiceId

8. Ricerca Notifiche su Fatture Ricevute
    - getByFilename
    - getByInvoiceFilename
    - getByInvoiceId
