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
    public class BusineesUsers
    {
        DataUser dataUser;
        public BusineesUsers(SqlConnection connection)
        {
            dataUser = new DataUser(connection);
        }

        public bool Login(DataLayer.Models.User user) {
            return dataUser.LoginUsuario(user);
        }

        public DataTable ListandoUsuario() {
            return dataUser.ListarUsuarios();
        }

        public DataTable BuscandoUsuario(int IdUsuario) {
            return dataUser.BuscarUsuario(IdUsuario);
        }

        public bool EliminandoUsuario(int IdUsuario) {
            return dataUser.EliminarUsuarios(IdUsuario);
        }
        public bool AgregandoUsuario(DataLayer.Models.User user) {
            return dataUser.AgregarUsuarios(user);
        }

        public bool EditandoUsuario(DataLayer.Models.User user) {
            return dataUser.EditarUsuarios(user);
        }
    }
}
