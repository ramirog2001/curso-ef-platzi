using curso_ef_platzi.Models;
using Microsoft.EntityFrameworkCore;

namespace curso_ef_platzi;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    
    public TareasContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new()
        {
            new(){CategoriaID = Guid.Parse("771fe61e-10b0-4174-8e42-bf5296b5e749"), Nombre = "Pendientes", Descripcion = "Tareas que todavía no se realizaron, se planean realizar en un futuro.", Peso = 3},
            new(){CategoriaID = Guid.Parse("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"), Nombre = "Terminadas", Descripcion = "Tareas que ya finalizaron.", Peso = 2},
            new(){CategoriaID = Guid.Parse("f046722f-c17e-47c5-aa34-c07f1578f9d9"), Nombre = "Descartadas", Descripcion = "Tareas que todavía no se realizaron, y no se planean realizar en un futuro.", Peso = 1}
        };
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaID);
            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new()
        {
            new(){Titulo = "Lavar ropa", CategoriaId = categoriasInit.First(x => x.Nombre == "Pendientes").CategoriaID, Descripcion = "Hay que lavar la ropa.", FechaCreacion = DateTime.Now.ToUniversalTime(), PrioridadTarea = Prioridad.Baja, TareaId = Guid.Parse("8c138467-c085-4333-8a89-d637e071757a")},
            new(){Titulo = "Pagar impuestos", CategoriaId = categoriasInit.First(x => x.Nombre == "Terminadas").CategoriaID, Descripcion = "Desde la pagina oficial.", FechaCreacion = DateTime.Now.ToUniversalTime(), PrioridadTarea = Prioridad.Baja, TareaId = Guid.Parse("8c138467-c085-4333-8a89-d637e071757b")},
            new(){Titulo = "Hacer deporte", CategoriaId = categoriasInit.First(x => x.Nombre == "Pendientes").CategoriaID, Descripcion = "Acordarse de llevar ropa.", FechaCreacion = DateTime.Now.ToUniversalTime(), PrioridadTarea = Prioridad.Baja, TareaId = Guid.Parse("8c138467-c085-4333-8a89-d637e071757c")}
        };
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareasInit);
        });
        base.OnModelCreating(modelBuilder);
    }
}