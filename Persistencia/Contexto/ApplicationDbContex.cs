using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Interfaces;
using Dominio.Comun;
using Dominio.Entidades;

namespace Persistencia.Contexto
{
    public class AppDbContext : DbContext
    {
        private readonly ITiempoServicio _datetime;
        public AppDbContext(DbContextOptions<AppDbContext> options, ITiempoServicio datetime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _datetime = datetime;
        }
        public DbSet<Libro> Libros { get; set; }// agregar referencia al dominio en <libro>

        public override Task<int> SaveChangesAsync(CancellationToken cancellationTaken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Auditoria>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Creado = _datetime.FechaActual;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UltimaModificacion = _datetime.FechaActual;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationTaken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
