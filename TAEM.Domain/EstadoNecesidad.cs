using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vmk.Framework.Enums;

namespace TAEM.Domain
{
    [Serializable]
    public enum EstadoNecesidad
    {
        [EnumsText("Activo")]
        Activo = 0,
        [EnumsText("En proceso")]
        EnProceso = 1,
        [EnumsText("Finalizado")]
        Finalizada = 2

    }
}
