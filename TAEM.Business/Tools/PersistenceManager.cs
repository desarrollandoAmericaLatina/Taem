using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vmk.Framework.Persistence.NHibernate;

namespace TAEM.Business.Tools
{
    public class PersistenceManager : PersistenceBase
    {
        /// <summary>
        /// Instancia un PersistenceManager con la Sesión de Persistencia por defecto.
        /// </summary>
        public PersistenceManager() : base() { }

        /// <summary>
        /// Instancia un PersistenceManager según la Sesión de Persistencia dada.
        /// </summary>
        /// <param name="nameSession">Nombre de Sesión de Persistencia.</param>
        public PersistenceManager(string nameSession) : base(nameSession) {}
    }
}
