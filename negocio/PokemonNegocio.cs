using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using modelo;

namespace negocio
{
    public class PokemonNegocio
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
                //comando.CommandText = "select nombre, descripcion, Numero, UrlImagen from pokemons";
                comando.CommandText = "select nombre, p.descripcion, Numero, UrlImagen, t.Descripcion as tipo, d.Descripcion as debilidad from pokemons p, elementos t, elementos d where p.IdTipo = t.Id and p.IdDebilidad = d.Id";
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
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["debilidad"];

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

        public void agregar(Pokemon pokemon)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

                comando.CommandText = "Insert into POKEMONS Values (" + pokemon.Numero + ", '" + pokemon.Nombre + "', '" + pokemon.Descripcion + "', '" + pokemon.UrlImagen + "', @idTipo, @idDebilidad,null, 1)";
                comando.Parameters.AddWithValue("@idTipo", pokemon.Tipo.Id);
                comando.Parameters.AddWithValue("@idDebilidad", pokemon.Debilidad.Id);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
