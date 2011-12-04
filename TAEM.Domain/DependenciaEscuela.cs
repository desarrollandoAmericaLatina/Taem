using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class DependenciaEscuela
    {
        public virtual int RBD { get; set; }
        public virtual Dependencia Dependencia { get; set; }
    }
}
