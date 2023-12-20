using curso_ef_platzi;
using curso_ef_platzi.Models;
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

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(x => x.Categoria).Select(x => new{ x.Titulo, x.Descripcion, x.Categoria, x.PrioridadTarea })); //.Include(x => x.Categoria).ToList());
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now.ToUniversalTime();
    await dbContext.AddAsync(tarea);
    var filasModificadas = await dbContext.SaveChangesAsync();

    return Results.Ok($"Se han modificado {filasModificadas} filas");
});

app.Run();