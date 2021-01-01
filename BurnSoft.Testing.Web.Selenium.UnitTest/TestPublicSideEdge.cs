using System;
using System.IO;
using BurnSoft.Testing.Web.Selenium.interfaces;
using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    [TestClass]
    public class TestPublicSideEdge : iMsEdgeActions
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
        public MsEdgeActions Ea { get; set; }
        /// <summary>
        /// Gets or sets the main URL.
        /// </summary>
        /// <value>The main URL.</value>
        public string MainUrl { get; set; }
        /// <summary>
        /// Gets or sets the usr login.
        /// </summary>
        /// <value>The usr login.</value>
        public string UsrLogin { get; set; }
        /// <summary>
        /// Gets or sets the usr password.
        /// </summary>
        /// <value>The usr password.</value>
        public string UsrPwd { get; set; }
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
        /// Gets or sets the pages login.
        /// </summary>
        /// <value>The pages login.</value>
        public string PagesLogin { get; set; }
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void LogIn(string testName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Logs the out.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void LogOut()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        [TestCleanup]
        public void Close()
        {
            Ea.Dispose();
        }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            MainUrl = VS2019.GetSetting("url_main");
            SettingsScreenShotLocation = VS2019.GetSetting("SettingsScreenShotLocation");
            FullExceptionPath = SettingsScreenShotLocation;
            if (!Directory.Exists(FullExceptionPath)) Directory.CreateDirectory(FullExceptionPath);

            Ea = new MsEdgeActions();
            Ea.TestName = "Init";
            Ea.Url = MainUrl;
            Ea.SettingsScreenShotLocation = SettingsScreenShotLocation;
            Ea.DoSleep = true;
            Ea.Initializer();
        }
        /// <summary>
        /// Defines the test method CheckPublic.
        /// </summary>
        [TestMethod]
        public void CheckPublic()
        {
            Ea.TestName = "PublicUI";

            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("My Gun Collection", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            //Ea.FindElements("//div[@id='main-container']/div[2]/div/div[4]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            //Ea.FindElements("//div[@id='main-container']/div[2]/div/div[5]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            //Ea.FindElements("//ul[@id='jetmenu']/li[3]/a", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("My Loaders Log", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("File Renamer Utility", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("BurnPad", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[7]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("Contact", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("MainContent_txtName", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "Jimmy Pop Corn");
            Ea.FindElements("MainContent_txteMail", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "joe.mireles@burnsoft.net");
            Ea.FindElements("MainContent_txtMsg", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys, "Make software great again!");
            Ea.FindElements("MainContent_btnSend", GeneralActions.FindBy.Id, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("MainContent_Label4", GeneralActions.FindBy.Id, GeneralActions.MyAction.Nothing);
        }


        /// <summary>
        /// Defines the test method GetContentsOfTagTest.
        /// </summary>
        [TestMethod]
        public void GetContentsOfTagTest()
        {
            Ea.TestName = "GetContentsOfTagTest";

            string value = Ea.GetContentsOfTag("body");
            TestContext.WriteLine(value);
            Assert.IsTrue(value.Length > 0);
        }

        /// <summary>
        /// Defines the test method NumberOfExpectedLinksTest.
        /// </summary>
        [TestMethod]
        public void NumberOfExpectedLinksTest()
        {
            Ea.TestName = "NumberOfExpectedLinksTest";
            Ea.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ea.NumberOfExpectedLinks("My Gun Collection", out var err);
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
            Ea.TestName = "LinkIsPresentByLinkTextTest";
            Ea.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ea.LinkIsPresentByLinkText("My Gun Collection", out var err);
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
            Ea.TestName = "LinkIsPresentByIdTest";
            Ea.GoToAnotherPage($"{MainUrl}/Pages/Software_OpenSource.aspx");
            bool value = Ea.LinkIsPresentById("MainContent_TreeView1t2", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value);
        }
        /// <summary>
        /// Defines the test method GetTextFromElementByIdTest.
        /// </summary>
        [TestMethod]
        public void GetTextFromElementByIdTest()
        {
            Ea.TestName = "GetTextFromElementByIdTest";
            Ea.GoToAnotherPage($"{MainUrl}/Pages/Sitemap.aspx");
            string value = Ea.GetTextFromElementById("MainContent_TreeView1t5", out var err);
            if (err?.Length > 0) TestContext.WriteLine(err);
            TestContext.WriteLine($"{value}");
            Assert.IsTrue(value.Length > 0);
        }
    }
}
