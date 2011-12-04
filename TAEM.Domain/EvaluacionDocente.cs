using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class EvaluacionDocente
    {
        public virtual int ID { get; set; }
        public virtual int RBD { get; set; }

        public virtual double A { get; set; }
        public virtual double B { get; set; }
        public virtual double C { get; set; }

        public virtual double D { get; set; }
        public virtual double E { get; set; }
        public virtual double F { get; set; }

        public virtual double G { get; set; }
        public virtual double H { get; set; }

        public virtual int Ano { get; set; }
    }
}
