using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplicacion.Feautres.Libros.Comandos.EliminarLibro
{
    public class EliminarLibroValidacion : AbstractValidator<EliminarLibro>
    {
        public EliminarLibroValidacion() 
        {
            RuleFor(p => p.Id);
        }
    }
}
