using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Domain;
using TAEM.Business.Tools;
using NHibernate.Linq;

namespace TAEM.Business
{
    public class DependenciaEscuelaBussines
    {


        public static DependenciaEscuela GetDependencia(int id)
        {
            var pm = new PersistenceManager();
            return pm.Get<DependenciaEscuela>(id);
        }

       
    }
}
