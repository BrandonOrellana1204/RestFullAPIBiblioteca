using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Comun
{
    public abstract class Auditoria
    {
        public virtual int Id { get; set; }
        public string? Creadopor { get; set; }
        public DateTime Creado { get; set; }
        public string? UltimaModificacionPor { get; set; }
        public DateTime? UltimaModificacion { get; set; }

    }
}
