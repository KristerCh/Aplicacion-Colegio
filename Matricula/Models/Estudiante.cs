using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }  
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
