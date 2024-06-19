using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpw.Entidades
{
    public class AutorLibro
    {
        public int Id { get; set; }
        public int AutorId {get; set;}
        public Autor Autor {get; set;}

        public List<Libro> Libros {get; set;}
    }
}
