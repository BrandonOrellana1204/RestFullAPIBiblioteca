using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IRepositorioAsincrono<T> : IRepositoryBase<T> where T : class
    {

    }
    public interface ILeerRepositorioAsincrono<T> : IReadRepositoryBase<T> where T : class
    {

    }
}
