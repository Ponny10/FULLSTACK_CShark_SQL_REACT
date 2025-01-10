using System;
using System.Collections.Generic;

namespace FullStack.Models;

public partial class Asignatura
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public string? Profesor { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public virtual Profesor? ProfesorNavigation { get; set; }
}
