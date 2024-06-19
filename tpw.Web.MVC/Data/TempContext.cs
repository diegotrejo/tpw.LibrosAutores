using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tpw.Entidades;

    public class TempContext : DbContext
    {
        public TempContext (DbContextOptions<TempContext> options)
            : base(options)
        {
        }

        public DbSet<tpw.Entidades.Autor> Autor { get; set; } = default!;

public DbSet<tpw.Entidades.Genero> Genero { get; set; } = default!;

public DbSet<tpw.Entidades.Libro> Libro { get; set; } = default!;
    }
