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
                List<Pokemon> listaObtenida = negocio.listar();

                dgvPokemons.DataSource = listaObtenida;
                dgvPokemons.Columns[0].Visible = false;
                dgvPokemons.Columns[4].Visible = false;

                pbxPokemon.Load(listaObtenida[0].UrlImagen);
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
                Pokemon poke = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                pbxPokemon.Load(poke.UrlImagen);                
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
    }
}
