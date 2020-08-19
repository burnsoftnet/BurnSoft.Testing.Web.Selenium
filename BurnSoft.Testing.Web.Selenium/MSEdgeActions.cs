using System;
using System.Diagnostics;
using BurnSoft.Testing.Web.Selenium.interfaces;
using OpenQA.Selenium.Edge;

namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Class to test the website using the Selenium Edge Driver
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="iGeneral" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="iGeneral" />
    public class MsEdgeActions : IDisposable, iGeneral
    {
        /// <summary>
        /// The driver
        /// </summary>
        private EdgeDriver _driver;
        /// <summary>
        /// Gets or sets the ga.
        /// </summary>
        /// <value>The ga.</value>
        public GeneralActions Ga { get; set; }
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        public int _sleepInterval { get; set; }

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
        /// Initialize this instance.
        /// </summary>
        public void Initializer()
        {
            try
            {
                Ga = new GeneralActions(Url) { SettingsScreenShotLocation = SettingsScreenShotLocation };
                _driver = new EdgeDriver();
                Ga.Driver = _driver;
                Ga.Initializer();
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
            Ga.Driver = _driver;
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
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            Ga.DoWait(field, fb);
        }
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
            if (_driver != null)
            {
                _driver.Close();
                _driver.Dispose();
            }
            Ga.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        ~MsEdgeActions()
        {
            Dispose(false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        public MsEdgeActions()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public MsEdgeActions(string url)
        {
            Url = url;
        }
    }
}
