using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpw.Entidades
{
    public class Autor
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public int AñoNacimiento { get; set; }
        public string Nacionalidad { get; set; }

        public List<Libro>? Libros { get; set; } // nav. obj.
    }
}
