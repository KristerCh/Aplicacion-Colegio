using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
    }
}
