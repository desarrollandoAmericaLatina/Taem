using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TAEM.Service.DataContract
{
    [DataContract]
    public class EscuelaDC : LugarDC
    {
        public int RDB { get; set; }
    }
}
