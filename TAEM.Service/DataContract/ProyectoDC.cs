using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract
{
    [DataContract]
    public class ProyectoDC
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public LugarDC Lugar { get; set; }
        [DataMember]
        public UsuarioDC PersonaResponsable { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public DateTime FechaDeseable { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaUltimaActualizacion { get; set; }
        [DataMember]
        public string ImagenUrl { get; set; }
        [DataMember]
        public string VideoUrl { get; set; }
        [DataMember]
        public IList<NecesidadDC> Necesidades { get; set; }
        [DataMember]
        public bool Finalizado { get; set; }
    }
}
