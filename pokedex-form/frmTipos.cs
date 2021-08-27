using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelo;
using negocio;

namespace pokedex_form
{
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
        }

        private void frmTipos_Load(object sender, EventArgs e)
        {
            ElementoNegocio negocio = new ElementoNegocio();
            dgvTipos.DataSource = negocio.listar();
        }
    }
}
