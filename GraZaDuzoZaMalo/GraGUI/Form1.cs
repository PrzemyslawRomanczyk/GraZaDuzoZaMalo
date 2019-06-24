using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelGry;

namespace GraGUI
{
    public partial class Form1 : Form
    {
        private Gra g;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNowaGra_Click(object sender, EventArgs e)
        {
            groupBoxLosuj.Visible = true;
            buttonNowaGra.Enabled = false;
        }

        private void buttonLosuj_Click(object sender, EventArgs e)
        {
            //ToDo: try-catch ...
            var a = int.Parse(textBoxOd.Text);
            var b = int.Parse(textBoxDo.Text);

            g = new Gra(a, b);

            buttonLosuj.Enabled = false;
            textBoxOd.Enabled = textBoxDo.Enabled = false;

            // odsłonić kolejne elemnty formularza
        }
    }
}
