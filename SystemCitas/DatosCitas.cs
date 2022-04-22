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
    public partial class DatosCitas : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessCitas citas;
        public DatosCitas()
        {
            InitializeComponent();
            SqlConnection connection = new(connectionString);
            citas = new(connection);
        }

        private void LlenarData() {
            DataTable dt = citas.ListandoCitas();
            dataPacientes.DataSource = dt;
        }

        private void Buscar() {
            if (txtBuscarDoctor.Text=="")
            {
                LlenarData();
            }
            else
            {
                int IdCitas = Convert.ToInt32(txtBuscarDoctor.Text);
                DataTable dt = citas.BuscarCitas(IdCitas);
                dataPacientes.DataSource = dt;
            }
        
        }

        private void DatosCitas_Load(object sender, EventArgs e)
        {
            LlenarData();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (dataPacientes.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dataPacientes.CurrentRow.Cells[0].Value.ToString());

                FrmDiagnostico diag = new();
                diag.IdCitas = id;
                diag.ShowDialog();
            }
        }
    }
}
