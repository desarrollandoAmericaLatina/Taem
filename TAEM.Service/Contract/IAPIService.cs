using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TAEM.Service.DataContract;
using TAEM.Service.DataContract.QueryModel;

namespace TAEM.Service.Contract
{
    [ServiceContract(Namespace = "TAEM")]    
    public interface IAPIService
    {
        [OperationContract]
        ResultadoMapa ListLugares(PointDC tl, PointDC br, byte zoom, FiltroMapa filtro);

        [OperationContract]
        void CrearDonacion(IList<int> necesidades);
    }
}
