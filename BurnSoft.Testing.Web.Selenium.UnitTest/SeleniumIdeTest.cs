using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    [TestClass]
    public class SeleniumIdeTest
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// The error out
        /// </summary>
        private string _errOut;
        /// <summary>
        /// The file
        /// </summary>
        private string _file;
        /// <summary>
        /// The test name
        /// </summary>
        private string _testName;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _errOut = "";
            _file = Vs2019.GetSetting("SIDE_FileName"); 
            _testName = Vs2019.GetSetting("SIDE_TestName");
        }
        /// <summary>
        /// Defines the test method RunSideFile.
        /// </summary>
        [TestMethod]
        public void RunSideFile()
        {
            bool value = SeleniumIde.RunSeleniumIdeFile(_file, _testName, out var results, out _errOut);
            TestContext.WriteLine(results);
            if (_errOut.Length > 0) TestContext.WriteLine($"ERROR: {_errOut}");
            Assert.IsTrue(value);
        }
    }
}
