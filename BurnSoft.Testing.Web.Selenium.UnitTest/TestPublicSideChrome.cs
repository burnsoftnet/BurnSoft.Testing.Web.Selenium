using System;
using System.Collections.Generic;
using System.IO;
using BurnSoft.Testing.Web.Selenium.interfaces;
using BurnSoft.Testing.Web.Selenium.Types;
using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable

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
            MainUrl = Vs2019.GetSetting("url_main");
            SettingsScreenShotLocation = Vs2019.GetSetting("SettingsScreenShotLocation");
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

        }

        [TestMethod]
        public void PublicSideBatch()
        {
            Ca.TestName = "PublicUIBatch";
            string softwareMenu = "//ul[@id='jetmenu']/li[3]/a";
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click, UseCommand  = GeneralActions.UseCommand.WaitFound,
                ElementName = softwareMenu, FindBy = GeneralActions.FindBy.XPath, TestName = @"Click On Windows App Menu"
            });
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "My Gun Collection",
                FindBy = GeneralActions.FindBy.LinkText,
                TestName = "Click on the My Gun Collection link"
            });
            
            
            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = softwareMenu,
                FindBy = GeneralActions.FindBy.XPath,
                TestName = @"Click On Windows App Menu"
            });


            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = "My Gun Collection",
                FindBy = GeneralActions.FindBy.LinkText,
                TestName = "Click on the My Gun Collection link"
            });


            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Nothing,
                UseCommand = GeneralActions.UseCommand.GetTextValue,
                ElementName = "//h3/span",
                FindBy = GeneralActions.FindBy.XPath,
                TestName = "Get Price of My Gun Collector Software"
            });

            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Click,
                UseCommand = GeneralActions.UseCommand.CheckExistAndClick,
                ElementName = "//a[contains(.,'DOWNLOAD NOW!!')]",
                FindBy = GeneralActions.FindBy.XPath,
                TestName = "Click on Download Button if it exists"
            });

            cmd.Add(new BatchCommandList()
            {
                Actions = GeneralActions.MyAction.Nothing,
                UseCommand = GeneralActions.UseCommand.GetTextValueAndCompare,
                ElementName = "//h3/span",
                FindBy = GeneralActions.FindBy.XPath,
                TestName = "Get Price of My Gun Collector Software and Compare to exptected Version",
                ExpectedReturnedValue = "FREE!"
            });

            List<BatchCommandList> value =  Ca.RunBatchCommands(cmd, out var errOut);

            int testNumber = 1;
            foreach (BatchCommandList v in value)
            {
                string passfailed = v.PassedFailed ? "PASSED" : "FAILED";
                TestContext.WriteLine($"{testNumber}.) {passfailed} - {v.TestName}");
                TestContext.WriteLine(v.ReturnedValue);
                testNumber++;
            }
        }
        [TestMethod]
        public void UseCommandListGetAndJumpToTest()
        {
            bool didPass = false;
            try
            {
                Ca.TestName = "UseCommandListGetAndJumpToTest";

                List<BatchCommandList> cmd = new List<BatchCommandList>();
                cmd.AddRange(BatchCmdHelper.Sleep500());
                cmd.AddRange(BatchCmdHelper.ClickOnElement("//ul[@id='jetmenu']/li[3]/a","software app menu"));
                cmd.AddRange(BatchCmdHelper.Sleep500());
                cmd.AddRange(BatchCmdHelper.ClickOnElement("//ul[@id='jetmenu']/li[4]/a","iOS App Menu"));
                cmd.AddRange(BatchCmdHelper.Sleep500());
                cmd.Add(new BatchCommandList()
                {
                    UseCommand = GeneralActions.UseCommand.GetUrlAndGoTo,
                    ElementName = "//a[contains(.,'My Essential Oil Remedies')]",
                    TestName = "Get Link Text and GOto url"
                });

                List<BatchCommandList> value = Ca.RunBatchCommands(cmd, out var errOut);

                int testNumber = 1;
                foreach (BatchCommandList v in value)
                {
                    string passfailed = v.PassedFailed ? "PASSED" : "FAILED";
                    TestContext.WriteLine($"{testNumber}.) {passfailed} - {v.TestName}");
                    TestContext.WriteLine(v.ReturnedValue);
                    testNumber++;
                }

                didPass = Ca.AllTestsPassed(value);
            }
            catch (Exception e)
            {
                TestContext.WriteLine(e.Message);
            }
            Assert.IsTrue(didPass);

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
