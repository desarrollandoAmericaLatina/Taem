using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract
{
    [DataContract]
    public class UsuarioDC
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Rut { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
    }
}
