using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Rendimiento
    {
        public virtual int ID { get; set; }
        public virtual int RBD { get; set; }

        public virtual int TotalHombresRetirados { get; set; }
        public virtual int TotalMujeresRetiradas { get; set; }
        public virtual int TotalRetirados { get; set; }

        public virtual int TotalHombresAprobados { get; set; }
        public virtual int TotalMujeresAprobadas { get; set; }
        public virtual int TotalAprobados { get; set; }

        public virtual int TotalHombresReprobados { get; set; }
        public virtual int TotalMujeresReprobadas { get; set; }
        public virtual int TotalReprobados { get; set; }

        public virtual int Ano { get; set; }
    }
}
