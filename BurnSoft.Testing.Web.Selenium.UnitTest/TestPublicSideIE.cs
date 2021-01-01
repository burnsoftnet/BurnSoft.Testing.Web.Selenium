using System;
using System.IO;
using BurnSoft.Testing.Web.Selenium.interfaces;
using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    /// <summary>
    /// Defines test class TestPublicSideIE.
    /// Implements the <see cref="BurnSoft.Testing.Web.Selenium.interfaces.iIEActions" />
    /// </summary>
    /// <seealso cref="BurnSoft.Testing.Web.Selenium.interfaces.iIEActions" />
    [TestClass]
    public class TestPublicSideIE : iIEActions
    {
        /// <summary>
        /// Access Selenium Chrome Actions Class
        /// </summary>
        /// <value>The ca.</value>
        public IEActions Ea { get; set; }
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
        }
        /// <summary>
        /// Defines the test method CheckPublic.
        /// </summary>
        [TestMethod]
        public void CheckPublic()
        {
            Ea = new IEActions();
            Ea.TestName = "PublicUI";
            Ea.Url = MainUrl;
            Ea.SettingsScreenShotLocation = SettingsScreenShotLocation;
            Ea.DoSleep = true;
            Ea.Initializer();
            Ea.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ea.WaitTillElementFound("My Gun Collection", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
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
            Ea = new IEActions();
            Ea.TestName = "GetContentsOfTagTest";
            Ea.Url = MainUrl;
            Ea.SettingsScreenShotLocation = SettingsScreenShotLocation;
            Ea.DoSleep = true;
            Ea.Initializer();

            string value = Ea.GetContentsOfTag("body");
            Console.WriteLine(value);
            Assert.IsTrue(value.Length > 0);
        }
    }
}
