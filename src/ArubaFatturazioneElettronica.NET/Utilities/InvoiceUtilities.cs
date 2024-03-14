using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ArubaFatturazioneElettronica.NET.Constants;
using ArubaFatturazioneElettronica.NET.Dtos.SendInvoices.Request;
using ArubaFatturazioneElettronica.NET.Invoices;
using ArubaFatturazioneElettronica.NET.Invoices.Resource;
using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data;
using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body;
using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Body.DatiGenerali;
using ArubaFatturazioneElettronica.NET.Invoices.Resource.Data.Header;
using CsbEcommerce.Enumerations;

using static ArubaFatturazioneElettronica.NET.Utilities.VatDictionary;

namespace ArubaFatturazioneElettronica.NET.Utilities;

public class InvoiceUtilities
{
    public static async Task<string> CreateXml(FatturaElettronica invoice) {
        var xml = new XmlSerializer(typeof(FatturaElettronica));
        using var ms = new MemoryStream();
        using var writer = new StreamWriter(ms, new UTF8Encoding());
        xml.Serialize(writer, invoice);
        using var reader = new StreamReader(ms);
        ms.Position = 0;
        var fileText = await reader.ReadToEndAsync();
        return fileText;
    }

    public static FatturaElettronica CreateFatturaElettronica(InoviceDataDto data) {
        var detailLines = CreateDetailLines(data.Items);
        if (data.TransportCost > 0) {
            var line = GenerateTransportCostLine(detailLines, data.TransportCost);
            detailLines.Add(line);
        }
        var summaryDetail = CreateDataSummary(detailLines, data.IsPaInvoice);
        var totalIva = summaryDetail.Sum(line => line.Imposta);
        var totalImponibile = summaryDetail.Sum(line => line.ImponibileImporto);
        var invoice = new FatturaElettronica {
            FatturaElettronicaHeader = new FatturaElettronicaHeader {
                //DATI DI CHI TRASMETTE LA FATTURA
                DatiTrasmissione = new DatiTrasmissione {
                    IdTrasmittente = new IdFiscale {
                        IdPaese = data.TransmissionData.TransmitterCountry,
                        IdCodice = data.TransmissionData.TransmitterVatCode,
                    },
                    ProgressivoInvio = data.TransmissionData.ProgressiveCode,
                    FormatoTrasmissione = data.TransmissionData.TransmissionFormat,
                    CodiceDestinatario = data.TransmissionData.RecipientCode,
                },
                //DATI DEL FORNITORE
                CedentePrestatore = new CedentePrestatore {
                    DatiAnagrafici = new DatiAnagrafici {
                        IdFiscaleIVA = new IdFiscale {
                            IdPaese = data.SupplierData.SupplierCountry,
                            IdCodice = data.SupplierData.SupplierVat,
                        },
                        CodiceFiscale = data.SupplierData.SupplierVat,
                        Anagrafica = new Anagrafica {
                            Denominazione = data.SupplierData.SupplierName,
                        },
                        RegimeFiscale = data.SupplierData.SupplierTaxRegime,
                    },
                    Sede = new Sede {
                        Indirizzo = data.SupplierData.SupplierStreet,
                        CAP = data.SupplierData.SupplierCap,
                        Comune = data.SupplierData.SupplierCity,
                        Provincia = data.SupplierData.SupplierProvince,
                        Nazione = data.SupplierData.SupplierCountrySite
                    },
                    IscrizioneREA = new IscrizioneREA {
                        Ufficio = data.SupplierData.SupplierUfficeRea,
                        NumeroREA = data.SupplierData.SupplierNumberRea,
                        StatoLiquidazione = data.SupplierData.SupplierLiquidationStatus,
                    },
                    Contatti = new Contatti {
                        Email = data.SupplierData.SupplierEmail,
                    }
                },
                // DATI DEL CLIENTE
                CessionarioCommittente = new DatiEconomici {
                    DatiAnagrafici = CreatePersonalData(data.CustomerData),
                    Sede = new Sede {
                        Indirizzo = data.CustomerData.SiteStreet,
                        Comune = data.CustomerData.SiteCity,
                        CAP = data.CustomerData.SitePostalCode,
                        Provincia = data.CustomerData.SiteProvince,
                        Nazione = data.CustomerData.SiteCountry,
                    }
                }
            },
            FatturaElettronicaBody = new FatturaElettronicaBody {
                DatiGenerali = new DatiGenerali {
                    DatiGeneraliDocumento = new DatiGeneraliDocumento {
                        TipoDocumento = data.GeneralData.DocumentType,
                        Divisa = data.GeneralData.Currency,
                        Data = DateTime.Now.ToString("yyyy-MM-dd"),
                        Numero = data.GeneralData.InvoiceNumber,
                        Causale = data.GeneralData.Causal,
                    },
                    DatiOrdineAcquisto = new DatiOrdineAcquisto {
                        IdDocumento = data.GeneralData.DocumentId,
                        CodiceCIG = data.GeneralData.CigCode,
                        CodiceCUP = data.GeneralData.CupCode,
                    }
                },
                DatiBeniServizi = new DatiBeniServizi { },
                DatiPagamento = new DatiPagamento {
                    CondizioniPagamento = data.PaymentData.PaymentConditions,
                    DettaglioPagamento = new DettaglioPagamento {
                        ModalitaPagamento = data.PaymentData.PaymentMethod,
                        DataScadenzaPagamento = data.PaymentData.PaymentDueDate,
                        ImportoPagamento = data.PaymentData.Total,
                        IstitutoFinanziario = data.PaymentData.Bank,
                        IBAN = data.PaymentData.IBAN,
                        BIC = data.PaymentData.BIC,
                    }
                }
            }
        };
        invoice.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee = [.. detailLines];
        invoice.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo = summaryDetail;
        invoice.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.RiferimentoNumeroLinea = detailLines.Select(line => line.NumeroLinea).ToArray();
        invoice.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento.ImportoPagamento = totalImponibile + totalIva;
        return invoice;
    }

