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
using System.IO;

namespace pokedex_form
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemons;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            cargar();
        }

        private void cargar()
        {
            //Cargar la grilla con pokemons desde la DB
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemons = negocio.listar();

                dgvPokemons.DataSource = listaPokemons;
                dgvPokemons.Columns[0].Visible = false;
                dgvPokemons.Columns[4].Visible = false;

                pbxPokemon.Load(listaPokemons[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvPokemons.SelectedRows.Count != 0)
                {
                    Pokemon poke = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                    pbxPokemon.Load(poke.UrlImagen);                
                }
            }
            catch (FileNotFoundException ex)
            {
                pbxPokemon.Load("https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png?w=640");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPokemon ventanaNuevo = new frmPokemon();
            ventanaNuevo.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            frmPokemon ventanaNuevo = new frmPokemon(seleccionado);
            ventanaNuevo.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            try
            {
                if(MessageBox.Show("De verdad lo querés eliminar? Se pierde eh...", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    negocio.eliminarFisico(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar... " + ex.ToString());
            }

        }

        private void btnEliminarDos_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            try
            {
                if (MessageBox.Show("De verdad lo querés eliminar? Se pierde eh...", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    negocio.eliminarLogico(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar... " + ex.ToString());
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtro();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtro();
        }

        private void filtro()
        {
            string filtro = txtFiltro.Text;

            if (filtro == "" || filtro.Length<=2)
            {
                dgvPokemons.DataSource = null;
                dgvPokemons.DataSource = listaPokemons;
            }
            else
            {
                List<Pokemon> listaFiltrada = listaPokemons.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                dgvPokemons.DataSource = null;
                dgvPokemons.DataSource = listaFiltrada;
            }

            dgvPokemons.Columns[0].Visible = false;
            dgvPokemons.Columns[4].Visible = false;
        }
    }
}
