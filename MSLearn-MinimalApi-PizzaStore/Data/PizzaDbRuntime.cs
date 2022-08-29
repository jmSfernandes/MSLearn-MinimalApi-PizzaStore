using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Data;

public class PizzaDbRuntime
{
    private static List<Pizza> _pizzas = new List<Pizza>()
    {
        new Pizza {Id = 1, Name = "Montemagno, Pizza shaped like a great mountain"},
        new Pizza {Id = 2, Name = "The Galloway, Pizza shaped like a submarine, silent but deadly"},
        new Pizza {Id = 3, Name = "The Noring, Pizza shaped like a Viking helmet, where's the mead"}
    };

    public static List<Pizza> GetPizzas()
    {
        return _pizzas;
    }

    public static Pizza? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static IResult CreatePizza(Pizza pizza)
    {
        var verification = _pizzas.SingleOrDefault(x => x.Id == pizza.Id);
        if (verification != null)
            return Results.UnprocessableEntity("This pizza is already in the database!");
        _pizzas.Add(pizza);

        return Results.Created($"/pizzas/{pizza.Id}", pizza);
    }

    public static IResult UpdatePizza(Pizza update)
    {
        var found = false;
        _pizzas = _pizzas.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
                found = true;
            }

            return pizza;
        }).ToList();
        if (!found)
            return Results.NotFound($"Entity with Id: {update.Id} not found");
        
        return Results.Ok(update);
    }

    public static void RemovePizza(int id)
    {
        _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
    }
}