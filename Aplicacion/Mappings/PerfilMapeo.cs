using Aplicacion.DTOs;
using Aplicacion.Feautres.Libros.Comandos.CrearLibro;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Mappings
{
    public class PerfilMapeo : Profile
    {
        public PerfilMapeo()
        {
            #region Commands
            CreateMap<CrearLibro, Libro>();
            #endregion


            #region DTOs
            CreateMap<Libro, librodto>();
            #endregion



        }
    }
}
