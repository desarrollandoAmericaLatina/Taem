using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Service.Contract;
using System.ServiceModel.Activation;
using TAEM.Business.Tools;
using NHibernate;
using TAEM.Domain;
using AutoMapper;
using TAEM.Service.DataContract;
using GisSharpBlog.NetTopologySuite.Geometries;
using NHibernate.Spatial.Criterion;
using TAEM.Service.DataContract.QueryModel;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Linq;
using TAEM.Business;
using System.Web;

namespace TAEM.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class APIService : IAPIService
    {
        public int SaveProyecto(ProyectoDC proyecto)
        {
            var domain = Mapper.Map<ProyectoDC, Proyecto>(proyecto);
            return ProyectoBusiness.CreateProyecto(domain);
        }

        public ResultadoMapa ListLugares(DataContract.PointDC tl, DataContract.PointDC br, byte zoom, FiltroMapa filtro)
        {
            if (zoom >= 8)
            {
                PersistenceManager persistence = new PersistenceManager();
                ICriteria criteria = persistence.CreateCriteria<Lugar>();
                List<Coordinate> coordenadas = new List<Coordinate>();
                coordenadas.Add(new Coordinate(tl.Longitud, tl.Latitud));
                coordenadas.Add(new Coordinate(br.Longitud, tl.Latitud));
                coordenadas.Add(new Coordinate(br.Longitud, br.Latitud));
                coordenadas.Add(new Coordinate(tl.Longitud, br.Latitud));
                coordenadas.Add(new Coordinate(tl.Longitud, tl.Latitud));
                Polygon p = new Polygon(new LinearRing(coordenadas.ToArray()));
                criteria.SetProjection(Projections.ProjectionList()
                    .Add(Projections.Property<Lugar>(l => l.ID), "ID")
                    .Add(Projections.Property<Lugar>(l => l.Posicion), "Point")
                    .Add(Projections.Property<Lugar>(l => l.Nombre), "Nombre")
                    );
                criteria.Add(SpatialRestrictions.Within("Posicion", p));
                criteria.SetResultTransformer(Transformers.AliasToBean<ItemLugar>());
                criteria.AddOrder(new Order(Projections.Property<Lugar>(l => l.Nombre), true));
                var list = criteria.List<ItemLugar>().ToList();
                HttpContext.Current.Session["Colegios"] = list;
                return new ResultadoMapa() { Items = list };
            }
            return new ResultadoMapa() { Items = new List<ItemLugar>() };
        }

        public List<ProyectosLugar> ListProyectosLugar(int idLugar)
        {
            var pm = new PersistenceManager();
            var criteria = pm.CreateCriteria<Proyecto>();
            criteria.SetProjection(Projections.ProjectionList()
                .Add(Projections.Property<Proyecto>(p => p.ID), "IDProyecto")
                .Add(Projections.Property<Proyecto>(p => p.Nombre), "Nombre")
                .Add(Projections.Property<Proyecto>(p => p.Descripcion), "Descripcion")
                .Add(Projections.Property<Proyecto>(p => p.PersonaResponsable.Rut), "PersonaResponsable")
                .Add(Projections.Property<Proyecto>(p => p.FechaIngreso), "FechaIngreso")
                .Add(Projections.Property<Proyecto>(p => p.Necesidades.Count), "Necesidades")
                );
            criteria.SetResultTransformer(Transformers.AliasToBean<ProyectosLugar>());
            return criteria.List<ProyectosLugar>().ToList();
        }

        public void CrearDonacion(IList<int> necesidades )
        {
            if (necesidades.Count > 0)
            {
                foreach (var item in necesidades)
                {
                    var fechaActual = DateTime.Now;

                    var pm = new PersistenceManager();

                    var necesidad = (from n in pm.Session.Query<Necesidad>()
                                     where n.ID == item
                                     select n).FirstOrDefault();

                    var usuario = (from u in pm.Session.Query<Usuario>()
                                   where u.ID == 1
                                   select u).FirstOrDefault();


                    Donacion donacion = new Donacion();
                    DonacionNecesidad donacionNecesidad = new DonacionNecesidad();

                    donacionNecesidad.DetalleDonante = "";
                    donacionNecesidad.DetalleBeneficiarion = "";


                    donacionNecesidad.Donacion = donacion;
                    donacionNecesidad.Necesidad = necesidad;


                    donacion.Fecha = fechaActual;

                    IList<DonacionNecesidad> listNecesidad = new List<DonacionNecesidad>();
                    listNecesidad.Add(donacionNecesidad);
                    donacion.DonacionNecesidades = listNecesidad;
                    donacion.Usuario = usuario;

                    pm.Save(donacion);
                    pm.Flush();
                    
                }

               
            }
            
        }
    }
}
