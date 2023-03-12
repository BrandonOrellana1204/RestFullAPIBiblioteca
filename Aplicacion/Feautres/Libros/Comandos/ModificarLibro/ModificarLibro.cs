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

namespace Aplicacion.Feautres.Libros.Comandos.ModificarLibro
{
    public class ModificarLibro : IRequest<Respuesta<int>>
    {
        public int Id { get; set; }
        public string TituloLibro { get; set; }
        public int CantidadPaginas { get; set; }
        public string Editorial { get; set; }
        public int cantidad { get; set; }
    }
    public class ModificarLibroHandler : IRequestHandler<ModificarLibro, Respuesta<int>>
    {
        private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono; //agregar constructor
        private readonly IMapper _mapper; //agregar parametros

        public  ModificarLibroHandler (IRepositorioAsincrono<Libro> repositorioAsincrono, IMapper mapper)
        {
            _repositorioAsincrono = repositorioAsincrono;
            _mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ModificarLibro request, CancellationToken cancellationToken)
        {
            var libro = await _repositorioAsincrono.GetByIdAsync(request.Id);
            if (libro ==null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id{request.Id}");
            }
            else
            {
                libro.TituloLibro= request.TituloLibro;
                libro.CantidadPaginas = request.CantidadPaginas;
                libro.Editorial= request.Editorial;
                libro.cantidad= request.cantidad;

                await _repositorioAsincrono.UpdateAsync(libro);

                return new Respuesta<int>(libro.Id);

            }
        }

    }
}
