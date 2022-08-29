using MSLearn_MinimalApi_PizzaStore.Data;
using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Services;

public class PizzaService : IPizzaService
{
    private PizzaDb _db;

    public PizzaService(PizzaDb pizzaDb)
    {
        _db = pizzaDb;
        
    }

    public async Task<IResult> GetPizza(int id)
    {
        return await _db.GetPizza(id);
    }

    public async Task<List<Pizza>> GetPizzas()
    {
        return await _db.GetPizzas();
    }

    public async Task<IResult> AddPizza(Pizza pizza)
    {
        return await _db.CreatePizza(pizza);
    }

    public async Task<IResult> UpdatePizza(Pizza pizza, int id)
    {
        return await _db.UpdatePizza(pizza, id);
    }

    public async Task<IResult> DeletePizza(int id)
    {
        return await _db.RemovePizza(id);
    }
}