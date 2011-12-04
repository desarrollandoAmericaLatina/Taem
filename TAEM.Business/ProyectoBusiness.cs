using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Domain;
using TAEM.Business.Tools;
using NHibernate.Linq;

namespace TAEM.Business
{
    public class ProyectoBusiness
    {
        public static int CreateProyecto(Proyecto proyecto)
        {
            ValidateProyecto(proyecto);
            var fechaActual = DateTime.Now;
            var pm = new PersistenceManager();
            proyecto.FechaIngreso = fechaActual;
            proyecto.FechaUltimaActualizacion = fechaActual;
            pm.Save(proyecto);
            return proyecto.ID;
        }

        public static int UpdateProyecto(Proyecto proyecto)
        {
            ValidateProyecto(proyecto);
            var fechaActual = DateTime.Now;
            var pm = new PersistenceManager();
            proyecto.FechaUltimaActualizacion = fechaActual;
            pm.Update(proyecto);
            return proyecto.ID;
        }

        public static Proyecto GetProyectoId(int idProyecto)
        {
            var pm = new PersistenceManager();
            return pm.Get<Proyecto>(idProyecto);
        }

        public static IList<Proyecto> ListProyectosLugar(int idLugar)
        {
            PersistenceManager persistence = new PersistenceManager();
            return (from p in persistence.Session.Query<Proyecto>()
                    where p.Lugar.ID == idLugar
                    select p).ToList();
        }

        public static IList<Historia> ListHistoriasLugar(int idLugar)
        {
            PersistenceManager persistence = new PersistenceManager();
            return (from h in persistence.Session.Query<Historia>()
                    where h.Proyecto.Lugar.ID == idLugar
                    select h).ToList();
        }

        private static void ValidateProyecto(Proyecto proyecto)
        {
            if (proyecto == null)
            {
                throw new ArgumentNullException("proyecto");
            }
            if (proyecto.PersonaResponsable == null)
            {
                throw new ArgumentNullException("persona responsable");
            }
            if (proyecto.Necesidades == null)
            {
                throw new ArgumentNullException("necesidades");
            }
            if (proyecto.Necesidades.Count == 0)
            {
                throw new BusinessException(Properties.Resources.ErrorProyectoSinNecesidades);
            }
        }
    }
}
