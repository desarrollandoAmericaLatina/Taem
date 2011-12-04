using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GeoAPI.Geometries;

namespace TAEM.Service.DataContract.QueryModel
{
    [DataContract]
    public class ItemLugar
    {
        private IPoint point;
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public IPoint Point
        {
            get
            {
                return point;
            }
            set
            {
                Posicion = new PointDC()
                {
                    Latitud = value.Coordinate.Y,
                    Longitud = value.Coordinate.X
                };
                point = value;
            }
        }

        [DataMember]
        public PointDC Posicion { get; set; }
    }
}
