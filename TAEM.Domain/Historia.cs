using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Historia
    {
        public virtual int ID { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string VideoUrl { get; set; }
        public virtual string ImagenUrl { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
