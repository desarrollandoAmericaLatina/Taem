using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class TipoEnsenanza
    {
        public virtual int ID { get; set; }
        public virtual int RBD { get; set; }
        public virtual string NombreTipoEnsenanza { get; set; }
    }
}
