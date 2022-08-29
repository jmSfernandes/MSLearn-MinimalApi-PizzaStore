using EndpointDefinitions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//if we want redirection to the correct port
//builder.Services.AddHttpsRedirection(options => options.HttpsPort = 9008);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title = "Pizza Store", Description = "Making the Pizzas you love",Version = "V1"});
});
builder.Services.AddAllEndpointDefinitions();

/* // if you want to filter the endpoints that are enabled;
 builder.Services.AddEndpointDefinitions(new Type[]
{
    typeof(Estimations), typeof(CsiLog)
});
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//redirection from http to https
//app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.Run();