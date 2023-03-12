using Aplicacion.Interfaces;
using Compartir.Servicio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartir
{
    public static class ExtencionServicio
    {
        public static void AddSharedInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<ITiempoServicio, TiempoServicio>();
        }
    }
}
