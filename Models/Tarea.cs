﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curso_ef_platzi.Models;
public class Tarea
{
    [Key]
    public Guid TareaID { get; set; }
    [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Categoria? Categoria { get; set; }
    [NotMapped]
    public string Resumen { get => Titulo + " - " + Descripcion; }
}
public enum Prioridad
{
    Baja,
    Media,
    Alta
}