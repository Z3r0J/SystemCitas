using System;
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
    }
}
