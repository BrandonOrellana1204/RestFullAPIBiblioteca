using Dominio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Libro : Auditoria
    {
        public string TituloLibro { get; set; }
        public int CantidadPaginas { get; set; }
        public string Editorial { get; set; }
        public int cantidad { get; set; }

    }
}
