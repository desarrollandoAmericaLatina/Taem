using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAEM.Domain;

namespace TAEM.WebSite.Models
{
    public class FichaLugarModel
    {        
        public Lugar Lugar { get; set; }
        public IList<Proyecto> Proyectos { get; set; }
        public DependenciaEscuela DependenciaEscuela { get; set; }
        public IList<Historia> Historias { get; set; }
        public IList<TipoEnsenanza> TiposEnseñanzas { get; set; }
        
    }
}