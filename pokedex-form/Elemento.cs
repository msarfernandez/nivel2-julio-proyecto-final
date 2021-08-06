using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_form
{
    class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Elemento(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
