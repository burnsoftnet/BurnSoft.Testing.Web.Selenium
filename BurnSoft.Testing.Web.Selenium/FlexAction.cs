using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
// ReSharper disable InconsistentNaming
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable UseNullPropagation
// ReSharper disable UnusedMember.Global

namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Class FlexAction.  The flex action class is allows a quick and easy way to
    /// run test against seperate browsers just by passing which browser you want to use.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class FlexAction : IDisposable
    {
        /// <summary>
        /// Gets or sets the selected driver.
        /// </summary>
        /// <value>The selected driver.</value>
        public UseDriver SelectedDriver { get; set; }
        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>The driver.</value>
        private IWebDriver Driver { get; set; }
        /// <summary>
        /// Gets or sets the ga.
        /// </summary>
        /// <value>The ga.</value>
        private GeneralActions Ga { get; set; }
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        private int _sleepInterval { get; set; }

        /// <summary>
        /// A simple list to log errors
        /// </summary>
        public List<string> ErrorList;
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        public int SleepInterval
        {
            get
            {
                if (_sleepInterval == 0)
                {
                    return 2000;
                }
                else
                {
                    return _sleepInterval;
                }
            }
            set => _sleepInterval = value;
        }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the settings screen shot location.
        /// </summary>
        /// <value>The settings screen shot location.</value>
        public string SettingsScreenShotLocation { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [do sleep].
        /// </summary>
        /// <value><c>true</c> if [do sleep]; otherwise, <c>false</c>.</value>
        public bool DoSleep { get; set; }
        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        public string TestName { get; set; }
        /// <summary>
        /// Enum Use Broswer Driver Options
        /// </summary>
        public enum UseDriver
        {
            /// <summary>
            /// The chrome browser driver
            /// </summary>
            Chrome,
            /// <summary>
            /// The edge  browser driver, not the edge from the band U2, this is better, it's MS Edge
            /// </summary>
            Edge,
            /// <summary>
            /// The ie  browser driver
            /// </summary>
            IE,
            /// <summary>
            /// The fire fox  browser driver
            /// </summary>
            FireFox
        }

        #region "General Functions used in other Action Classess"
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initializer()
        {
            try
            {
                Ga = new GeneralActions(Url) { SettingsScreenShotLocation = SettingsScreenShotLocation };
                Ga.Driver = Driver;
                Ga.Initializer();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if (Driver != null) Driver.Quit();
            }
        }
        /// <summary>
        /// Screens the shot it.
        /// </summary>
        public void ScreenShotIt()
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            Ga.ScreenShotIt();
        }
        /// <summary>
        /// Goes to another page.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoToAnotherPage(string url)
        {
            Ga.GoToAnotherPage(url);
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma"> Perform Actions click, clear or send keys or do nothing and just read</param>
        /// <param name="sendText">the text that you want to send</param>
        public void FindElements(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma, string sendText = "")
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            Ga.FindElements(field, fb, ma, sendText);
        }
        /// <summary>
        /// Gets the contents of tag.  If you ask for the <br/>
        /// Body tag it will return only the text of the entire webpage.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string GetContentsOfTag(string name)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            return Ga.GetContentsOfTag(name);
        }

        /// <summary>
        /// Get the number of Expected Links by the Link text, the Default expected count is 1 but you can change that number
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">Error out if results return false or exception</param>
        /// <param name="expectedCount">The expected count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool NumberOfExpectedLinks(string name, out string errOut, int expectedCount = 1)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            return Ga.NumberOfExpectedLinks(name, out errOut, expectedCount);
        }
        /// <summary>
        /// Links the is present by link text.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception">Unable to find link {name}</exception>
        public bool LinkIsPresentByLinkText(string name, out string errOut)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            return Ga.LinkIsPresentByLinkText(name, out errOut);
        }
        /// <summary>
        /// Links the is present by identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception">Unable to find link {name}</exception>
        public bool LinkIsPresentById(string name, out string errOut)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            return Ga.LinkIsPresentById(name, out errOut);
        }
        /// <summary>
        /// Gets the text from element by identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementById(string name, out string errOut)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementById(name, out errOut);
        }
        /// <summary>
        /// Selects the element in page.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="textToSelect">The text to select.</param>
        public void SelectElementInPage(string field, GeneralActions.FindBy fb, string textToSelect)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            Ga.SelectElementInPage(field, fb, textToSelect);
        }

        /// <summary>
        /// Waits the till element found.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma">Actions to so, click clear, send keys etc</param>
        /// <param name="sendKeys">keys that you want to send</param>
        public void WaitTillElementFound(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma, string sendKeys = "")
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            Ga.WaitTillElementFound(field, fb, ma, sendKeys);
        }
        /// <summary>
        /// Does the wait.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        public void DoWait(string field, GeneralActions.FindBy fb)
        {
            Ga.Driver = Driver;
            Ga.TestName = TestName;
            Ga.DoWait(field, fb);
        }
        #endregion

        #region "Dispose Section"
        /// <summary>
        /// Releases the unmanaged resources.
        /// </summary>
        private void ReleaseUnmanagedResources()
        {

        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Url = @"";
            TestName = @"";
            if (Driver != null)
            {
                Driver.Close();
                Driver.Dispose();
            }
            ErrorList = null;
            Ga.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="FlexAction"/> class.
        /// </summary>
        ~FlexAction()
        {
            Dispose(false);
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            Driver = null;
        }
        #endregion
        #region "Initialize Section"
        /// <summary>
        /// Initializes a new instance of the <see cref="FlexAction"/> class.
        /// </summary>
        public FlexAction()
        {
            ErrorList = new List<string>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FlexAction"/> class.
        /// </summary>
        /// <param name="ud">The ud.</param>
        public FlexAction(UseDriver ud)
        {
            ErrorList = new List<string>();
            InitDriver(ud);
        }
        /// <summary>
        /// Initializes the driver.
        /// </summary>
        /// <param name="ud">The ud.</param>
        private void InitDriver(UseDriver ud)
        {
            try
            {
                switch (ud)
                {
                    case UseDriver.Chrome:
                        Driver = new ChromeDriver();
                        break;
                    case UseDriver.Edge:
                        Driver = new EdgeDriver();
                        break;
                    case UseDriver.IE:
                        Driver = new InternetExplorerDriver();
                        break;
                    case UseDriver.FireFox:
                        Driver = new FirefoxDriver();
                        break;
                    default:
                        Driver = new ChromeDriver();
                        break;
                }
            }
            catch (Exception e)
            {
                ApplendToErrorList("InitDriver", e.Message);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        /// <param name="ud">Use Selenium Driver selection</param>
        /// <param name="url">The URL.</param>
        public FlexAction(UseDriver ud, string url)
        {
            ErrorList = new List<string>();
            Url = url;
            InitDriver(ud);
        }
        #endregion        
        /// <summary>
        /// Applends to error list.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="msg">The MSG.</param>
        private void ApplendToErrorList(string function, string msg)
        {
            if (ErrorList == null) ErrorList = new List<string>();
            ErrorList.Add($"{DateTime.Now} - {function} - {msg}");
        }
    }
}
