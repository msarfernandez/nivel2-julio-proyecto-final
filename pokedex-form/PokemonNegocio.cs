using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace pokedex_form
{
    class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select nombre, descripcion, Numero, UrlImagen from pokemons";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Nombre = lector.GetString(0);
                    aux.Descripcion = (string)lector["descripcion"];
                    aux.Numero = lector.GetInt32(2);
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
