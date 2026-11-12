namespace Kutuphane;

public class Kitap
{
    public int Id { get; init; }
    public required string Ad { get; init; }
    public required string Yazar { get; init; }
    public decimal Fiyat { get; set; }
    public bool OduncteMi { get; set; }
}
