using curso_ef_platzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("connectionTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/isup", async ([FromServices] TareasContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos creada: " + dbContext.Database.IsInMemory());
});

app.Run();
