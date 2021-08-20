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
    public partial class frmPokemon : Form
    {
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevo.Numero = (int)numNumero.Value;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                nuevo.Tipo = (Elemento)cboTipo.SelectedItem;
                nuevo.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                negocio.agregar(nuevo);

                MessageBox.Show("Pokemon agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboDebilidad.DataSource = elementoNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
