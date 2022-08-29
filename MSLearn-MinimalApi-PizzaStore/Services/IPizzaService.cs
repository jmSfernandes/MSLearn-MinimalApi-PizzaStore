using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Services;

public interface IPizzaService
{
    Pizza? GetPizza(int id);
    List<Pizza> GetPizzas();
    IResult AddPizza(Pizza pizza);
    IResult UpdatePizza(Pizza pizza);
    IResult DeletePizza(int id);
    
}