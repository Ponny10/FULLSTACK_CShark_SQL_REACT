using System;
using System.Collections.Generic;

namespace FullStack.Models;

public partial class Calificacion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public float Nota { get; set; }

    public int Porcentaje { get; set; }

    public int MatriculaId { get; set; }

    public virtual Matricula Matricula { get; set; } = null!;
}
