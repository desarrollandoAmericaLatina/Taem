using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Dependencia
    {
        public virtual int IDDependencia { get; set; }
        public virtual string Nombre { get; set; }
        public virtual IList<DependenciaEscuela> EscuelasDependientes  { get; set; }
        
    }
}
