using Atest.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atest.Suites
{
    [SetUpFixture]
    public class SetUpClass
    {
        
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Browser.Start();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Browser.Quit();
        }
    }
}
