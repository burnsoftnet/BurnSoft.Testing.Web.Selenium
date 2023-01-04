# BurnSoft.Testing.Web.Selenium

![](https://img.shields.io/nuget/vpre/BurnSoft.Testing.Web.Selenium) | ![](https://img.shields.io/nuget/v/BurnSoft.Testing.Web.Selenium)

This library was created to simplify testing out a website using Selenium.  All you have to do is add which interface that you want to use (Chrome, IE, Edge, etc) and add the code required for that interface to initialize the module.

Then in your main test you just have to add the tags and and types of tags and actions that you want to perform.

I do recommend using the Selenium Chrome IDE to first walk through what you want to do with the site, then use that session capture to get the names of the id's, xpaths, etc that you want to step through with your tests.

If there is an error, it will perform a screen shot capture and store it in a directory of your choosing so you can see what the error might be.

## Resources
- [https://www.selenium.dev](https://www.selenium.dev)
- [Selenium Chrome IDE](https://chrome.google.com/webstore/detail/selenium-ide/mooikfkahbdckldjjndioackbalphokd?hl=en)

## How To Use

1. Install nuget package
2. Check out the Unit Tests for examples on what the interface requires.  A lot of it is copy and paste code except for the parts on what items that you are looking for on the selected website.

### Example:

        [TestClass]
    public class TestPublicSideChrome : iChromeActions
    {
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
            MainUrl = "http://www.burnsoft.test";
            SettingsScreenShotLocation = "c:\pics\";
            FullExceptionPath = SettingsScreenShotLocation;
            if (!Directory.Exists(FullExceptionPath)) Directory.CreateDirectory(FullExceptionPath);
        }
        /// <summary>
        /// Defines the test method CheckPublic.
        /// </summary>
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
        
Happy Testing!

[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JSW8XEMQVH4BE)]

## Release Log

### v.1.0.0.44
- Updated drivers, verified everything still works with the unit tests

### v.1.0.0.43
- Updated drivers

### v1.0.0.42
- Updated Edge Driver
- Added the ability to See if an element exists, if it does then you can click on it.

### v.1.0.0.41
- Updated drivers
- Added More options for framwork support. .net 5 and .net framework 4.8


### v.1.0.0.40
- Updated drivers

### v.1.0.0.39
- Updated drivers

### v.1.0.0.38
- Updated drivers
- Added the ability to increase the Wait Till Found based on the cpu speed of the machine, slower older machines will increase to 40 seconds max wait while newer machines will be at 15 seconds max wait

### v.1.0.0.37
- Updated drivers
- Added exposed variable to get the screen shot locations and added it to the results

### v.1.0.0.36
- Updated drivers

### v.1.0.0.35

- Fixed Driver Select for flex actions

### v1.0.0.34

- Added cheat sheet for documentation and added flex action stain gto driver function and options list

### v1.0.0.33

- Updated selenium libraries and unit test, fixed glitch with newer selenium project

### v1.0.0.26

- new release with addition command functions, flex action, and the ability to run a selenium side ( .side ) file for the test

### v1.0.0.5

- Added Flex Command to switch between Firefox, chrome and edge
- Added Batch Command function so you can seed you element commands and option through a list and it will run that batch command
- Added/ Simplified get element value function to just pass the element and we will guess the rest 

### v1.0.0.0

Initial Release

