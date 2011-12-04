using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAEM.Domain
{
    public class UsuarioLugar
    {
        public virtual int ID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Lugar Lugar { get; set; }
        public virtual bool EsAdministrador { get; set; }
    }
}
