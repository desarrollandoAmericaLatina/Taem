using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAEM.Business;
using TAEM.WebSite.Models.Establecimientos;
using System.Web.Script.Serialization;
using TAEM.Business.Tools;

namespace WebSite.Controllers
{
    public class EstablecimientosController : Controller
    {
        public ActionResult Grafico(int? id)
        {
            int rdb = id.Value;

            GraficoModel model = new GraficoModel();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var matriculas = EstablecimientoBusiness.GetMatriculas(rdb);
            var rendimientos = EstablecimientoBusiness.GetRendimientos(rdb);
            
            model.MatriculasJson = serializer.Serialize(matriculas);
            model.RendimientosJson = serializer.Serialize(rendimientos);
            model.NombreEstablecimiento = EstablecimientoBusiness.Nombre(rdb);
            
            return View(model);
        }

        public ActionResult EvalDocente(int? id)
        {
            int rdb = id.Value;

            GraficoModel model = new GraficoModel();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var evaluaciones = EstablecimientoBusiness.GetEvaluacionesDocentes(rdb);
            model.EvalDocente = serializer.Serialize(evaluaciones);

            return View(model);
        }
    }
}
