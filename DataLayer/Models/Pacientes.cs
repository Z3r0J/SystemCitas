using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Pacientes
    {
        public int IdPacientes { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroDeTelefono { get; set; }
        public string Cedula { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
