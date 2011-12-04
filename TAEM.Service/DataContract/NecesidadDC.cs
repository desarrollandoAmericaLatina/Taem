using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using TAEM.Domain;

namespace TAEM.Service.DataContract
{
    [DataContract]
    public class NecesidadDC
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string MasInformacionUrl { get; set; }
        [DataMember]
        public string ImagenUrl { get; set; }
        [DataMember]
        public EstadoNecesidad EstadoNecesidad { get; set; }
    }
}