    private static DatiRiepilogo[] CreateDataSummary(List<DettaglioLinee> detailLines, bool isPaInvoice) {
        var dati = new List<DatiRiepilogo>();
        var groups = detailLines
            .GroupBy(d => d.AliquotaIVA)
            .ToList();
        var esigibility = isPaInvoice ? "S" : "I";
        foreach (var g in groups) {
            var tot = g.Sum(d => d.PrezzoTotale);
            switch (g.Key) {
                case VENTIDUE:
                    dati.Add(new DatiRiepilogo {
                        AliquotaIVA = VENTIDUE,
                        ImponibileImporto = decimal.Round(tot, 2),
                        Imposta = decimal.Round(tot * VENTIDUE / 100M, 2),
                        EsigibilitaIVA = esigibility,
                    });
                    break;
                case DIECI:
                    dati.Add(new DatiRiepilogo {
                        AliquotaIVA = DIECI,
                        ImponibileImporto = decimal.Round(tot, 2),
                        Imposta = decimal.Round(tot * DIECI / 100M, 2),
                        EsigibilitaIVA = esigibility,
                    });
                    break;
                case CINQUE:
                    dati.Add(new DatiRiepilogo {
                        AliquotaIVA = CINQUE,
                        ImponibileImporto = decimal.Round(tot, 2),
                        Imposta = decimal.Round(tot * CINQUE / 100M, 2),
                        EsigibilitaIVA = esigibility,
                    });
                    break;
                case QUATTRO:
                    dati.Add(new DatiRiepilogo {
                        AliquotaIVA = QUATTRO,
                        ImponibileImporto = decimal.Round(tot, 2),
                        Imposta = decimal.Round(tot * QUATTRO / 100M, 2),
                        EsigibilitaIVA = esigibility,
                    });
                    break;
                case ZERO:
                    dati.Add(new DatiRiepilogo {
                        AliquotaIVA = ZERO,
                        ImponibileImporto = decimal.Round(tot, 2),
                        Imposta = ZERO,
                        RiferimentoNormativo = InvoiceConstants.RIF_FORMATIVO,
                    });
                    break;
                default:
                    break;
            }
        }
        return [.. dati];
    }

    private static DatiAnagrafici CreatePersonalData(CustomerDataDto data) {
        var ad = new DatiAnagrafici();
        var vatRegex = new Regex(Regexes.VAT_NUMBER_PATTERN);
        if (vatRegex.IsMatch(data.VatNumOrFiscalCode)) {
            ad.IdFiscaleIVA = new IdFiscale {
                IdCodice = data.VatNumOrFiscalCode,
                IdPaese = data.Country,
            };
            ad.Anagrafica = new Anagrafica {
                Denominazione = data.Denomination,
            };
        } else {
            ad.CodiceFiscale = data.VatNumOrFiscalCode;
            ad.Anagrafica = new Anagrafica {
                Denominazione = data.Denomination,
            };
        }
        return ad; 
    }


    private static DettaglioLinee GenerateTransportCostLine(List<DettaglioLinee> list, decimal transportCost) {
        return new DettaglioLinee {
            NumeroLinea = list.Count + 1,
            Descrizione = "Spese di spedizione",
            Quantita = 1.00M,
            UnitaMisura = "NR",
            PrezzoUnitario = decimal.Round(transportCost / InvoiceConstants.STARNDAR_VAT, 2),
            PrezzoTotale = decimal.Round(transportCost / InvoiceConstants.STARNDAR_VAT, 2),
            AliquotaIVA = InvoiceConstants.STARNDAR_VAT_PERC,
        };
    }

    private static List<DettaglioLinee> CreateDetailLines(List<ItemDto> items) {
        var listDetailLines = new List<DettaglioLinee>();
        for (var i = 0; i < items.Count; i++) {
            var newDetail = new DettaglioLinee {
                NumeroLinea = i,
                Descrizione = items[i].Description,
                Quantita = items[i].Quantity + 0.00M,
                UnitaMisura = items[i].MeasureUnit,
                PrezzoUnitario = items[i].UnitPrice,
                PrezzoTotale = items[i].UnitPrice * items[i].Quantity,
            };
            switch (items[i].Vat) {
                case VatTypes.VENTIDUE:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.VENTIDUE];
                    break;
                case VatTypes.DIECI:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.DIECI];
                    break;
                case VatTypes.CINQUE:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.CINQUE];
                    break;
                case VatTypes.QUATTRO:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.QUATTRO];
                    break;
                case VatTypes.ZERO:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.ZERO];
                    newDetail.Natura = InvoiceConstants.NATURA_ESC;
                    break;
                case VatTypes.EX_ART_15:
                    newDetail.AliquotaIVA = VAT_VALUES[VatTypes.EX_ART_15];
                    newDetail.Natura = InvoiceConstants.NATURA_EX_ART_15;
                    break;
                default:
                    newDetail.AliquotaIVA = 0.00M;
                    newDetail.Natura = InvoiceConstants.NATURA_ESC;
                    break;
            }
            listDetailLines.Add(newDetail);
        }
        return listDetailLines;
    }
}
