
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

namespace Aplicacion.Feautres.Libros.Comandos.CrearLibro
{

        public class CrearLibro : IRequest<Respuesta<int>>
        {
            public string TituloLibro { get; set; }
            public int CantidadPaginas { get; set; }
            public string Editorial { get; set; }
            public int cantidad { get; set; }
        }

        public class CrearClienteHandler : IRequestHandler<CrearLibro, Respuesta<int>>
        
        {
        private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono; //agregar constructor
        private readonly IMapper _mapper; //agregar parametros
        public CrearClienteHandler(IRepositorioAsincrono<Libro> repositorioAsincrono, IMapper mapper)
        {
            _repositorioAsincrono = repositorioAsincrono;
            _mapper = mapper;
        }
    
        public async Task<Respuesta<int>> Handle(CrearLibro request, CancellationToken cancellationToken)
            {
            var nuevoRegistro = _mapper.Map<Libro>(request);
            var data = await _repositorioAsincrono.AddAsync(nuevoRegistro);
            return new Respuesta<int>(data.Id);
            }
        }
    }

