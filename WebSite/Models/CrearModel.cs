using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAEM.Domain;

namespace WebSite.Models
{
    public class CrearModel
    {
        public IList<Proyecto> Proyectos { get; set; }
        public string Local { get; set; }

        public  bool Autenticado { get; set; }

        //public string Responsable { get; set; }
    }
}