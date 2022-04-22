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
    public partial class RegistroCitas : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessCitas citas;
        public RegistroCitas()
        {
            InitializeComponent();
            SqlConnection connection = new(connectionString);
            citas = new(connection);
        }

        private void RegistroCitas_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString()+ " |";

            LlenarCombo();
            LlenarComboDoctor();
        }

        public void LlenarComboDoctor()
        {
            var lista = citas.comboDoctor();
            foreach (var item in lista)
            {
                cmbDoctor.Items.Add(item);
            }
        }
        public void LlenarCombo() {
            var lista = citas.comboPacientes();
            foreach (var item in lista)
            {
                cmbPacientes.Items.Add(item);
            }
        }

        public void Agregar() {
            var SelectedDoctor = cmbDoctor.SelectedItem as ComboBoxItem;
            var SelectedPacientes = cmbPacientes.SelectedItem as ComboBoxItem;

            if (SelectedDoctor==null)
            {
                MessageBox.Show("Selecciona un doctor");
            }
            else if (SelectedPacientes==null)
            {
                MessageBox.Show("Selecciona un paciente");
            }
            else
            {
                Citas cit = new Citas() { IdDoctor = (int)SelectedDoctor.Value, IdPacientes = (int)SelectedPacientes.Value,Fecha_Citas=dateTimePicker1.Value, Diagnostico = " ", Estado = 'I' };
                if (citas.AgregarCitas(cit))
                {
                    MessageBox.Show("Agregado Correctamente");
                    this.Close();
                }
                else
                {

                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }
    }
}
