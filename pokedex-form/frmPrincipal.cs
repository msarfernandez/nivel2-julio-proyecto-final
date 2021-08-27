using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokedex_form
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menPokemons_Click(object sender, EventArgs e)
        {
            bool existeVentana = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is Form1)
                    existeVentana = true;
            }
            if (!existeVentana)
            {
                Form1 ventana = new Form1();
                ventana.MdiParent = this;
                ventana.Show();
            }            
        }

        private void menTipos_Click(object sender, EventArgs e)
        {
            frmTipos tipos = new frmTipos();
            tipos.MdiParent = this;
            tipos.Show();
            //menTipos.Enabled = false;
        }
    }
}
