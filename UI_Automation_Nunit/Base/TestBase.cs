using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Automation_Nunit.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp] 
        public void BeforeAll() 
        {
            FW.CreateTestResultDirectory();
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
        }

        [TearDown]
        public void AfterEach()
        {

        }
    }
}
