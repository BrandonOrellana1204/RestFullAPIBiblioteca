using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Aplicacion.Exceptions
{
    public class ExcepcionesValidacion : Exception
    {
       
        public ExcepcionesValidacion() : base("Tiene errores de validación")
        {
            Error = new List<string>();
        }
        public List<string> Error { get; }
        public ExcepcionesValidacion(IEnumerable<ValidationErrores> errores) : this()
        {
            foreach (var error in errores)
            {
                Error.Add(error.ErrorMessage);
            }
        }
    }
}
