namespace ArubaFatturazioneElettronica.NET.Exceptions;

public class ArubaFatturazioneElettronicaException(
    string errorCode, 
    string errorDescription) : Exception($"{errorCode}: {errorDescription}")
{
    public string ErrorCode { get; } = errorCode;
    public string ErrorDescription { get; } = errorDescription;
}