namespace MSLearn_MinimalApi_PizzaStore.Models;


public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}