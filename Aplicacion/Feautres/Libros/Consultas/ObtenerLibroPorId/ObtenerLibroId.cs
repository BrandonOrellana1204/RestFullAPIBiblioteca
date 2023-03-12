using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Feautres.Libros.Consultas.ObtenerLibroPorId
{
    public class ObtenerLibroId : IRequest<Respuesta<librodto>>
    {
        public int Id { get; set; }

        public class ObtenerLibroHandler : IRequestHandler<ObtenerLibroId, Respuesta<librodto>>
        {
            private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono;
            private readonly   IMapper _mapper;

            public ObtenerLibroHandler(IRepositorioAsincrono<Libro> repositorioAsincrono, IMapper mapper)
            {
                _repositorioAsincrono = repositorioAsincrono;
                _mapper = mapper;
            }



            public async Task<Respuesta<librodto>> Handle(ObtenerLibroId request, CancellationToken cancellationToken)
            {
                var libro = await _repositorioAsincrono.GetByIdAsync(request.Id);
                if (libro == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id{request.Id}");
                }
                else
                {
                    var objetodto = _mapper.Map<librodto>(libro);

                    return new Respuesta<librodto>(objetodto);

                }
            }
        }
        }
    }

