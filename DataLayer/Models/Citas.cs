using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Citas
    {
        public int IdCitas { get; set; }
        public int IdDoctor { get; set; }
        public int IdPacientes { get; set; }
        public DateTime Fecha_Citas { get; set; }
        public string Diagnostico { get; set; }
        public char Estado { get; set; }


    }
}
