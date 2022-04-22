using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCitas
{
    public partial class RegistroCitas : Form
    {
        public RegistroCitas()
        {
            InitializeComponent();
        }

        private void RegistroCitas_Load(object sender, EventArgs e)
        {
            lbFecha.Text = "| " + DateTime.Now.ToLongDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString();
           
        }
    }
}
