using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataCitas
    {
        SqlConnection _conexion;
        public DataCitas(SqlConnection connection)
        {
            _conexion = connection;
        }

        public DataTable ListadoCitas()
        {
            SqlCommand comando = new SqlCommand("SP_Listar_Citas", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();

            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public DataTable ListadoCitasCompletadas()
        {
            SqlCommand comando = new SqlCommand("SP_Listar_Citas_Completadas", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            _conexion.Open();

            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }

        public List<ComboBoxItem> comboPacientes(){
            SqlCommand comando = new SqlCommand("SP_ComboBoxPacientes", _conexion);
             comando.CommandType = CommandType.StoredProcedure;
            List<ComboBoxItem> Lista = new List<ComboBoxItem>();
            _conexion.Open();
            SqlDataReader Datos = comando.ExecuteReader();
            while (Datos.Read())
            {
                Lista.Add(new ComboBoxItem {
                Value=Datos.GetInt32(0),
                Text=Datos.GetString(1)
                });
            }
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();
            return Lista;
        }


        public List<ComboBoxItem> comboDoctores()
        {
            SqlCommand comando = new SqlCommand("SP_ComboBoxDoctor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            List<ComboBoxItem> Lista = new List<ComboBoxItem>();
            _conexion.Open();
            SqlDataReader Datos = comando.ExecuteReader();
            while (Datos.Read())
            {
                Lista.Add(new ComboBoxItem
                {
                    Value = Datos.GetInt32(0),
                    Text = Datos.GetString(1)
                });
            }
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();
            return Lista;
        }
        public DataTable BuscarCitas(int IdCitas) {
            SqlCommand comando = new SqlCommand("SP_BuscarCitas", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCitas",IdCitas);
            _conexion.Open();

            DataTable ListarFilas = new DataTable();
            SqlDataReader Datos = comando.ExecuteReader();
            ListarFilas.Load(Datos);
            Datos.Close();
            Datos.Dispose();
            _conexion.Close();

            return ListarFilas;
        }
        public bool AgregarCitas(Citas citas)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarCitas", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdDoctor", citas.IdDoctor);
            cmd.Parameters.AddWithValue("@IdPacientes", citas.IdPacientes);
            cmd.Parameters.AddWithValue("@FechaCitas", citas.Fecha_Citas);
            cmd.Parameters.AddWithValue("@Diagnostico", citas.Diagnostico);
            cmd.Parameters.AddWithValue("@Estado", citas.Estado);
            
            return ExecuteProc(cmd);
        }

        public bool Diagnosticar(Citas citas)
        {
            SqlCommand cmd = new SqlCommand("SP_CompletarCitas", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdCitas", citas.IdCitas);
            cmd.Parameters.AddWithValue("@Diagnostico", citas.Diagnostico);
            cmd.Parameters.AddWithValue("@Estado", citas.Estado);

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
