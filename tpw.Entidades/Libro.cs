using System.ComponentModel.DataAnnotations;

namespace tpw.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen {  get; set; }
        public int AñoPublicacion { get; set; }
        public string Isbn { get; set; }
        public int NroPaginas { get; set; }

        public int? GeneroId { get; set; }  // FK generos
        public Genero? Genero { get; set; }  // navigation object

        public int? AutorId { get; set; } // FK autores
        public Autor? Autor { get; set; } // nav. obj.
    }
}
