using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GeoAPI.Geometries;

namespace TAEM.Service.DataContract.QueryModel
{
    [DataContract]
    public class ResultadoMapa
    {
        [DataMember]
        public List<ItemLugar> Items { get; set; }
    }
}
