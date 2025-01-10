using System;
using System.Collections.Generic;

namespace FullStack.Models;

public partial class Matricula
{
    public int Id { get; set; }

    public int AlumnoId { get; set; }

    public int AsignaturaId { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Asignatura Asignatura { get; set; } = null!;

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
