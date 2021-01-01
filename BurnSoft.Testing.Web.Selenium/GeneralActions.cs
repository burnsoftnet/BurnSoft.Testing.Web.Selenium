using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
// ReSharper disable EmptyDestructor
// ReSharper disable UnusedMember.Global
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable RedundantAssignment
// ReSharper disable UseNullPropagation
#pragma warning disable 618

namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Class GeneralActions.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class GeneralActions : IDisposable
    {
        /// <summary>
        /// The test name that will mostly be used for the screen capturing exception capturing
        /// </summary>
        public string TestName;
        /// <summary>
        /// The driver
        /// </summary>
        public IWebDriver Driver;
        /// <summary>
        /// The settings screen shot location
        /// </summary>
        public string SettingsScreenShotLocation;
        /// <summary>
        /// The URL to start with
        /// </summary>
        public string Url;
        /// <summary>
        /// Toggle the sleeping after a command was issue so you can see the results
        /// </summary>
        public bool DoSleep;
        /// <summary>
        /// The wait
        /// </summary>
        public WebDriverWait Wait;
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
        /// Initialize this instance.
        /// </summary>
        public void Initializer()
        {
            try
            {
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl($"{Url}");
                Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 15));
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                Driver.Quit();
            }
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="GeneralActions"/> class.
        /// </summary>
        ~GeneralActions()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralActions"/> class.
        /// </summary>
        public GeneralActions()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralActions"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public GeneralActions(string url)
        {
            Url = url;
        }
        /// <summary>
        /// Enum My Actions to do on the web page
        /// </summary>
        public enum MyAction
        {
            /// <summary>
            /// The nothing
            /// </summary>
            Nothing,
            /// <summary>
            /// The click
            /// </summary>
            Click,
            /// <summary>
            /// The send keys
            /// </summary>
            SendKeys,
            /// <summary>
            /// The send keys submit
            /// </summary>
            SendKeysSubmit,
            /// <summary>
            /// The clear
            /// </summary>
            Clear,
            /// <summary>
            /// The clear send keys
            /// </summary>
            ClearSendKeys,
            /// <summary>
            /// The submit
            /// </summary>
            Submit,
            /// <summary>
            /// The clear send keys submit
            /// </summary>
            ClearSendKeysSubmit,
        }

        /// <summary>
        /// Enum FindBy
        /// </summary>
        public enum FindBy
        {
            /// <summary>
            /// The class name
            /// </summary>
            ClassName,
            /// <summary>
            /// The identifier
            /// </summary>
            Id,
            /// <summary>
            /// The x path
            /// </summary>
            XPath,
            /// <summary>
            /// The link text
            /// </summary>
            LinkText,
            /// <summary>
            /// The CSS selector
            /// </summary>
            CssSelector,
            /// <summary>
            /// The tag name
            /// </summary>
            TagName,
            /// <summary>
            /// The name
            /// </summary>
            Name,
            /// <summary>
            /// The partial link text
            /// </summary>
            PartialLinkText
        }

        /// <summary>
        /// Screens the shot it.
        /// </summary>
        public void ScreenShotIt()
        {
            if (Driver != null)
            {
                ITakesScreenshot screenShotDriver = (ITakesScreenshot)Driver;
                if (screenShotDriver.GetScreenshot() != null)
                {
                    if (TestName == null || TestName?.Length ==0) TestName = "UnMarked";
                    Screenshot screenShot = screenShotDriver.GetScreenshot();
                    screenShot.SaveAsFile($"{SettingsScreenShotLocation}\\{TestName}-{DateTime.Now.Ticks}.png", ScreenshotImageFormat.Png);
                }
                else
                {
                    Debug.Print("The browser is not active so we are unable to take a screen shot at this time.");
                }

            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Driver?.Dispose();
            Driver = null;
            SettingsScreenShotLocation = @"";
            TestName = @"";
        }
        /// <summary>
        /// Goes to another page.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoToAnotherPage(string url)
        {
            Driver.Navigate().GoToUrl($"{url}");
        }

        /// <summary>
        /// Sets the type of the by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <returns>By.</returns>
        private By SetByType(string field, FindBy fb)
        {
            By b = new ByAll();
            try
            {
                switch (fb)
                {
                    case FindBy.ClassName:
                        b = By.ClassName(field);
                        break;
                    case FindBy.Id:
                        b = By.Id(field);
                        break;
                    case FindBy.XPath:
                        b = By.XPath(field);
                        break;
                    case FindBy.CssSelector:
                        b = By.CssSelector(field);
                        break;
                    case FindBy.LinkText:
                        b = By.LinkText(field);
                        break;
                    case FindBy.PartialLinkText:
                        b = By.PartialLinkText(field);
                        break;
                    case FindBy.Name:
                        b = By.Name(field);
                        break;
                    case FindBy.TagName:
                        b = By.TagName(field);
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if (Driver != null) Driver.Quit();
            }
            return b;
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma"> Perform Actions click, clear or send keys or do nothing and just read</param>
        /// <param name="sendText">the text that you want to send</param>
        public void FindElements(string field, FindBy fb, MyAction ma, string sendText = "")
        {
            try
            {
                switch (ma)
                {
                    case MyAction.Click:
                        Driver.FindElement(SetByType(field, fb)).Click();
                        break;
                    case MyAction.Clear:
                        Driver.FindElement(SetByType(field, fb)).Clear();
                        break;
                    case MyAction.ClearSendKeys:
                        Driver.FindElement(SetByType(field, fb)).Clear();
                        Driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
                        break;
                    case MyAction.SendKeys:
                        Driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
                        break;
                    case MyAction.SendKeysSubmit:
                        Driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
                        Driver.FindElement(SetByType(field, fb)).Submit();
                        break;
                    case MyAction.ClearSendKeysSubmit:
                        Driver.FindElement(SetByType(field, fb)).Clear();
                        Driver.FindElement(SetByType(field, fb)).SendKeys(sendText);
                        Driver.FindElement(SetByType(field, fb)).Submit();
                        break;
                    case MyAction.Submit:
                        Driver.FindElement(SetByType(field, fb)).Submit();
                        break;
                    case MyAction.Nothing:
                        Driver.FindElement(SetByType(field, fb));
                        break;
                }
                if (DoSleep) Thread.Sleep(SleepInterval);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if (Driver != null) Driver.Quit();
            }
        }
        /// <summary>
        /// Selects the element in page.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="textToSelect">The text to select.</param>
        public void SelectElementInPage(string field, FindBy fb, string textToSelect)
        {
            var getAdminlist = Driver.FindElement(SetByType(field, fb));
            SelectElement iSelect = new SelectElement(getAdminlist);
            iSelect.SelectByText(textToSelect);
            if (DoSleep) Thread.Sleep(SleepInterval);
        }

        /// <summary>
        /// Waits the till element found.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma">Actions to so, click clear, send keys etc</param>
        /// <param name="sendKeys">keys that you want to send</param>
        public void WaitTillElementFound(string field, FindBy fb, MyAction ma, string sendKeys = "")
        {
            try
            {
                var element = Wait.Until(ExpectedConditions.ElementIsVisible(SetByType(field, fb)));
                switch (ma)
                {
                    case MyAction.Click:
                        element.Click();
                        break;
                    case MyAction.Clear:
                        element.Clear();
                        break;
                    case MyAction.ClearSendKeys:
                        element.Clear();
                        element.SendKeys(sendKeys);
                        break;
                    case MyAction.SendKeys:
                        element.SendKeys(sendKeys);
                        break;
                    case MyAction.Nothing:
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if(Driver !=null) Driver.Quit();
            }
        }
        /// <summary>
        /// Does the wait.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        public void DoWait(string field, FindBy fb)
        {
            try
            {
                Wait.Until(wt => wt.FindElement(SetByType(field, fb)));
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if (Driver != null) Driver.Quit();
            }
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
            bool bAns = false;
            errOut = @"";
            try
            {
                int myCount = Driver.FindElements(By.LinkText(name)).Count;
                bAns = myCount == expectedCount;
                if (!bAns) throw new Exception($"Expected {expectedCount} of {name} but got {myCount}");
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return bAns;
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
            bool bAns = false;
            errOut = @"";
            try
            {
                bAns = Driver.FindElement(By.LinkText(name)).Displayed;
                if (!bAns) throw new Exception($"Unable to find link {name}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return bAns;
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
            bool bAns = false;
            errOut = @"";
            try
            {
                bAns = Driver.FindElement(By.Id(name)).Displayed;
                if (!bAns) throw new Exception($"Unable to find link id {name}");
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return bAns;
        }
        /// <summary>
        /// Gets the text from element by identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementById(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.Id(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
    }
}
