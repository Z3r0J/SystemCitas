using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessPacientes
    {
        SqlConnection _conexion;
        DataPacientes dataPacientes;
        public BusinessPacientes(SqlConnection connection)
        {
            _conexion = connection;
            dataPacientes = new DataPacientes(_conexion);
        }

        public DataTable BuscandoPacientes(int IdPacientes) {
            return dataPacientes.BuscarPacientes(IdPacientes);
        }
        public DataTable ListandoPacientes()
        {
            return dataPacientes.ListarPacientes();
        }
        public bool AgregandoPacientes(DataLayer.Models.Pacientes pacientes) {
            return dataPacientes.AgregarPacientes(pacientes);
        }
        public bool EditandoPacientes(DataLayer.Models.Pacientes pacientes)
        {
            return dataPacientes.EditarPacientes(pacientes);
        }
        public bool EliminandoPacientes(int IdPacientes) {
            return dataPacientes.EliminarPacientes(IdPacientes);
        }
    }
}
