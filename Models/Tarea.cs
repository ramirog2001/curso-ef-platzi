﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curso_ef_platzi.Models;

public class Tarea
{
    public Guid TareaId { get; set; }
    public Guid CategoriaId { get; set; }
    public required string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Categoria? Categoria { get; set; }
    public string Resumen => Titulo + " - " + Descripcion;
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}
