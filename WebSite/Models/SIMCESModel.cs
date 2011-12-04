using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAEM.Domain;

namespace WebSite.Models
{
    public class SIMCESModel
    {
        public List<DatosSIMCEQM> SIMCEColegio { get; set; }
        public List<DatosSIMCEQM> SIMCEResto { get; set; }
    }
}