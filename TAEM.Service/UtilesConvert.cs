using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TAEM.Domain;
using TAEM.Service.DataContract;

namespace TAEM.Service
{
    public static class UtilesConvert
    {
        public static void Configure() {
            Mapper.CreateMap<Lugar, LugarDC>()
                .ForMember(d => d.Posicion, a => a.Ignore())
                .AfterMap((d, dDC) =>
                {
                    if (d != null && d.Posicion != null)
                        dDC.Posicion = new PointDC()
                        {
                            Latitud = d.Posicion.Y,
                            Longitud = d.Posicion.X
                        };
                });
            Mapper.CreateMap<Proyecto, ProyectoDC>();
        }
    }
}
