using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class DatosSIMCE
    {
        public virtual int ID { get; set; }
        public virtual int RBD { get; set; }
        public virtual int AlumLect { get; set; }
        public virtual decimal PromLect { get; set; }
        public virtual int AlumMat { get; set; }
        public virtual decimal PromMat { get; set; }
        public virtual int AlumSoc { get; set; }
        public virtual decimal PromSoc { get; set; }
        public virtual int AlumNat { get; set; }
        public virtual decimal PromNat { get; set; }
        public virtual int AlumIng { get; set; }
        public virtual decimal PromIngTotal { get; set; }
        public virtual int Ano { get; set; }
        public virtual int Curso { get; set; }
    }
}
