using DataLayer;
using System;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BusinessDoctor
    {
        private DataDoctor dataDoctor;
        public BusinessDoctor(SqlConnection connection)
        {
            dataDoctor = new DataDoctor(connection);
        }
    }
}
