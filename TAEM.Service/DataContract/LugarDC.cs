using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract
{
    [DataContract]
    [KnownType(typeof(LugarDC))]
    public class LugarDC
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public PointDC Posicion { get; set; }
    }
}
