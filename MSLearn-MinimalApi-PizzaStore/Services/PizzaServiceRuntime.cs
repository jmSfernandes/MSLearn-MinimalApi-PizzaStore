using MSLearn_MinimalApi_PizzaStore.Data;
using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Services;

public class PizzaServiceRuntime //: IPizzaService
{
    
    
    public Pizza? GetPizza(int id)
    {
        return PizzaDbRuntime.GetPizza(id);
    }

    public List<Pizza> GetPizzas()
    {
        return PizzaDbRuntime.GetPizzas();
    }

    public IResult AddPizza(Pizza pizza)
    {
        return PizzaDbRuntime.CreatePizza(pizza);
    }
    
    public IResult UpdatePizza(Pizza pizza)
    {
        return PizzaDbRuntime.UpdatePizza(pizza);
    }

    public IResult DeletePizza(int id)
    {
        PizzaDbRuntime.RemovePizza(id);
        return Results.Ok($"Pizza {id} deleted with success");
    }
}