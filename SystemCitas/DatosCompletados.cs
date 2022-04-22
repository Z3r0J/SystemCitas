using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCitas
{
    public partial class DatosCompletados : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessCitas citas;
        public DatosCompletados()
        {
            InitializeComponent();
            SqlConnection connection = new(connectionString);
            citas = new(connection);
        }

        private void LlenarData() {
            DataTable dt = citas.ListandoCitasCompletadas();
            dataPacientes.DataSource = dt;
        }


        private void DatosCitas_Load(object sender, EventArgs e)
        {
            LlenarData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
