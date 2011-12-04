using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Donacion
    {
        public virtual int IDDonacion { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual IList<DonacionNecesidad> DonacionNecesidades { get; set; }
    }
}
