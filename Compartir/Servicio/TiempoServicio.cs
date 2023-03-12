using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartir.Servicio
{

    public class TiempoServicio : ITiempoServicio
    {
        DateTime ITiempoServicio.FechaActual => DateTime.UtcNow;
    }
}
