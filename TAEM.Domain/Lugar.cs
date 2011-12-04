using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoAPI.Geometries;

namespace TAEM.Domain
{
    public abstract class Lugar
    {
        public virtual int ID { get; set; }        
        public virtual string Nombre { get; set; }
        public virtual IPoint Posicion { get; set; }
    }
}
