﻿using System;
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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbEstado.Text = "Conectado | " + DateTime.Now.ToShortTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DoctorData frm = new DoctorData();
            frm.Show();
        }
    }
}
