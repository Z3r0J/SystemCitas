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
    public class DataUser
    {
        SqlConnection _conexion;
        public DataUser(SqlConnection connection)
        {
            _conexion = connection;
        }

        public bool LoginUsuario(User us) {
            SqlCommand cmd = new SqlCommand("SP_Login", _conexion) {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserName",us.UserName);
            cmd.Parameters.AddWithValue("@Password",us.Password);
            _conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                _conexion.Close();
                return true;
            }
            _conexion.Close();
            return false;

        }

        public DataTable ListarUsuarios()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_ListarUsuarios", _conexion)
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

        public DataTable BuscarUsuario(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BuscarUsuarios", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@BUSCAR",IdUsuario);
            _conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();

            _conexion.Close();

            return dt;
        }

        public bool AgregarUsuarios(User us) {
            SqlCommand cmd = new SqlCommand("SP_InsertarUsuarios", _conexion) { 
            CommandType=CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserName",us.UserName);
            cmd.Parameters.AddWithValue("@Password",us.Password);

            return ExecuteProc(cmd);
        }

        public bool EditarUsuarios(User us) {
            SqlCommand cmd = new SqlCommand("SP_EditarUsuario", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdUsuarios", us.IdUser);
            cmd.Parameters.AddWithValue("@UserName", us.UserName);
            cmd.Parameters.AddWithValue("@Password", us.Password);
            return ExecuteProc(cmd);
        }

        public bool EliminarUsuarios(int IdUser) {
            SqlCommand cmd = new SqlCommand("SP_EliminarUsuario", _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdUsuarios",IdUser);

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
