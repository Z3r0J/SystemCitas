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
    public partial class FrmDiagnostico : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        BusinessCitas citas;
        public int IdCitas = 0;
        public FrmDiagnostico()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);
            citas = new(connection);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Diagnosticar();
        }

        private void Diagnosticar()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Escribe un diagnostico");
            }
            else
            {
                var cit = new Citas() { IdCitas=IdCitas,Diagnostico=textBox1.Text,Estado='C'};

                if (citas.Diagnosticando(cit))
                {
                    MessageBox.Show("Diagnosticado Correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
