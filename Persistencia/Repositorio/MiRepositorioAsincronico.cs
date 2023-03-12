using Aplicacion.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorio
{
    public class MyRepositorioAsincrono<T> : RepositoryBase<T>, IRepositorioAsincrono<T> where T : class
    {
        private readonly AppDbContext dbContext;
        public MyRepositorioAsincrono(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
