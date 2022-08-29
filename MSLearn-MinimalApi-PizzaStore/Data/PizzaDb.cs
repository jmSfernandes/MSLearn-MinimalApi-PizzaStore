using Microsoft.EntityFrameworkCore;
using MSLearn_MinimalApi_PizzaStore.Models;

namespace MSLearn_MinimalApi_PizzaStore.Data;

public class PizzaDb : DbContext
{
    public PizzaDb(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Pizza> Pizzas { get; set; } = null!;


    public async Task<List<Pizza>> GetPizzas()
    {
        return await Pizzas.ToListAsync();
    }

    public async Task<IResult> GetPizza(int id)
    {
        var pizza = await Pizzas.FindAsync(id);
        if (pizza == null)
            return Results.NotFound($"Entity with Id: {id} not found");
        return Results.Ok(pizza);
    }

    public async Task<IResult> CreatePizza(Pizza pizza)
    {
        await Pizzas.AddAsync(pizza);
        await this.SaveChangesAsync();
        return Results.Created($"/pizzas/{pizza.Id}", pizza);
    }

    public async Task<IResult> UpdatePizza(Pizza update, int id)
    {
        var verification = await Pizzas.FindAsync(id);
        if (verification == null)
            return Results.NotFound($"Entity with Id: {id} not found");
        verification.Name = update.Name;
        verification.Description = update.Description;
        var set = Pizzas.Update(verification);
        await this.SaveChangesAsync();

        return Results.Ok(verification);
    }

    public async Task<IResult> RemovePizza(int id)
    {
        var verification = await Pizzas.FindAsync(id);
        if (verification == null)
            return Results.NotFound($"Entity with Id: {id} not found");

        Pizzas.Remove(verification);
        await this.SaveChangesAsync();
        return Results.Ok();
    }
}