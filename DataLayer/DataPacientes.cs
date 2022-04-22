using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataPacientes
    {
        SqlConnection _conexion;
        public DataPacientes(SqlConnection connection)
        {
            _conexion = connection; 
        }

        public DataTable BuscarPacientes(int IdPacientes) {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarPacientes", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@BUSCAR", IdPacientes);
            _conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();

            _conexion.Close();

            return dt;
        }

        public DataTable ListarPacientes()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_ListarPacientes", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            _conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();

            _conexion.Close();

            return dt;
        }
        public bool AgregarPacientes(Models.Pacientes pacientes)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarPacientes", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Nombre", pacientes.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", pacientes.Apellido);
            cmd.Parameters.AddWithValue("@Direccion", pacientes.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", pacientes.FechaNacimiento);
            cmd.Parameters.AddWithValue("@NumeroDeTelefono", pacientes.NumeroDeTelefono);
            cmd.Parameters.AddWithValue("@CorreoElectronico", pacientes.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Cedula", pacientes.Cedula);
            cmd.Parameters.AddWithValue("@FechaIngreso", pacientes.FechaIngreso);
            return ExecuteProc(cmd);
        }

        public bool EditarPacientes(Models.Pacientes pacientes)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarPacientes", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdPacientes", pacientes.IdPacientes);
            cmd.Parameters.AddWithValue("@Nombre", pacientes.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", pacientes.Apellido);
            cmd.Parameters.AddWithValue("@Direccion", pacientes.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", pacientes.FechaNacimiento);
            cmd.Parameters.AddWithValue("@NumeroDeTelefono", pacientes.NumeroDeTelefono);
            cmd.Parameters.AddWithValue("@CorreoElectronico", pacientes.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Cedula", pacientes.Cedula);
            cmd.Parameters.AddWithValue("@FechaIngreso", pacientes.FechaIngreso);
            return ExecuteProc(cmd);
        }

        public bool EliminarPacientes(int IdPacientes)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarPacientes", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdPacientes", IdPacientes);

            return ExecuteProc(cmd);
        }


        public bool ExecuteProc(SqlCommand cmd)
        {
            try
            {
                _conexion.Open();
                cmd.ExecuteNonQuery();
                _conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                _conexion.Close();
                return false;
            }
        }
    }
}
