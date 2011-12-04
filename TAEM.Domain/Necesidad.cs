using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Necesidad
    {
        public virtual int ID { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string MasInformacionUrl { get; set; }
        public virtual string ImagenUrl { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual EstadoNecesidad EstadoNecesidad { get; set; }

        public virtual IList<DonacionNecesidad> DonacionesNecesidad { get; set; }
    }
}
