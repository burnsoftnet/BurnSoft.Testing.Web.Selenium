using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using BurnSoft.Testing.Web.Selenium.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
// ReSharper disable EmptyDestructor
// ReSharper disable UnusedMember.Global
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable RedundantAssignment
// ReSharper disable UseNullPropagation
// ReSharper disable RedundantCast
// ReSharper disable SimplifyConditionalTernaryExpression
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
        /// Enum UseCommand
        /// </summary>
        public enum UseCommand
        {
            /// <summary>
            /// The find
            /// </summary>
            Find,
            /// <summary>
            /// The wait found
            /// </summary>
            WaitFound,
            /// <summary>
            /// The wait
            /// </summary>
            Wait,
            /// <summary>
            /// The sleep
            /// </summary>
            Sleep,
            /// <summary>
            /// The find element and get the text value
            /// </summary>
            GetTextValue,
            /// <summary>
            /// The get text value and compare to an expted value
            /// </summary>
            GetTextValueAndCompare,
            /// <summary>
            /// The move a slider
            /// </summary>
            MoveSlider,
            /// <summary>
            /// Get the Test value and see if it contains whatever
            /// </summary>
            GetTextValueAndMustContain

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
            //Driver.Navigate().GoToUrl($"{url}");
            Driver.Url = url;
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
        /// Moves the slider.
        /// </summary>
        /// <param name="elementName">Name of the element as xPath.</param>
        /// <param name="sliderMin">The minium slider value</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="moveAmount">the amount to move the slider</param>
        /// <param name="sliderMax">the maxium slider amount</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool MoveSlider(string elementName, int moveAmount, int sliderMax, int sliderMin, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                IWebElement slider = Driver.FindElement(By.XPath(elementName));
                int pixelsToMove = GetPixelsToMove(slider, moveAmount, sliderMax, sliderMin);
                Actions sliderAction = new Actions(Driver);
                sliderAction.ClickAndHold(slider)
                    .MoveByOffset((-(int)slider.Size.Width / 2), 0)
                    .MoveByOffset(pixelsToMove, 0).Release().Perform();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return bAns;
        }
        /// <summary>
        /// Gets the pixels to move.
        /// </summary>
        /// <param name="slider">The slider.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="sliderMax">The slider maximum.</param>
        /// <param name="sliderMin">The slider minimum.</param>
        /// <returns>System.Int32.</returns>
        public int GetPixelsToMove(IWebElement slider, decimal amount, decimal sliderMax, decimal sliderMin)
        {
            int pixels = 0;
            decimal tempPixels = slider.Size.Width;
            tempPixels = tempPixels / (sliderMax - sliderMin);
            tempPixels = tempPixels * (amount - sliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }
        /// <summary>
        /// Generates the results from the Batch Command List to display the step number, testname, any returnedvalue results and
        /// if it failed, to return the element name that it failed at.
        /// </summary>
        /// <param name="cmdResults">The command results.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GenerateResults(List<BatchCommandList> cmdResults, out string errOut)
        {
            string sAns = "";
            errOut = "";
            try
            {
                int stepNumber = 1;
                foreach (BatchCommandList c in cmdResults)
                {
                    if (c.TestName != null)
                    {
                        if (c.TestName?.Length > 0)
                        {
                            string passFailed = c.PassedFailed ? "PASSED!" : "FAILED!";
                            sAns += $"{Environment.NewLine}{stepNumber}.)  {passFailed} {c.TestName}";
                            if (c.ReturnedValue.Length > 0) sAns += $"  {c.ReturnedValue}";
                            if (!c.PassedFailed) sAns += $"{Environment.NewLine} Failed at line: {c.ElementName}";
                            stepNumber++;
                        }
                    }
                }

                if (sAns.Length > 0) sAns += $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }

        /// <summary>
        /// Works through the results of the Batch Command list and looks to see if any of the tests where marked as failed,
        /// if some show up as failed then it will return false, else everything passed and it is true.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public bool AllTestsPassed(List<BatchCommandList> results)
        {
            return !results.Any(r => !r.PassedFailed);
        }

        /// <summary>
        /// Runs the batch of list commands to test the web ui
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public List<BatchCommandList> RunBatchCommands(List<BatchCommandList> cmd, out string errOut)
        {
            List<BatchCommandList> theReturned = new List<BatchCommandList>();
            errOut = @"";
            try
            {
                foreach (BatchCommandList c in cmd)
                {
                    bool didpass = false;
                    string result = @"";
                    string sendkeys = @"";
                    string jumpurl = @"";
                    try
                    {
                        if (Driver == null) throw new Exception("Error occured and the Driver is not active!");
                        if (c.SendKeys != null) sendkeys = c.SendKeys;
                        if (c.JumpToUrl != null) jumpurl = c.JumpToUrl;

                        if (sendkeys?.Length == 0 && jumpurl?.Length ==0)
                        {
                            switch (c.UseCommand)
                            {
                                case UseCommand.Find:
                                    FindElements(c.ElementName, c.FindBy, c.Actions);
                                    break;
                                case UseCommand.GetTextValue:
                                    bool blankOk = c.ReturnedValueBlankOk != null ? c.ReturnedValueBlankOk : false;

                                    result = GetTextFromElement(c.ElementName, out errOut);
                                    if (!blankOk)
                                    {
                                        if (result?.Length == 0) throw new Exception($"Unable to get value from {c.ElementName}");
                                    }
                                    else
                                    {
                                        if (result?.Length == 0) result = "Nothing was returned, but we expected that.";
                                    }
                                    
                                    break;
                                case UseCommand.GetTextValueAndCompare:
                                    result = GetTextFromElement(c.ElementName, out errOut);
                                    if (result?.Length == 0) throw new Exception($"Unable to get value from {c.ElementName}");
                                    if (!result.Equals(c.ExpectedReturnedValue)) throw new Exception($"Values Did Not Match Up!! got {result} but expected {c.ExpectedReturnedValue}");
                                    result = $"Value MATCH!  Expected {c.ExpectedReturnedValue} and got {result}";
                                    break;
                                case UseCommand.GetTextValueAndMustContain:
                                    result = GetTextFromElement(c.ElementName, out errOut);
                                    if (result?.Length == 0) throw new Exception($"Unable to get value from {c.ElementName}");
                                    if (!result.Contains(c.ExpectedReturnedValue)) throw new Exception($"Value was not found!! got {result} but expected {c.ExpectedReturnedValue}");
                                    result = $"Value FOUND!  Expected {c.ExpectedReturnedValue} and got {result}";
                                    break;
                                case UseCommand.Sleep:
                                    Thread.Sleep(c.SleepInterval);
                                    break;
                                case UseCommand.Wait:
                                    DoWait(c.ElementName, c.FindBy);
                                    break;
                                case UseCommand.WaitFound:
                                    WaitTillElementFound(c.ElementName, c.FindBy, c.Actions);
                                    break;
                                case UseCommand.MoveSlider:
                                    didpass = MoveSlider(c.ElementName, c.SliderMoveTo, c.SliderMax, c.SliderMin, out errOut);
                                    if (errOut?.Length > 0) throw new Exception($"Error occured while attempting to move slider. {errOut}");
                                    break;
                            }
                        }
                        else if (sendkeys?.Length > 0 && jumpurl?.Length ==0)
                        {
                            switch (c.UseCommand)
                            {
                                case UseCommand.Find:
                                    FindElements(c.ElementName, c.FindBy, c.Actions, c.SendKeys);
                                    break;
                                case UseCommand.WaitFound:
                                    WaitTillElementFound(c.ElementName, c.FindBy, c.Actions, c.SendKeys);
                                    break;
                            }
                        } else if (jumpurl.Length > 0)
                        {
                            GoToAnotherPage(c.JumpToUrl);
                        }

                        if (!didpass) didpass = true;
                    }
                    catch (Exception e)
                    {
                        didpass = false;
                        result = e.Message;
                    }
                    theReturned.Add( new BatchCommandList(){SleepInterval = c.SleepInterval ,Actions = c.Actions, ElementName = c.ElementName, SendKeys = c.SendKeys, UseCommand = c.UseCommand, FindBy = c.FindBy, PassedFailed = didpass, SliderMax = c.SliderMax, SliderMin = c.SliderMin, SliderMoveTo = c.SliderMoveTo, ReturnedValue = result, JumpToUrl = c.JumpToUrl, TestName = c.TestName});
                }
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }

            return theReturned;
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
            bool bAns;
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
        /// Well attempt to get the value from the xpath, id, classname, cssSelector if the string keeps returning null.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElement(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = GetTextFromElementById(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByXPath(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByClassName(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByCssSelector(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByName(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByTagName(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByLinkText(name, out _);
                if (sAns?.Length == 0) sAns = GetTextFromElementByPartialLinkText(name, out _);
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
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
        /// <summary>
        /// Gets the text from element by xpath
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByXPath(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.XPath(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Gets the text from element by Class Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByClassName(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.ClassName(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Gets the text from element by Css Selector
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByCssSelector(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.CssSelector(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Get Text from Element by the Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByName(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.Name(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Get Text from Element by the Tag Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByTagName(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.TagName(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Get Text from Element by the link text
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByLinkText(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.LinkText(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }
        /// <summary>
        /// Get Text from Element by the partial link text
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errOut"></param>
        /// <returns></returns>
        public string GetTextFromElementByPartialLinkText(string name, out string errOut)
        {
            string sAns = @"";
            errOut = @"";
            try
            {
                sAns = Driver.FindElement(By.PartialLinkText(name)).Text;
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return sAns;
        }

        /// <summary>
        /// Gets the contents of tag.  If you ask for the <br/>
        /// Body tag it will return only the text of the entire webpage.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string GetContentsOfTag(string name)
        {
            return Driver.FindElement(By.TagName(name)).Text;
        }
    }
}
