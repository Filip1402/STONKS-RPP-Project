﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmPopisPrimki : Form
    {
        public FrmPopisPrimki()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }
    }
}