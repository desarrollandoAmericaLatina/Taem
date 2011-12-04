using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAEM.Domain;
using TAEM.Business.Tools;
using NHibernate.Linq;
namespace TAEM.Business.Test
{
    [TestClass()]
    public class DonacionBussinesTest
    {
         private TestContext testContextInstance;

         static DonacionBussinesTest()
        {
            Vmk.Framework.Configuration.FrameworkConfigurationManager.Configure();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

         [TestMethod()]
        public void ListDonacion()
        {
            //PersistenceManager persistence = new PersistenceManager();
            //var xx = (from d in persistence.Session.Query<Donacion>()
            //        where d.IDDonacion == 1
            //        select d);

            IList<int> list = new List<int>();
            list.Add(1);
            foreach (var item in list)
            {
             
                var fechaActual = DateTime.Now;

                var pm = new PersistenceManager();

                var necesidad = (from n in pm.Session.Query<Necesidad>()
                                 where n.ID == item
                                 select n).FirstOrDefault();

                var usuario = (from u in pm.Session.Query<Usuario>()
                               where u.ID == 1
                               select u).FirstOrDefault();


                Donacion donacion = new Donacion();
                DonacionNecesidad donacionNecesidad = new DonacionNecesidad();

                donacionNecesidad.DetalleDonante = "";
                donacionNecesidad.DetalleBeneficiarion = "";


                donacionNecesidad.Donacion = donacion;
                donacionNecesidad.Necesidad = necesidad;


                donacion.Fecha = fechaActual;

                IList<DonacionNecesidad> listNecesidad = new List<DonacionNecesidad>();
                listNecesidad.Add(donacionNecesidad);
                donacion.DonacionNecesidades = listNecesidad;
                donacion.Usuario = usuario;

                pm.Save(donacion);
                pm.Flush();
            }

        }

       
    }
}
