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
    public class AutoresController : Controller
    {
        private string apiUrl = "https://localhost:7004/api/autores";

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            var data = Crud<Autor>.Read_All(apiUrl);
            return View(data);
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = Crud<Autor>.Read_ById(apiUrl, id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,AñoNacimiento,Nacionalidad")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                Crud<Autor>.Create(apiUrl, autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = Crud<Autor>.Read_ById(apiUrl, id.Value);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,AñoNacimiento,Nacionalidad")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Autor>.Update( apiUrl, id, autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
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
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = Crud<Autor>.Read_ById(apiUrl, id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = Crud<Autor>.Read_ById(apiUrl, id);
            if (autor != null)
            {
                Crud<Autor>.Delete(apiUrl, id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            var data = Crud<Autor>.Read_ById(apiUrl, id);
            return data != null;
        }
    }
}
