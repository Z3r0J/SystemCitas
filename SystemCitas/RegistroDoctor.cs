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
    public partial class RegistroDoctor : Form
    {
        public RegistroDoctor()
        {
            InitializeComponent();
        }

        private void RegistroDoctor_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString() + " |";
        }
    }
}
