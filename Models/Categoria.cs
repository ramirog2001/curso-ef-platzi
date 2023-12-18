using System.ComponentModel.DataAnnotations;

namespace curso_ef_platzi.Models;
public class Categoria
{
    [Key]
    public Guid CategoriaID {get; set;}
    [Required]
    [MaxLength(150)]
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public ICollection<Tarea>? Tareas { get; set; }
}
