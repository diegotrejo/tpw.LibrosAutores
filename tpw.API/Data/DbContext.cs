using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tpw.Entidades;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<tpw.Entidades.Genero> Generos { get; set; } = default!;
        public DbSet<tpw.Entidades.Autor> Autores { get; set; } = default!;
        public DbSet<tpw.Entidades.Libro> Libros { get; set; } = default!;
    }
