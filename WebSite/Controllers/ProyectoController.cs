using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using TAEM.Business;
using TAEM.Domain;

namespace WebSite.Controllers
{
    public class ProyectoController : Controller
    {
        //
        // GET: /Proyecto/

        public ActionResult Crear(int? RBD)
        {
            CrearModel model = new CrearModel();

            var local= Session["Local"];

            if (RBD.HasValue || local!=null )
            {
                Escuela est;
                if (local != null)
                {
                    est = EstablecimientoBusiness.Establecimiento(Convert.ToInt32(local));
                }
                else {
                    est = EstablecimientoBusiness.Establecimiento(RBD.Value);
                    Session["Local"] = est.ID;
                    Response.Redirect("/");
                }
                
                model.Proyectos = ProyectoBusiness.ListProyectosLugar(est.ID);
                model.Local = EstablecimientoBusiness.Nombre(est.ID);

               

                model.Autenticado = true;
            }
            else {
                model.Autenticado = false;
            }
            
            return View(model);
        }


        //public ActionResult Autenticar(int RBD)
        //{
        //    CrearModel model = new CrearModel();
        //    model.Proyectos = ProyectoBusiness.ListProyectosLugar(id);

        //    model.Local = EstablecimientoBusiness.Nombre(id);

        //    return View(model);
        //}


    }
}
