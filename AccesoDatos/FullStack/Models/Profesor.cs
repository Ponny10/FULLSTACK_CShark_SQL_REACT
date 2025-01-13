using System;
using System.Collections.Generic;

namespace FullStack.Models;

public partial class Profesor
{
    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Nombre { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
