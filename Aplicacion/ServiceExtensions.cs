using Aplicacion.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public static class ServiceExtensions
    {
        public static void CapaAPlicacion(this IServiceCollection service)//
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());// registrar mapeo de biblioteca de clase.
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());//agregar sentencias de validacion en el mismo metodo.
            service.AddMediatR(Assembly.GetExecutingAssembly());//agregar el patro mediator
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ComportamientosValidaciones<,>));// ASIGNAR VALIDACIONES.
          
        }
    }
}
