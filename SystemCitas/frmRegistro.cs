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
    public partial class frmRegistro : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusineesUsers users;
        public bool Editar = false;
        public int Id = 0;
        public frmRegistro()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);
            users = new BusineesUsers(connection);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Editar)
            {
                Editarse();
            }
            else
            {
                Registrar();
            }
        }
        private void Editarse(){
            DataLayer.Models.User us = new DataLayer.Models.User() { IdUser=Id,UserName = txtUserName.Text, Password = textBox1.Text };

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Inserta un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Inserta una Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text != textBox1.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (users.EditandoUsuario(us))
                {
                    MessageBox.Show("Editado Correctamente");
                    Limpiar();
                    this.Close();
                }
            }

        }

        private void Limpiar() {
            txtUserName.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Registrar() {
            DataLayer.Models.User us = new DataLayer.Models.User() { UserName = txtUserName.Text, Password = textBox1.Text };

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Inserta un usuario","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Inserta una Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text!=textBox1.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (users.AgregandoUsuario(us))
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

        private void btnCacelarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
