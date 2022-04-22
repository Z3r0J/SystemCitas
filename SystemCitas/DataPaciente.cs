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
using DataLayer.Models;

namespace SystemCitas
{
    public partial class DataPaciente : Form
    {
        public string ConnectionStrings = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessPacientes pacientes;
        public DataPaciente()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            pacientes = new BusinessPacientes(connection);
        }
        private void Eliminando() {
            if (dataPacientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataPacientes.CurrentRow.Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("¿Estas seguro que quieres eliminar el doctor", "Notificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (pacientes.EliminandoPacientes(id))
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
            else
            {
                MessageBox.Show("Seleccione un Pacientes");
            }
        }

        private void Editarse() {
            if (dataPacientes.SelectedRows.Count > 0)
            {
                RegistroPaciente registro = new RegistroPaciente();
                registro.Editar = true;
                registro.Id = Convert.ToInt32(dataPacientes.CurrentRow.Cells[0].Value);
                registro.txtNombrePaciente.Text = dataPacientes.CurrentRow.Cells[1].Value.ToString();
                registro.txtApellidoPaciente.Text = dataPacientes.CurrentRow.Cells[2].Value.ToString();
                registro.txtDireccion.Text = dataPacientes.CurrentRow.Cells[3].Value.ToString();
                registro.dateTimePicker2.Value = (DateTime)dataPacientes.CurrentRow.Cells[4].Value;
                registro.txtTelefono.Text = dataPacientes.CurrentRow.Cells[5].Value.ToString();
                registro.txtCorreo.Text = dataPacientes.CurrentRow.Cells[6].Value.ToString();
                registro.txtCedula.Text = dataPacientes.CurrentRow.Cells[7].Value.ToString();
                registro.dateTimePicker1.Value = (DateTime)dataPacientes.CurrentRow.Cells[8].Value;
                this.Hide();
                registro.ShowDialog();
                dataPacientes.ClearSelection();
                LlenarData();
                this.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un Pacientes");
            }
        }
        private void Agregar() {
            RegistroPaciente frm = new RegistroPaciente();
            frm.Editar = false;
            this.Hide();
            frm.ShowDialog();
            LlenarData();
            this.Show();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarDoctor.Text=="")
            {
                LlenarData();
            }
            else
            {
                int IdPacientes = Convert.ToInt32(txtBuscarDoctor.Text);
                DataTable dt = pacientes.BuscandoPacientes(IdPacientes);
                dataPacientes.DataSource = dt;
            }
        }
        private void LlenarData() {
            DataTable dt = pacientes.ListandoPacientes();

            dataPacientes.DataSource = dt;
        }
        private void DataPaciente_Load(object sender, EventArgs e)
        {
            LlenarData();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editarse();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminando();
        }
    }
}
