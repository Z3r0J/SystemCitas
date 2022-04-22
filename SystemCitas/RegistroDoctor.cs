using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Models;
using System.Data.SqlClient;

namespace SystemCitas
{
    public partial class RegistroDoctor : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessDoctor doctor;
        public bool Editar = false;
        public int Id = 0;
        public RegistroDoctor()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);

            doctor = new BusinessDoctor(connection);
        }

        private void RegistroDoctor_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString() + " |";
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

        private void Editarse()
        {
            Doctor doc = new Doctor()
            {
                IdDoctor=Id,
                Nombre = txtNombreDoctor.Text,
                Apellido = txtApellidoDoctor.Text,
                Direccion = txtDireccion.Text,
                Cedula = txtCedula.Text,
                NumeroDeTelefono = txtTelefono.Text,
                CorreoElectronico = txtCorreo.Text,
                FechaNacimiento = dateTimePicker2.Value
            };

            if (string.IsNullOrWhiteSpace(txtNombreDoctor.Text))
            {
                MessageBox.Show("Nombre Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtApellidoDoctor.Text))
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

                if (doctor.EditandoDoctor(doc))
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

        private void Limpiar() {
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtDireccion.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Agregar() {
            Doctor doc = new Doctor() {
                Nombre = txtNombreDoctor.Text,
                Apellido = txtApellidoDoctor.Text,
                Direccion = txtDireccion.Text,
                Cedula = txtCedula.Text,
                NumeroDeTelefono = txtTelefono.Text,
                CorreoElectronico = txtCorreo.Text,
                FechaNacimiento = dateTimePicker2.Value
            };

            if (string.IsNullOrWhiteSpace(txtNombreDoctor.Text))
            {
                MessageBox.Show("Nombre Vacio");
            }
            else if (string.IsNullOrWhiteSpace(txtApellidoDoctor.Text)) {
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

                if (doctor.AgregandoDoctor(doc))
                {
                    MessageBox.Show("Agregado Correctamente");
                    Limpiar();
                    this.Close();
                }
                else {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
