using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tpw.Entidades;
using tpw.APIConsumer;

namespace tpw.Web.MVC.Controllers
{
    public class LibrosController : Controller
    {
        private string apiUrl = "https://localhost:7004/api/libros";

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var data = Crud<Libro>.Read_All(apiUrl);
            return View(data);
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = Crud<Libro>.Read_ById(apiUrl, id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        private void LeerListasDatos()
        {
            var autores = Crud<Autor>.Read_All(apiUrl.Replace("libros", "autores"));
            var generos = Crud<Genero>.Read_All(apiUrl.Replace("libros", "generos"));

            ViewData["AutorId"] = new SelectList(autores, "Id", "Nombre");
            ViewData["GeneroId"] = new SelectList(generos, "Id", "Descripcion");
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            LeerListasDatos();
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Resumen,AñoPublicacion,Isbn,NroPaginas,GeneroId,AutorId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                Crud<Libro>.Create(apiUrl, libro);
                return RedirectToAction(nameof(Index));
            }
            LeerListasDatos();

            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = Crud<Libro>.Read_ById(apiUrl, id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            LeerListasDatos();

            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Resumen,AñoPublicacion,Isbn,NroPaginas,GeneroId,AutorId")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Libro>.Update(apiUrl, id, libro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            LeerListasDatos();

            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = Crud<Libro>.Read_ById(apiUrl, id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = Crud<Libro>.Read_ById(apiUrl, id);
            if (libro != null)
            {
                Crud<Libro>.Delete(apiUrl, id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return Crud<Libro>.Read_ById(apiUrl, id) != null;
        }
    }
}
