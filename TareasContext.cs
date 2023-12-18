using curso_ef_platzi.Models;
using Microsoft.EntityFrameworkCore;

namespace curso_ef_platzi;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions options){}
}