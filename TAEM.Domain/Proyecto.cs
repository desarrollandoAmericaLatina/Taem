using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Proyecto
    {
        public virtual int ID { get; set; }
        public virtual Lugar Lugar { get; set; }
        public virtual Usuario PersonaResponsable { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual DateTime FechaDeseable { get; set; }
        public virtual DateTime FechaIngreso { get; set; }
        public virtual DateTime FechaUltimaActualizacion { get; set; }
        public virtual string ImagenUrl { get; set; }
        public virtual string VideoUrl { get; set; }
        public virtual IList<Necesidad> Necesidades { get; set; }
        public virtual bool Finalizado { get; set; }
    }
}
