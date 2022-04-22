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
    public partial class FrmLogin : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusineesUsers users;
        public FrmLogin()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);
            users = new BusineesUsers(connection);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Acceder();
        }

        private void Acceder() {
            DataLayer.Models.User us = new DataLayer.Models.User() { UserName=txtUserName.Text,Password=textBox1.Text };

            if (users.Login(us))
            {
                MessageBox.Show("Logueado Correctamente");
                frmMenuPrincipal frm = new frmMenuPrincipal();
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else {
                MessageBox.Show("Error");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegistro frm = new frmRegistro();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
