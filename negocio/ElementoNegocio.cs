using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from elementos");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Id = datos.Lector.GetInt32(0);
                    lista.Add(aux);
                    
                    //lista.Add(new Elemento((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
