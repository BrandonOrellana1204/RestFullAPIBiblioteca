using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistencia.Contexto;
using Persistencia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class ServicioExtencion
    {
        public static void AddPersitenceInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ));

            #region Repositorios
            service.AddTransient(typeof(IRepositorioAsincrono<>), typeof(MyRepositorioAsincrono<>));//inyeccion dependencia
            #endregion

        }
    }
}
