namespace Api.Models;

public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Percent { get; set; }
}