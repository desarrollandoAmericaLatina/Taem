using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain.GeoPolitica
{
    public class Provincia
    {
        public virtual int ID { get; set; }
        public virtual string Nombre { get; set; }
        public virtual IList<Comuna> Comunas { get; set; }
        public virtual Region Region { get; set; }
    }
}
