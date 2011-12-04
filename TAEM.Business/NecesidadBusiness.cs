using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Business.Tools;
using TAEM.Domain;

namespace TAEM.Business
{
    public class NecesidadBusiness
    {
        public void DeleteNecesidad(int idNecesidad)
        {
            var pm = new PersistenceManager();
            var necesidad = pm.Get<Necesidad>(idNecesidad);
            if (necesidad == null)
            {
                throw new BusinessException(Properties.Resources.ErrorDeleteNecesidadNecesidadNoExiste);
            }
            if (necesidad.EstadoNecesidad == EstadoNecesidad.EnProceso)
            {
                throw new BusinessException(Properties.Resources.ErrorDeleteNecesidadEstadoEnProceso);
            }
            if (necesidad.EstadoNecesidad == EstadoNecesidad.Finalizada)
            {
                throw new BusinessException(Properties.Resources.ErrorDeleteNecesidadEstadoFinalizada);
            }
            pm.Delete(necesidad);
        }
    }
}
