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
    public partial class DatosUsuarios : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusineesUsers users;
        public DatosUsuarios()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            users = new BusineesUsers(sqlConnection);
        }

        private void LlenarData()
        {
            DataTable dt = users.ListandoUsuario();
            dataUsuarios.DataSource = dt;
        }

        private void Buscar() {
            if (txtBuscarUsuarios.Text=="")
            {
                LlenarData();
            }
            else
            {
                int Id = Convert.ToInt32(txtBuscarUsuarios.Text);
                DataTable dt = users.BuscandoUsuario(Id);
                dataUsuarios.DataSource = dt;
            }
        }

        public void Eliminar()
        {
            if (dataUsuarios.SelectedRows.Count>0)
            {
                int Id = Convert.ToInt32(dataUsuarios.CurrentRow.Cells[0].Value.ToString());

                if (users.EliminandoUsuario(Id))
                {
                    MessageBox.Show("Eliminado Correctamente");
                    LlenarData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario");
            }
        }

        private void Editar() {
            if (dataUsuarios.SelectedRows.Count>0)
            {
                frmRegistro frm = new frmRegistro();
                frm.Editar = true;
                frm.Id = Convert.ToInt32(dataUsuarios.CurrentRow.Cells[0].Value.ToString());
                frm.txtUserName.Text = dataUsuarios.CurrentRow.Cells[1].Value.ToString();
                frm.textBox1.Text = dataUsuarios.CurrentRow.Cells[2].Value.ToString();
                frm.textBox2.Text = dataUsuarios.CurrentRow.Cells[2].Value.ToString();

                this.Hide();
                frm.ShowDialog();
                LlenarData();
                this.Show();

            }
            else
            {
                MessageBox.Show("Selecciona un usuario");
            }
        }
        private void Agregar() {
            frmRegistro frm = new frmRegistro();
            frm.Editar = false;
            this.Hide();
            frm.ShowDialog();
            LlenarData();
            this.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void DatosUsuarios_Load(object sender, EventArgs e)
        {
            LlenarData();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
