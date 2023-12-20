using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace curso_ef_platzi.Models;
public class Categoria
{
    public Guid CategoriaID {get; set;}
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Peso { get; set; }
    // [JsonIgnore]
    public ICollection<Tarea>? Tareas { get; set; }
}
