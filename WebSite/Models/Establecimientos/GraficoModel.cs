using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAEM.Domain;

namespace TAEM.WebSite.Models.Establecimientos
{
    public class GraficoModel
    {
        public string NombreEstablecimiento { get; set; }
        public string MatriculasJson { get; set; }
        public string RendimientosJson { get; set; }

        public string EvalDocente { get; set; }
    }
}