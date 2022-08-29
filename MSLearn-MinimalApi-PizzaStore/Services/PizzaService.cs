using MSLearn_MinimalApi_PizzaStore.Data;
using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Services;

public class PizzaService : IPizzaService
{
    public Pizza? GetPizza(int id)
    {
        return PizzaDb.GetPizza(id);
    }

    public List<Pizza> GetPizzas()
    {
        return PizzaDb.GetPizzas();
    }

    public IResult AddPizza(Pizza pizza)
    {
        return PizzaDb.CreatePizza(pizza);
    }
    
    public IResult UpdatePizza(Pizza pizza)
    {
        return PizzaDb.UpdatePizza(pizza);
    }

    public IResult DeletePizza(int id)
    {
        PizzaDb.RemovePizza(id);
        return Results.Ok($"Pizza {id} deleted with success");
    }
}