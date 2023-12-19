using System.ComponentModel.DataAnnotations;

namespace curso_ef_platzi.Models;
public class Categoria
{
    public Guid CategoriaID {get; set;}
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Peso { get; set; }
    public ICollection<Tarea>? Tareas { get; set; }
}
