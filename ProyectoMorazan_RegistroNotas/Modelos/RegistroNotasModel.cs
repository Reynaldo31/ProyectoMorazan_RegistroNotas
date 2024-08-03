using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.Modelos
{
    public class RegistroNotasModel
    {
        public string NombreEstudiante { get; set; }
        public string NombreMateria { get; set; }
        public int NotaExamen1 { get; set; }
        public int NotaExamen2 { get; set; }
        public int NotaExamen3 { get; set; }
        public int NotaExamen4 { get; set; }
        public int NotaAcumulativo { get; set; }
        public int NotaFinal { get; set; }
        public string FechaHoraCalculo { get; set; }
    }
}
