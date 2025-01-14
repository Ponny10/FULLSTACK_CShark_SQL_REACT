using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Context;
using FullStack.Models;

namespace FullStack.Operaciones
{
    public class ProfesorDAO
    {
        private CursoFullstackContext context = new CursoFullstackContext();

        // Lógica de logueo para profesor
        public Profesor login(string usuario, string password)
        {
            // Verificar que exista el profesor a loguear
            var exiteProfesor = context.Profesors.Where(p => p.Usuario == usuario && p.Pass == password).FirstOrDefault();
            return exiteProfesor;
        }
    }
}
