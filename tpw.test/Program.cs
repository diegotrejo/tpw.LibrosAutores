using tpw.Entidades;
using tpw.APIConsumer;

namespace tpw.test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var apiUrl = "https://localhost:7004/api";

            //// GENEROS
            //var nuevoGenero = new Genero { Descripcion = "LITERATURA CLÀSICA" };

            //nuevoGenero = Crud<Genero>.Create(apiUrl + "/generos", nuevoGenero);
            //Console.WriteLine( nuevoGenero.Id );

            //// AUTORES
            //var nuevoAutor = new Autor
            //{
            //    Nombre = "pepito",
            //    Nacionalidad = "EC",
            //    AñoNacimiento = 1999,
            //    Id = 0
            //};

            //nuevoAutor = Crud<Autor>.Create(apiUrl + "/autores", nuevoAutor);
            //Console.WriteLine( nuevoAutor.Id );

            // LIBROS
            //var nuevoLibro = new Libro
            //{
            //    Id = 0,
            //    AutorId = 5,
            //    AñoPublicacion = 2023,
            //    GeneroId = 5,
            //    NroPaginas = 89,
            //    Isbn = "u989090123",
            //    Titulo = "EL PEREGRINO",
            //    Resumen = "este es un resumen"
            //};
            //nuevoLibro = Crud<Libro>.Create(apiUrl + "/libros", nuevoLibro);
            //Console.WriteLine( nuevoLibro.Id );

            //var libros = Crud<Libro>.Read_All(apiUrl + "/libros");
            //foreach (var libro in libros)
            //{
            //    Console.WriteLine("---------------------");
            //    Console.WriteLine(libro.Id);
            //    Console.WriteLine(libro.Titulo);
            //}

            var unLibro = Crud<Libro>.Read_ById(apiUrl + "/libros", 4);
            Console.WriteLine("---------------------");
            Console.WriteLine(unLibro.Id);
            Console.WriteLine(unLibro.Titulo);
            Console.WriteLine(unLibro.Resumen);

            unLibro.Titulo = "EL PEREGRINO DE COMPOSTELA";
            unLibro.Resumen = "Contenido para reflexionar";
            Crud<Libro>.Update(apiUrl + "/libros", 4, unLibro);

            unLibro = Crud<Libro>.Read_ById(apiUrl + "/libros", 4);
            Console.WriteLine("---------------------");
            Console.WriteLine(unLibro.Id);
            Console.WriteLine(unLibro.Titulo);
            Console.WriteLine(unLibro.Resumen);


            Crud<Libro>.Delete(apiUrl + "/libros", 4);
            Crud<Libro>.Read_ById(apiUrl + "/libros", 4);

            // ---------------------
            Console.ReadKey();
        }
    }
}
