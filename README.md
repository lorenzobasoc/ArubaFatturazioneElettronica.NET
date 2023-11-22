# API ENDPOINTS

1. Auth
    - signin #auth-signin
    - refresh token #auth-refresh
    - userInfo #auth-user-info
    - multicedenti #_multicedenti
    - multicedenteById #_multicedentebyid

2. Comunicazioni finanziarie
    - CreateTransmissionRequest #_createtransmissionrequest 
    - GetTransmissionInfoRequest #services-clientrequest-info
    - pdd

3. Invio Fatture Elettroniche
    - upload #services-invoice-upload
    - uploadSigned #services-invoice-upload-signed

4. Ricerca Fatture Inviate
    - findByUsername #_findbyusername
    - getByFilename #services-invoice-out-getByFilename
    - getZipByFilename #services-invoice-out-getZipByFilename
    - getByInvoiceId #services-invoice-out-invoiceId
    - getByIdSdi #services-invoice-out-getByIdSdi
    - pdd #services-invoice-out-pdd

5. Ricerca Fatture Ricevute
    - findByUsername #_findbyusername_2
    - getByFilename #services-invoice-in-getByFilename
    - getZipByFilename #_getzipbyfilename
    - getByIdSdi #services-invoice-in-getByIdSdi
    - getInvoiceWithUnsignedFile #getInvoiceWithUnsignedFile
    - pdd #services-invoice-in-pdd

6. Invio Esito Committente
    - sendEsitoCommittente #_sendesitocommittente
    - Stato sendEsitoCommittente #_stato_sendesitocommittente

7. Ricerca Notifiche su Fatture Inviate
    - getByFilename #_getbyfilename
    - getByInvoiceFilename #_getbyinvoicefilename
    - getByInvoiceId #_getbyinvoiceid

8. Ricerca Notifiche su Fatture Ricevute
    - getByFilename #_getbyfilename_2
    - getByInvoiceFilename #_getbyinvoicefilename_2
    - getByInvoiceId #_getbyinvoiceid_2