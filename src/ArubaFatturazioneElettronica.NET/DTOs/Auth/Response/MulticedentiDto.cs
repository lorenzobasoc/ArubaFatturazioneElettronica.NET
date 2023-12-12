namespace ArubaFatturazioneElettronica.NET.DTOs.Auth.Response;

public class MulticedentiDto
{
    public MulticedenteDto[] Content { get; set; }
    public bool First { get; set; }
    public bool Last { get; set; }
    public int Number { get; set; }
    public int NumberOfElements { get; set; }
    public double Size { get; set; }
    public int TotalElements { get; set; }
    public int TotalPages { get; set; }
    public int MyProperty { get; set; }
}
