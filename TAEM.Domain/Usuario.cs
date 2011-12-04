using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class Usuario
    {
        public virtual int ID { get; set; }
        public virtual string Rut { get; set; }
        public virtual string Nombres { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual string EMail { get; set; }

        //TODO: Completar atributos
    }
}
