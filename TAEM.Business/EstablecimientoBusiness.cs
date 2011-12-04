using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Domain;
using TAEM.Business.Tools;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace TAEM.Business
{
    public static class EstablecimientoBusiness
    {
        public static string Nombre(int rdb)
        {
            var pm = new PersistenceManager();

            var r = (from m in pm.Session.Query<Escuela>()
                     where m.RDB == rdb
                     select m.Nombre
                     ).Single();

            return r;
        }


        public static Escuela Establecimiento(int rdb)
        {
            var pm = new PersistenceManager();

            var r = (from m in pm.Session.Query<Escuela>()
                     where m.RDB == rdb
                     select m
                     ).Single();

            return r;
        }

        public static IList<Matricula> GetMatriculas(int rdb)
        {
            var pm = new PersistenceManager();

            var r = (from m in pm.Session.Query<Matricula>()
                     where m.RBD == rdb
                     select m
                     ).ToList();

            return r;
        }

        public static IList<Rendimiento> GetRendimientos(int rdb)
        {
            var pm = new PersistenceManager();

            var rs = (from r in pm.Session.Query<Rendimiento>()
                     where r.RBD == rdb
                     select r
                     ).ToList();

            return rs;
        }

        public static IList<TipoEnsenanza> GetTiposEnsenanza(int rdb)
        {
            var pm = new PersistenceManager();

            var rs = (from r in pm.Session.Query<TipoEnsenanza>()
                      where r.RBD == rdb
                      select r
                     ).ToList();

            return rs;
        }

        public static List<DatosSIMCEQM> GetSIMCES(int[] rbd)
        {
            var pm = new PersistenceManager();
            ICriteria criteria = pm.CreateCriteria<DatosSIMCE>();

            criteria.Add(Restrictions.In("RBD", rbd));
            criteria.SetProjection(Projections.ProjectionList()
                .Add(Projections.Property<DatosSIMCE>(d => d.Ano), "Ano")
                .Add(Projections.Avg<DatosSIMCE>(d => d.PromLect), "PromLect")
                .Add(Projections.Avg<DatosSIMCE>(d => d.PromMat), "PromMat")
                .Add(Projections.Avg<DatosSIMCE>(d => d.PromNat), "PromNat")
                .Add(Projections.Avg<DatosSIMCE>(d => d.PromSoc), "PromSoc")
                .Add(Projections.Avg<DatosSIMCE>(d => d.PromIngTotal), "PromIngTotal")
                .Add(Projections.GroupProperty("Ano")));
            criteria.SetResultTransformer(Transformers.AliasToBean<DatosSIMCEQM>());
            criteria.AddOrder(new Order("Ano", true));
            var a = criteria.List<DatosSIMCEQM>().ToList();
            
            return a;
        }

        public static IList<EvaluacionDocente> GetEvaluacionesDocentes(int id)
        {
            var pm = new PersistenceManager();

            var rdb = (from e in pm.Session.Query<Escuela>()
                       where e.ID == id
                       select e.RDB).Single();

            var rs = (from r in pm.Session.Query<EvaluacionDocente>()
                      where r.RBD == rdb
                      select r
                     ).ToList();

            return rs;
        }
    }
}
