using EndpointDefinitions;
using MSLearn_MinimalApi_PizzaStore.Models;
using MSLearn_MinimalApi_PizzaStore.Services;

namespace MSLearn_MinimalApi_PizzaStore.EndpointDefinitions;

public class PizzaEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!")
            .WithName("Hello World").WithTags("Data");
        app.MapGet("/pizzas/{id}", GetPizza).WithTags("Pizza");
        app.MapGet("/pizzas", GetPizzas).WithTags("Pizza");
        app.MapPost("/pizzas", AddPizza).WithTags("Pizza");
        app.MapPut("/pizzas/{id}", UpdatePizza).WithTags("Pizza");
        app.MapDelete("/pizzas/{id}", DeletePizza).WithTags("Pizza");
    }

    public void DefineServices(IServiceCollection services)
    {
        //services.AddScoped<EstimationsService>();
        services.AddScoped<IPizzaService, PizzaService>();
    }

    private async Task<List<Pizza>> GetPizzas(IPizzaService service)
    {
        return await service.GetPizzas();
    }

    private async Task<IResult> GetPizza(IPizzaService service, int id)
    {
        return await service.GetPizza(id);
    }

    private async Task<IResult> AddPizza(IPizzaService service, Pizza pizza)
    {
        return await service.AddPizza(pizza);
    }

    private async Task<IResult> UpdatePizza(IPizzaService service, Pizza pizza, int id)
    {
        return await service.UpdatePizza(pizza, id);
    }

    private async Task<IResult> DeletePizza(IPizzaService service, int id)
    {
        return await service.DeletePizza(id);
    }
}