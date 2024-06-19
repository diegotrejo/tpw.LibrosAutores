using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpw.Entidades
{
    public class LibroAutor
    {
        public int Id { get; set; }

        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        public List<Autor> Autores { get; set; }
    }
}
