using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    [TestClass]
    public class FlexTestingPublicSide
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// Access Selenium Chrome Actions Class
        /// </summary>
        /// <value>The ca.</value>
        public FlexAction Ca { get; set; }
        /// <summary>
        /// Gets or sets the main URL.
        /// </summary>
        /// <value>The main URL.</value>
        public string MainUrl { get; set; }
        /// <summary>
        /// The settings screen shot location
        /// </summary>
        /// <value>The settings screen shot location.</value>
        public string SettingsScreenShotLocation { get; set; }
        /// <summary>
        /// The full exception path
        /// </summary>
        /// <value>The full exception path.</value>
        public string FullExceptionPath { get; set; }
        
        /// <summary>
        /// Closes this instance.
        /// </summary>
        [TestCleanup]
        public void Close()
        {
            if (Ca.ErrorList.Count > 0)
            {
                foreach (string err in Ca.ErrorList)
                {
                    TestContext.WriteLine(err);
                }
            }
            if (Ca != null) Ca.Dispose();
        }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            MainUrl = Vs2019.GetSetting("url_main");
            SettingsScreenShotLocation = Vs2019.GetSetting("SettingsScreenShotLocation");
            FullExceptionPath = SettingsScreenShotLocation;
            if (!Directory.Exists(FullExceptionPath)) Directory.CreateDirectory(FullExceptionPath);

            Ca = new FlexAction(FlexAction.UseDriver.Edge);
           
            Ca.TestName = "Init";
            Ca.Url = MainUrl;
            Ca.SettingsScreenShotLocation = SettingsScreenShotLocation;
            Ca.DoSleep = true;
            Ca.Initializer();
        }
        /// <summary>
        /// Defines the test method CheckPublic.
        /// </summary>
        [TestMethod]
        public void CheckPublic()
        {
            Ca.TestName = "PublicUI";
            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("My Gun Collection", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);

            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("My Loaders Log", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("File Renamer Utility", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("BurnPad", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[7]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("Contact", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("MainContent_txtName", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "Jimmy Pop Corn");
            Ca.FindElements("MainContent_txteMail", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "joe.mireles@burnsoft.net");
            Ca.FindElements("MainContent_txtMsg", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "Make software great again!");
            Ca.FindElements("MainContent_btnSend", GeneralActions.FindBy.Id, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("MainContent_Label4", GeneralActions.FindBy.Id, GeneralActions.MyAction.Nothing);

            Assert.IsTrue(Ca.ErrorList.Count == 0);
        }
        /// <summary>
        /// Defines the test method GetContentsOfTagTest.
        /// </summary>
        [TestMethod]
        public void GetContentsOfTagTest()
        {
            Ca.TestName = "GetContentsOfTagTest";

            string value = Ca.GetContentsOfTag("body");
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Length > 0);
        }

        /// <summary>
        /// Defines the test method NumberOfExpectedLinksTest.
        /// </summary>
        [TestMethod]
        public void NumberOfExpectedLinksTest()
        {
            Ca.TestName = "NumberOfExpectedLinksTest";
            Ca.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ca.NumberOfExpectedLinks("My Gun Collection", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value);
        }

        /// <summary>
        /// Defines the test method LinkIsPresentByLinkTextTest.
        /// </summary>
        [TestMethod]
        public void LinkIsPresentByLinkTextTest()
        {
            Ca.TestName = "LinkIsPresentByLinkTextTest";
            Ca.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ca.LinkIsPresentByLinkText("My Gun Collection", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value);
        }
        /// <summary>
        /// Defines the test method LinkIsPresentByIdTest.
        /// </summary>
        [TestMethod]
        public void LinkIsPresentByIdTest()
        {
            Ca.TestName = "LinkIsPresentByIdTest";
            Ca.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ca.LinkIsPresentById("MainContent_TreeView1t2", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void GetTextFromElementByIdTest()
        {
            Ca.TestName = "GetTextFromElementByIdTest";
            Ca.GoToAnotherPage($"{MainUrl}/Pages/Sitemap.aspx");
            string value = Ca.GetTextFromElementById("MainContent_TreeView1t5", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value.Length > 0);
        }
    }
}
