using System;
using System.Collections.Generic;
using System.IO;
using BurnSoft.Testing.Web.Selenium.interfaces;
using BurnSoft.Testing.Web.Selenium.Types;
using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    /// <summary>
    /// Defines test class TestPublicSideChrome.
    /// Implements the <see cref="BurnSoft.Testing.Web.Selenium.interfaces.iChromeActions" />
    /// </summary>
    /// <seealso cref="BurnSoft.Testing.Web.Selenium.interfaces.iChromeActions" />
    [TestClass]
    public class TestPublicSideChrome : iChromeActions
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
        public ChromeActions Ca { get; set; }
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
            Ca.Dispose();
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

            Ca = new ChromeActions();
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
            Ca.WaitTillElementFound("MainContent_txtName", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys,"Jimmy Pop Corn");
            Ca.FindElements("MainContent_txteMail", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys,"joe.mireles@burnsoft.net");
            Ca.FindElements("MainContent_txtMsg", GeneralActions.FindBy.Id, GeneralActions.MyAction.SendKeys,"Make software great again!");
            Ca.FindElements("MainContent_btnSend", GeneralActions.FindBy.Id, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("MainContent_Label4", GeneralActions.FindBy.Id, GeneralActions.MyAction.Nothing);
        }

        [TestMethod]
        public void PublicSideBatch()
        {
            Ca.TestName = "PublicUIBatch";
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click, UseCommand  = GeneralActions.UseCommand.WaitFound,
                ElementName = "//ul[@id='jetmenu']/li[3]/a", FindBy = GeneralActions.FindBy.XPath
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "My Gun Collection",
                FindBy = GeneralActions.FindBy.LinkText
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "//ul[@id='jetmenu']/li[3]/a",
                FindBy = GeneralActions.FindBy.XPath
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "My Loaders Log",
                FindBy = GeneralActions.FindBy.LinkText
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "//ul[@id='jetmenu']/li[3]/a",
                FindBy = GeneralActions.FindBy.XPath
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "File Renamer Utility",
                FindBy = GeneralActions.FindBy.LinkText
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "//ul[@id='jetmenu']/li[3]/a",
                FindBy = GeneralActions.FindBy.XPath
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "BurnPad",
                FindBy = GeneralActions.FindBy.LinkText
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "//ul[@id='jetmenu']/li[7]/a",
                FindBy = GeneralActions.FindBy.XPath
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "Contact",
                FindBy = GeneralActions.FindBy.LinkText
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.SendKeys,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "MainContent_txtName",
                FindBy = GeneralActions.FindBy.Id,
                SendKeys = "Jimmy Pop Corn Batch"
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.Find,
                ElementName = "MainContent_txteMail",
                FindBy = GeneralActions.FindBy.Id,
                SendKeys = "joe.mireles@burnsoft.net"
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.Find,
                ElementName = "MainContent_txtMsg",
                FindBy = GeneralActions.FindBy.Id,
                SendKeys = "Make Software Great Again in Batch"
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.Find,
                ElementName = "MainContent_btnSend",
                FindBy = GeneralActions.FindBy.Id
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Nothing,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "MainContent_Label4",
                FindBy = GeneralActions.FindBy.Id
            });

            
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
