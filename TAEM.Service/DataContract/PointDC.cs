using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract
{
    [DataContract]
    public class PointDC
    {
        [DataMember]
        public double Latitud { get; set; }
        [DataMember]
        public double Longitud { get; set; }
    }
}