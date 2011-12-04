using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class DonacionNecesidad
    {
        public virtual int IDDonacionNecesidad {get; set;}
        public virtual Necesidad Necesidad {get; set;}
        public virtual Donacion Donacion {get; set;}
        public virtual DateTime?  FechaIngresoBeneficiario {get; set;}
        public virtual string DetalleBeneficiarion {get; set;}
        public virtual bool RecibidoBeneficiario {get; set;}
        public virtual DateTime?  FechaIngresoDonante {get; set;}
        public virtual string DetalleDonante {get; set;}
        public virtual bool EntregadoPorDonante { get; set; }

    }
}
