using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract.QueryModel
{
    [DataContract]
    public class ProyectosLugar
    {
        [DataMember]
        public string IDProyecto { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string PersonaResponsable { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public int Necesidades { get; set; }
    }
}
