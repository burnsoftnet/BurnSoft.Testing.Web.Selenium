using System;
using System.Collections.Generic;
using System.Diagnostics;
using BurnSoft.Testing.Web.Selenium.interfaces;
using BurnSoft.Testing.Web.Selenium.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// ReSharper disable UnusedMember.Global
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable RedundantAssignment

namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Class ChromeActions.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ChromeActions :IDisposable, iGeneral
    {
        /// <summary>
        /// The driver
        /// </summary>
        private ChromeDriver _driver;

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
        /// The screen shot location/
        /// </summary>
        public List<string> ScreenShotLocation;
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
                Ga = new GeneralActions(Url) {SettingsScreenShotLocation = SettingsScreenShotLocation};
                _driver = new ChromeDriver();
                Ga.Driver = _driver;
                Ga.Initializer();
                ScreenShotLocation = new List<string>();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                ScreenShotIt();
                if (_driver != null) _driver.Quit();
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
            ScreenShotLocation.AddRange(Ga.ScreenShotLocation);
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
        /// Finds the elements.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="sendText">The send text.</param>
        /// <returns>IWebElement.</returns>
        public IWebElement FindElements(string field, GeneralActions.FindBy fb, out string errOut, string sendText = "")
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.FindElements(field, fb, GeneralActions.MyAction.Nothing, out errOut, sendText);
        }
        /// <summary>
        /// Gets the contents of tag.  If you ask for the <br/>
        /// Body tag it will return only the text of the entire webpage.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string GetContentsOfTag(string name)
        {
            Ga.Driver = _driver;
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
            Ga.Driver = _driver;
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
            Ga.Driver = _driver;
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
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.LinkIsPresentById(name, out errOut);
        }

        /// <summary>
        /// Gets the link from element.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetLinkFromElement(string name, out string errOut)
        {
            return Ga.GetLinkFromElement(name, out errOut);
        }

        /// <summary>
        /// Gets the text from element by identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementById(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementById(name, out errOut);
        }
        /// <summary>
        /// Gets the text from element by x path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByXPath(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByXPath(name, out errOut);
        }
        /// <summary>
        /// Gets the text from element by link text.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByLinkText(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByLinkText(name, out errOut);
        }
        /// <summary>
        /// Gets the text from element by partial link text.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByPartialLinkText(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByPartialLinkText(name, out errOut);
        }
        /// <summary>
        /// Gets the text from element by CSS selector.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByCssSelector(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByCssSelector(name, out errOut);
        }
        /// <summary>
        /// Gets the name of the text from element by tag.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByTagName(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByTagName(name, out errOut);
        }
        /// <summary>
        /// Gets the name of the text from element by class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByClassName(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByClassName(name, out errOut);
        }
        /// <summary>
        /// Gets the name of the text from element by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElementByName(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElementByName(name, out errOut);
        }

        /// <summary>
        /// Well attempt to get the value from the xpath, id, classname, cssSelector if the string keeps returning null.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public string GetTextFromElement(string name, out string errOut)
        {
            Ga.Driver = _driver;
            Ga.TestName = TestName;
            return Ga.GetTextFromElement(name, out errOut);
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
        /// Runs the batch commands.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        /// <example>
        /// This is an example from the unit test <br/>
        /// <br/>
        /// Ca.TestName = "PublicUIBatch";<br/>
        /// string softwareMenu = "//ul[@id='jetmenu']/li[3]/a";<br/>
        /// List&lt;BatchCommandList&gt; cmd = new List&lt;BatchCommandList&gt;();<br/>
        /// cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, UseCommand = GeneralActions.UseCommand.WaitFound,
        ///         ElementName = softwareMenu, FindBy = GeneralActions.FindBy.XPath, TestName = @"Click On Windows App Menu"
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "My Gun Collection", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = "Click on the My Gun Collection link" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = softwareMenu, <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = @"Click On Windows App Menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "My Loaders Log", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = @"Click on the My Loaders Log Link" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = softwareMenu, <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = @"Click On Windows App Menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "File Renamer Utility", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = "Click on the File Renamer Utility" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = softwareMenu, <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = @"Click On Windows App Menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "BurnPad", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = "Click on BurnPad Link" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "//ul[@id='jetmenu']/li[7]/a", <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = "Click on Support Menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "Contact", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = "Select Contact Option from menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.SendKeys, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "MainContent_txtName", <br/>
        ///         FindBy = GeneralActions.FindBy.Id, <br/>
        ///         SendKeys = "Jimmy Pop Corn Batch", <br/>
        ///         TestName = "Send Name to Text Box" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.SendKeys, <br/>
        ///         UseCommand = GeneralActions.UseCommand.Find, <br/>
        ///         ElementName = "MainContent_txteMail", <br/>
        ///         FindBy = GeneralActions.FindBy.Id, <br/>
        ///         SendKeys = "joe.mireles@burnsoft.net", <br/>
        ///         TestName = "Send email to text box" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.SendKeys, <br/>
        ///         UseCommand = GeneralActions.UseCommand.Find, <br/>
        ///         ElementName = "MainContent_txtMsg", <br/>
        ///         FindBy = GeneralActions.FindBy.Id, <br/>
        ///         SendKeys = "Make Software Great Again in Batch", <br/>
        ///         TestName = "Send the message to the text box" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.Find, <br/>
        ///         ElementName = "MainContent_btnSend", <br/>
        ///         FindBy = GeneralActions.FindBy.Id, <br/>
        ///         TestName = "Click on the send button" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Nothing, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "MainContent_Label4", <br/>
        ///         FindBy = GeneralActions.FindBy.Id, <br/>
        ///         TestName = "Wait for response label" <br/>
        ///     }); <br/>
        ///  <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = softwareMenu, <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = @"Click On Windows App Menu" <br/>
        ///     }); <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Click, <br/>
        ///         UseCommand = GeneralActions.UseCommand.WaitFound, <br/>
        ///         ElementName = "My Gun Collection", <br/>
        ///         FindBy = GeneralActions.FindBy.LinkText, <br/>
        ///         TestName = "Click on the My Gun Collection link" <br/>
        ///     }); <br/>
        ///  <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Nothing, <br/>
        ///         UseCommand = GeneralActions.UseCommand.GetTextValue, <br/>
        ///         ElementName = "//h3/span", <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = "Get Price of My Gun Collector Software" <br/>
        ///     }); <br/>
        ///  <br/>
        ///     cmd.Add(new BatchCommandList() <br/>
        /// { <br/>
        ///     Actions = GeneralActions.MyAction.Nothing, <br/>
        ///         UseCommand = GeneralActions.UseCommand.GetTextValueAndCompare, <br/>
        ///         ElementName = "//h3/span", <br/>
        ///         FindBy = GeneralActions.FindBy.XPath, <br/>
        ///         TestName = "Get Price of My Gun Collector Software and Compare to exptected Version", <br/>
        ///         ExpectedReturnedValue = "$29.99" <br/>
        ///     }); <br/>
        ///  <br/>
        ///     List&lt;BatchCommandList&gt; value = Ca.RunBatchCommands(cmd, out var errOut); <br/>
        ///  <br/>
        /// int testNumber = 1; <br/>
        ///     foreach (BatchCommandList v in value) <br/>
        ///     { <br/>
        ///         string passfailed = v.PassedFailed ? "PASSED" : "FAILED"; <br/>
        /// TestContext.WriteLine($"{testNumber}.) {passfailed} - {v.TestName}"); <br/>
        ///         TestContext.WriteLine(v.ReturnedValue); <br/>
        ///         testNumber++; <br/>
        ///     } <br/>
        /// </example>
        public List<BatchCommandList> RunBatchCommands(List<BatchCommandList> cmd, out string errOut)
        {
            return Ga.RunBatchCommands(cmd, out errOut);
        }
        /// <summary>
        /// Works through the results of the Batch Command list and looks to see if any of the tests where marked as failed,
        /// if some show up as failed then it will return false, else everything passed and it is true.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public bool AllTestsPassed(List<BatchCommandList> results)
        {
            return Ga.AllTestsPassed(results);
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
            return Ga.GenerateResults(cmdResults, out errOut);
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
        /// Gets the item back ground color by CSS Element link.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="cssValue">The CSS value.  By default it will look for background-color, but you can change that to what ever css value you need</param>
        /// <returns>System.String.</returns>
        public string GetItemBackGroundColorByCss(string elementName, out string errOut,
            string cssValue = "background-color")
        {
            return Ga.GetItemBackGroundColorByCss(elementName, out errOut, cssValue);
        }
        /// <summary>
        /// Gets the item back ground color by x path.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="cssValue">The CSS value.  By default it will look for background-color, but you can change that to what ever css value you need</param>
        /// <returns>System.String.</returns>
        public string GetItemBackGroundColorByXPath(string elementName, out string errOut,
            string cssValue = "background-color")
        {
            return Ga.GetItemBackGroundColorByXPath(elementName, out errOut, cssValue);
        }
        /// <summary>
        /// Gets the item back ground color by identifier.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="cssValue">The CSS value.  By default it will look for background-color, but you can change that to what ever css value you need</param>
        /// <returns>System.String.</returns>
        public string GetItemBackGroundColorById(string elementName, out string errOut,
            string cssValue = "background-color")
        {
            return Ga.GetItemBackGroundColorById(elementName, out errOut, cssValue);
        }
        /// <summary>
        /// Gets the item back ground color by link text.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="cssValue">The CSS value.  By default it will look for background-color, but you can change that to what ever css value you need</param>
        /// <returns>System.String.</returns>
        public string GetItemBackGroundColorByLinkText(string elementName, out string errOut,
            string cssValue = "background-color")
        {
            return Ga.GetItemBackGroundColorByLinkText(elementName, out errOut, cssValue);
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
        ~ChromeActions()
        {
            Dispose(false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        public ChromeActions()
        {
            ScreenShotLocation = new List<string>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromeActions"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public ChromeActions(string url)
        {
            Url = url;
            ScreenShotLocation = new List<string>();
        }
    }
}
