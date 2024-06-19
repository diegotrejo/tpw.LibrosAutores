using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpw.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Libro>? Libros { get; set; }
    }
}
