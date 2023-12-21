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
    return Results.Ok(dbContext.Tareas.Include(x => x.Categoria).Select(x => new{ x.TareaId ,x.Titulo, x.Descripcion, x.Categoria, x.PrioridadTarea })); //.Include(x => x.Categoria).ToList());
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now.ToUniversalTime();
    await dbContext.AddAsync(tarea);
    var filasModificadas = await dbContext.SaveChangesAsync();

    return Results.Ok($"Se han modificado {filasModificadas} filas");
});

app.MapPut("/api/tareas/{idTarea}",
    async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid idTarea) =>
    {
        var tareaOld = dbContext.Tareas.Find(idTarea);
        
        if (tareaOld is null)
            return Results.BadRequest("No se encontro una tarea con el id requerido");

        tarea.TareaId = tareaOld.TareaId;
        tarea.FechaCreacion = tareaOld.FechaCreacion;
        var props = tareaOld.GetType().GetProperties();
        foreach (var prop in tareaOld.GetType().GetProperties())
        {
            if(prop.CanWrite)
                prop.SetValue(tareaOld, prop.GetValue(tarea));
        }

        var rowsChanged = await dbContext.SaveChangesAsync();

        return Results.Ok($"Se han cambiado {rowsChanged} filas");
    });

app.Run();