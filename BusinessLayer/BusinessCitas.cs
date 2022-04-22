using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessCitas
    {
        DataCitas citas;
        public BusinessCitas(SqlConnection connection)
        {
            citas = new(connection);
        }

        public DataTable ListandoCitas()
        {
            return citas.ListadoCitas();
        }
        public DataTable ListandoCitasCompletadas()
        {
            return citas.ListadoCitasCompletadas();
        }

        public DataTable BuscarCitas(int IdCitas) {
            return citas.BuscarCitas(IdCitas);
        }

        public List<ComboBoxItem> comboPacientes() {
            return citas.comboPacientes();
        }
        public List<ComboBoxItem> comboDoctor()
        {
            return citas.comboDoctores();
        }
        public bool AgregarCitas(Citas cit) {
            return citas.AgregarCitas(cit);
        }
        public bool Diagnosticando(Citas cit)
        {
            return citas.Diagnosticar(cit);
        }
    }
}
