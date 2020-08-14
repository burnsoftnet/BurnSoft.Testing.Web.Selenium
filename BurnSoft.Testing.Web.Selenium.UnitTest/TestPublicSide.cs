using System;
using System.IO;
using BurnSoft.Testing.Web.Selenium.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BurnSoft.Testing.Web.Selenium.UnitTest
{
    [TestClass]
    public class TestPublicSide : iChromeActions
    {

        public ChromeActions Ca { get; set; }
        public string MainUrl { get; set; }
        public string UsrLogin { get; set; }
        public string UsrPwd { get; set; }
        public string SettingsScreenShotLocation { get; set; }
        public string FullExceptionPath { get; set; }
        public string PagesLogin { get; set; }
        public void LogIn(string testName)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
        [TestCleanup]
        public void Close()
        {
            Ca.Dispose();
        }
        [TestInitialize]
        public void Init()
        {
            MainUrl = VS2019.GetSetting("url_main");
            SettingsScreenShotLocation = VS2019.GetSetting("SettingsScreenShotLocation");
            FullExceptionPath = SettingsScreenShotLocation;
            if (!Directory.Exists(FullExceptionPath)) Directory.CreateDirectory(FullExceptionPath);
        }

        [TestMethod]
        public void CheckPublic()
        {
            Ca = new ChromeActions();
            Ca.TestName = "PublicUI";
            Ca.Url = MainUrl;
            Ca.SettingsScreenShotLocation = SettingsScreenShotLocation;
            Ca.DoSleep = true;
            Ca.Initializer();
            Ca.FindElements("My Gun Collection", ChromeActions.FindBy.LinkText, ChromeActions.MyAction.Click);
            Ca.FindElements("//div[@id='main-container']/div[2]/div/div[4]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            Ca.FindElements("//div[@id='main-container']/div[2]/div/div[5]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            Ca.FindElements("//ul[@id='jetmenu']/li[3]/a", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            Ca.FindElements("My Loaders Log", ChromeActions.FindBy.LinkText, ChromeActions.MyAction.Click);
            Ca.FindElements("File Renamer Utility", ChromeActions.FindBy.LinkText, ChromeActions.MyAction.Click);
            Ca.FindElements("BurnPad", ChromeActions.FindBy.LinkText, ChromeActions.MyAction.Click);
            Ca.FindElements("Contact", ChromeActions.FindBy.LinkText, ChromeActions.MyAction.Click);

        }
    }
}
