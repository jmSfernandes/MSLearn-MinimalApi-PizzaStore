using EndpointDefinitions;
using MSLearn_MinimalApi_PizzaStore.Data;
using MSLearn_MinimalApi_PizzaStore.Models;
using MSLearn_MinimalApi_PizzaStore.Services;

namespace MSLearn_MinimalApi_PizzaStore.EndpointDefinitions;

public class PizzaEndpointDefinition : IEndpointDefinition
{
    
    
    public void DefineEndpoints(WebApplication app)
    {
      
        app.MapGet("/", ()=>"Hello World!")
            .WithName("Hello World").WithTags("Data");
        app.MapGet("/pizzas/{id}", GetPizza);
        app.MapGet("/pizzas", GetPizzas);
        app.MapPost("/pizzas", AddPizza);
        app.MapPut("/pizzas", UpdatePizza);
        app.MapDelete("/pizzas/{id}", DeletePizza);
    }

    public void DefineServices(IServiceCollection services)
    {
        //services.AddScoped<EstimationsService>();
        services.AddScoped<IPizzaService, PizzaService>();
    }

    private List<Pizza> GetPizzas(IPizzaService service)
    {
        return service.GetPizzas();
    }
    private Pizza? GetPizza(IPizzaService service, int id)
    {
        return service.GetPizza(id);
    }
    
    private IResult AddPizza(IPizzaService service, Pizza pizza)
    {
        return service.AddPizza(pizza);
    }
    private IResult UpdatePizza(IPizzaService service, Pizza pizza)
    {
        return service.UpdatePizza(pizza);
    }
    private IResult DeletePizza(IPizzaService service, int id)
    {
        return service.DeletePizza(id);
    }
    
}