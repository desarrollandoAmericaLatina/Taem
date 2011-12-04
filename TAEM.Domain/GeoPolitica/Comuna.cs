using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain.GeoPolitica
{
    public class Comuna
    {
        public virtual int ID { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
