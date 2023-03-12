using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Wrappers
{
    public class Respuesta<T>
    {
        public Respuesta()
        {

        }
        public Respuesta(T datos, string mensaje = null)
        {
            Confirmar = true;
            Mensaje = mensaje;
            Datos = datos;
        }
        public Respuesta(string mensaje)
        {
            Confirmar = false;
            Mensaje = mensaje;
        }
        public bool Confirmar { get; set; }
        public string Mensaje { get; set; }

        public List<string> Errors { get; set; }
        public T Datos { get; set; }
    }
}
