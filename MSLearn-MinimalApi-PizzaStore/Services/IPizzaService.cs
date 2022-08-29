using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Services;

public interface IPizzaService
{
    Task<IResult> GetPizza(int id);
    Task<List<Pizza>> GetPizzas();
    Task<IResult> AddPizza(Pizza pizza);
    Task<IResult> UpdatePizza(Pizza pizza, int id);
    Task<IResult> DeletePizza(int id);
    
}