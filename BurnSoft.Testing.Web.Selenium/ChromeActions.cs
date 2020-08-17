using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Class ChromeActions.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ChromeActions :IDisposable
    {
        public GeneralActions Ga;
        /// <summary>
        /// The driver
        /// </summary>
        private ChromeDriver _driver;
        /// <summary>
        /// The wait
        /// </summary>
        private WebDriverWait _wait;
        /// <summary>
        /// The sleep interval
        /// </summary>
        private int _sleepInterval;
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
        /// The URL to start with
        /// </summary>
        public string Url;
        /// <summary>
        /// The settings screen shot location
        /// </summary>
        public string SettingsScreenShotLocation;
        /// <summary>
        /// Toggle the sleeping after a command was issue so you can see the results
        /// </summary>
        public bool DoSleep;
        /// <summary>
        /// The test name that will mostly be used for the screen capturing exception capturing
        /// </summary>
        public string TestName;

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initializer()
        {
            try
            {
                Ga = new GeneralActions(Url);
                Ga.SettingsScreenShotLocation = SettingsScreenShotLocation;
                _driver = new ChromeDriver();
                Ga.Driver = _driver;
                Ga.Initializer();
                //_driver.Navigate().GoToUrl($"{Url}");
                //_driver.Manage().Window.Maximize();
                //_wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                _driver.Quit();
            }
        }
        /// <summary>
        /// Screens the shot it.
        /// </summary>
        public void ScreenShotIt()
        {
            Ga.Driver = _driver;
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
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            Ga.FindElements(field, fb, ma, sendText);

            //try
            //{
            //    switch (ma)
            //    {
            //        case GeneralActions.MyAction.Click:
            //            _driver.FindElement(SetByType(field, fb)).Click();
            //            break;
            //        case GeneralActions.MyAction.Clear:
            //            _driver.FindElement(SetByType(field, fb)).Clear();
            //            break;
            //        case GeneralActions.MyAction.ClearSendKeys:
            //            _driver.FindElement(SetByType(field, fb)).Clear();
            //            _driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
            //            break;
            //        case GeneralActions.MyAction.SendKeys:
            //            _driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
            //            break;
            //        case GeneralActions.MyAction.Nothing:
            //            _driver.FindElement(SetByType(field, fb));
            //            break;
            //    }
            //    if (DoSleep) Thread.Sleep(SleepInterval);
            //}
            //catch (Exception e)
            //{
            //    Debug.Print(e.Message);
            //    ScreenShotIt();
            //    _driver.Quit();
            //}
        }
        /// <summary>
        /// Selects the element in page.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="textToSelect">The text to select.</param>
        public void SelectElementInPage(string field, GeneralActions.FindBy fb, string textToSelect)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            Ga.SelectElementInPage(field, fb,textToSelect);
            //var getAdminlist = _driver.FindElement(SetByType(field, fb));
            //SelectElement iSelect = new SelectElement(getAdminlist);
            //iSelect.SelectByText(textToSelect);
            //if (DoSleep) Thread.Sleep(SleepInterval);
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
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            Ga.WaitTillElementFound(field, fb, ma, sendKeys);
            //try
            //{
            //    var element = _wait.Until(ExpectedConditions.ElementIsVisible(SetByType(field, fb)));
            //    switch (ma)
            //    {
            //        case GeneralActions.MyAction.Click:
            //            element.Click();
            //            break;
            //        case GeneralActions.MyAction.Clear:
            //            element.Clear();
            //            break;
            //        case GeneralActions.MyAction.ClearSendKeys:
            //            element.Clear();
            //            element.SendKeys(sendKeys);
            //            break;
            //        case GeneralActions.MyAction.SendKeys:
            //            element.SendKeys(sendKeys);
            //            break;
            //        case GeneralActions.MyAction.Nothing:
            //            break;
            //    }
            //}
            //catch (Exception e)
            //{
            //    Debug.Print(e.Message);
            //    ScreenShotIt();
            //    _driver.Quit();
            //}
        }
        /// <summary>
        /// Does the wait.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        public void DoWait(string field, GeneralActions.FindBy fb)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            Ga.DoWait(field, fb);
            //try
            //{
            //    _wait.Until(wt => wt.FindElement(SetByType(field, fb)));
            //}
            //catch (Exception e)
            //{
            //    Debug.Print(e.Message);
            //    ScreenShotIt();
            //    _driver.Quit();
            //}
        }
        /// <summary>
        /// Releases the unmanaged resources.
        /// </summary>
        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
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
            _wait = null;
            Url = @"";
            TestName = @"";
            _driver.Close();
            _driver.Dispose();
            Ga.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        ~ChromeActions()
        {
            Dispose(false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        public ChromeActions()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public ChromeActions(string url)
        {
            Url = url;
        }
    }
}
