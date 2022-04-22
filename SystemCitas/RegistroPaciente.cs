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
    public partial class RegistroPaciente : Form
    {
        public bool Editar = false;
        public int Id = 0;

        BusinessPacientes pacientes;
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public RegistroPaciente()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);

            pacientes = new BusinessPacientes(connection);
        }

        private void RegistroPaciente_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString() + " |";
        }

        private void Limpiar()
        {
            txtNombrePaciente.Clear();
            txtApellidoPaciente.Clear();
            txtDireccion.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void Agregar()
        {
            Pacientes pac = new Pacientes()
            {
                Nombre = txtNombrePaciente.Text,
                Apellido = txtApellidoPaciente.Text,
                Direccion = txtDireccion.Text,
                Cedula = txtCedula.Text,
                NumeroDeTelefono = txtTelefono.Text,
                CorreoElectronico = txtCorreo.Text,
                FechaNacimiento = dateTimePicker2.Value
            };

            if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text))
            {
                MessageBox.Show("Nombre Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtApellidoPaciente.Text))
            {
                MessageBox.Show("Apellido Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Direccion Vacio");
            }
            else if (!txtCedula.MaskCompleted)
            {
                MessageBox.Show("Cedula Vacio");
            }
            else if (!txtTelefono.MaskCompleted)
            {
                MessageBox.Show("Telefono Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Correo Vacio");
            }
            else
            {

                if (pacientes.AgregandoPacientes(pac))
                {
                    MessageBox.Show("Agregado Correctamente");
                    Limpiar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Editarse()
        {
            Pacientes pac = new Pacientes()
            {
                IdPacientes = Id,
                Nombre = txtNombrePaciente.Text,
                Apellido = txtApellidoPaciente.Text,
                Direccion = txtDireccion.Text,
                Cedula = txtCedula.Text,
                NumeroDeTelefono = txtTelefono.Text,
                CorreoElectronico = txtCorreo.Text,
                FechaNacimiento = dateTimePicker2.Value,
                FechaIngreso = dateTimePicker1.Value
            };

            if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text))
            {
                MessageBox.Show("Nombre Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtApellidoPaciente.Text))
            {
                MessageBox.Show("Apellido Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Direccion Vacio");
            }
            else if (!txtCedula.MaskCompleted)
            {
                MessageBox.Show("Cedula Vacio");
            }
            else if (!txtTelefono.MaskCompleted)
            {
                MessageBox.Show("Telefono Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Correo Vacio");
            }
            else
            {

                if (pacientes.EditandoPacientes(pac))
                {
                    MessageBox.Show("Editado Correctamente");
                    Limpiar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Editar)
            {
                Editarse();
            }
            else
            {
                Agregar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
