using BusinessLayer;
using DataLayer.Models;
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
    public partial class DoctorData : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessDoctor doctor;
        public DoctorData()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);

            doctor = new BusinessDoctor(connection);
        }

        private void DoctorData_Load(object sender, EventArgs e)
        {
            LlenarData();
        }
        private void LlenarData() {

            DataTable dt = doctor.ListandoDoctor();
            dataDotores.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminandoDoctor();
        }

        private void EliminandoDoctor()
        {
            if (dataDotores.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dataDotores.CurrentRow.Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("¿Estas seguro que quieres eliminar el doctor","Notificacion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (doctor.EliminandoDoctor(id))
                    {
                        MessageBox.Show("Eliminado correctamente");
                        LlenarData();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDoctor();
        }

        private void BuscarDoctor() {
            if (txtBuscarDoctor.Text == "")
            {
                LlenarData();
            }
            int IdDoctor = Convert.ToInt32(txtBuscarDoctor.Text);
            dataDotores.DataSource = doctor.BuscarDoctor(IdDoctor);
        }
    }


}
