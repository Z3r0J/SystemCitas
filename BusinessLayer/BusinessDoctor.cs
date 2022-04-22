using DataLayer;
using System;
using System.Data;
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

        public DataTable ListandoDoctor() {
            return dataDoctor.ListarDoctor();
        }

        public DataTable BuscarDoctor(int IdDoctor) {
            return dataDoctor.BuscarDoctor(IdDoctor);
        }

        public bool AgregandoDoctor(DataLayer.Models.Doctor doctor) {

            return dataDoctor.AgregarDoctor(doctor);
        }

        public bool EditandoDoctor(DataLayer.Models.Doctor doctor) {
            return dataDoctor.EditarDoctor(doctor);
        }

        public bool EliminandoDoctor(DataLayer.Models.Doctor doctor) {
            return dataDoctor.EliminarDoctor(doctor);
        }
    }
}
