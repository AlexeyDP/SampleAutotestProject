using NUnit.Framework;

namespace Atest.Suites
{
    [SetUpFixture]
    public class SetUpClass
    {
        BaseTest testSuite = new BaseTest();
        [OneTimeSetUp]
        public void RunBeforeTest()
        {
            
            testSuite.StartDriver();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            testSuite.QuitDriver();
        }
    }
}
