using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataDoctor
    {
        private SqlConnection _conexion;
        public DataDoctor(SqlConnection connection)
        {
            _conexion = connection;
        }

        public DataTable ListarDoctor() {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_ListarDoctor", _conexion)
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

        public DataTable BuscarDoctor(int IdDoctor)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarDoctor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@BUSCAR",IdDoctor);
            _conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();

            _conexion.Close();

            return dt;
        }

        public bool AgregarDoctor(Models.Doctor doc) {
            SqlCommand cmd = new SqlCommand("SP_InsertarDoctor", _conexion) {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Nombre",doc.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", doc.Apellido);
            cmd.Parameters.AddWithValue("@Direccion", doc.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", doc.FechaNacimiento);
            cmd.Parameters.AddWithValue("@NumeroDeTelefono", doc.NumeroDeTelefono);
            cmd.Parameters.AddWithValue("@CorreoElectronico", doc.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Cedula",doc.Cedula);

            return ExecuteProc(cmd);
        }

        public bool EditarDoctor(Models.Doctor doc) {
            SqlCommand cmd = new SqlCommand("SP_EditarDoctor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdDoctor",doc.IdDoctor);
            cmd.Parameters.AddWithValue("@Nombre", doc.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", doc.Apellido);
            cmd.Parameters.AddWithValue("@Direccion", doc.Direccion);
            cmd.Parameters.AddWithValue("@FechaNacimiento", doc.FechaNacimiento);
            cmd.Parameters.AddWithValue("@NumeroDeTelefono", doc.NumeroDeTelefono);
            cmd.Parameters.AddWithValue("@CorreoElectronico", doc.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Cedula", doc.Cedula);

            return ExecuteProc(cmd);
        }

        public bool EliminarDoctor(Models.Doctor doc)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarDoctor", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdDoctor", doc.IdDoctor);

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
