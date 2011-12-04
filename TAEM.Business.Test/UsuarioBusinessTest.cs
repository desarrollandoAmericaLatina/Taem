using TAEM.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TAEM.Domain;
using System.Collections.Generic;

namespace TAEM.Business.Test
{
    
    
    /// <summary>
    ///This is a test class for UsuarioBusinessTest and is intended
    ///to contain all UsuarioBusinessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioBusinessTest
    {
        private TestContext testContextInstance;

        static UsuarioBusinessTest()
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void ListUsuariosTest()
        {
            UsuarioBusiness target = new UsuarioBusiness();
            IList<Usuario> actual = target.ListUsuarios();
        }

        [TestMethod]
        public void ListUsuariosLugares()
        {
            UsuarioBusiness target = new UsuarioBusiness();
            IList<UsuarioLugar> actual = target.ListUsuariosLugares();
        }
    }
}
