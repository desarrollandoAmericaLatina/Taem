using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAEM.Domain
{
    public class DatosSIMCEQM
    {
        public virtual double PromLect { get; set; }
        public virtual double PromMat { get; set; }
        public virtual double PromSoc { get; set; }
        public virtual double PromNat { get; set; }
        public virtual double PromIngTotal { get; set; }
        public virtual int Ano { get; set; }
    }
}