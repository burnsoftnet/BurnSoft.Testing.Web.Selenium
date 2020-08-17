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
            Ca.WaitTillElementFound("//ul[@id='jetmenu']/li[3]/a", GeneralActions.FindBy.XPath, GeneralActions.MyAction.Click);
            Ca.WaitTillElementFound("My Gun Collection", GeneralActions.FindBy.LinkText, GeneralActions.MyAction.Click);
            //Ca.FindElements("//div[@id='main-container']/div[2]/div/div[4]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            //Ca.FindElements("//div[@id='main-container']/div[2]/div/div[5]", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
            //Ca.FindElements("//ul[@id='jetmenu']/li[3]/a", ChromeActions.FindBy.XPath, ChromeActions.MyAction.Click);
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
    }
}
