using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAEM.WebSite.Models;
using TAEM.Business.Tools;
using TAEM.Domain;
using TAEM.Business;
using System.Web.Script.Serialization;
using WebSite.Models;
using TAEM.Service.DataContract.QueryModel;

namespace WebSite.Controllers
{
    public class FormularioController : Controller
    {
        //
        // GET: /Formulario/

        public ActionResult FichaColegio(int id)
        {
            FichaLugarModel fichaColegio = new FichaLugarModel();
            fichaColegio.Lugar = GenericBusiness.Load<Lugar>(id);
            var escuela = GenericBusiness.Load<Escuela>(id);
            
            fichaColegio.Proyectos = ProyectoBusiness.ListProyectosLugar(id);

            var dependeciaEscuela = DependenciaEscuelaBussines.GetDependencia(escuela.RDB);
            
            if (dependeciaEscuela == null)
            {
                dependeciaEscuela = new DependenciaEscuela();
                Dependencia depedencia = new Dependencia();
                depedencia.IDDependencia = 0;
                depedencia.Nombre = "Dato no disponible";

                dependeciaEscuela.Dependencia = depedencia;

            }
            fichaColegio.TiposEnseñanzas = EstablecimientoBusiness.GetTiposEnsenanza(id);
            fichaColegio.DependenciaEscuela = dependeciaEscuela;
            fichaColegio.Historias = ProyectoBusiness.ListHistoriasLugar(id);
            
            return View(fichaColegio);
        }

        public ActionResult ResumenSimce(int id, int curso) 
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var simces = EstablecimientoBusiness.GetSIMCES(new int[] { id });
            List<int> ids = new List<int>();
            foreach (var item in (List<ItemLugar>)Session["Colegios"])
            {
                if(id != item.ID)
                    ids.Add(item.ID);
            }
            
            var todosSimces = EstablecimientoBusiness.GetSIMCES(ids.ToArray());

            SIMCESModel model = new SIMCESModel { SIMCEColegio = simces, SIMCEResto = todosSimces };

            return View(model);
        }
    }
}
