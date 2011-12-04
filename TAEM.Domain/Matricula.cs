using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Matricula
    {
        public virtual int ID { get; set; }
        public virtual int RBD { get; set; }
        public virtual int TotalHombres { get; set; }
        public virtual int TotalMujeres { get; set; }
        public virtual int Total { get; set; }
        public virtual int Ano { get; set; }
    }
}
