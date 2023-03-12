using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Exceptions
{
    public class ApiExcepciones : Exception
    {
        public ApiExcepciones() : base() { }

        public ApiExcepciones(string mensaje): base(mensaje) { }
       
        public ApiExcepciones( string mensaje, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,mensaje,args)) { }
    }
}
