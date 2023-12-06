namespace Api.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool Insured { get; set; }
}