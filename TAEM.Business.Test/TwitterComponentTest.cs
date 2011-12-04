using TAEM.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TAEM.Domain;

namespace TAEM.Business.Test
{
    
    
    /// <summary>
    ///This is a test class for TwitterComponentTest and is intended
    ///to contain all TwitterComponentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TwitterComponentTest
    {
        private TestContext testContextInstance;

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


        /// <summary>
        ///A test for SendMessage
        ///</summary>
        [TestMethod()]
        public void SendMessageTest()
        {
            TwitterComponent target = new TwitterComponent();
            Proyecto proyecto = new Proyecto();
            proyecto.ID = 5;
            proyecto.Nombre = "Dipiriyeah, testing DAL";
            target.SendMessage(proyecto);
        }
    }
}
