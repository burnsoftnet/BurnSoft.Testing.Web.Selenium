using System;
using System.Collections.Generic;
using System.IO;
using BurnSoft.Testing.Web.Selenium.Ns.Types;
using Newtonsoft.Json;

// ReSharper disable UseObjectOrCollectionInitializer

namespace BurnSoft.Testing.Web.Selenium.Ns
{
    /// <summary>
    /// Class SeleniumIde allows you to use the selnium IDE .side file to run tests in the back ground.
    /// </summary>
    public class SeleniumIde
    {
        /// <summary>
        /// Reads the selenium IDE file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>List&lt;SideFile&gt;.</returns>
        private static List<SideFile> ReadSeleniumIdeFile(string file)
        {
            string jsonData = File.ReadAllText(file);
            jsonData = $"[{jsonData}]";
            return JsonConvert.DeserializeObject<List<SideFile>>(jsonData);
        }
        /// <summary>
        /// Runs the selenium IDE file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="testName">Name of the test.</param>
        /// <param name="results">The results.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="Exception">ERROR!  There is no url set in the file or was unable to pull it from teh json file!</exception>
        /// <exception cref="Exception"></exception>
        public static bool RunSeleniumIdeFile(string file, string testName, out string results, out string errOut)
        {
            return RunSeleniumIdeFile(FlexAction.UseDriver.Chrome, file, testName, out results, out errOut);
        }
        /// <summary>
        /// The driver options
        /// </summary>
        public static List<string> DriverOptions = new List<string> { "Chrome", "Edge", "IE", "FireFox" };
        /// <summary>
        /// Strings to driver.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>FlexAction.UseDriver.</returns>
        public static FlexAction.UseDriver StringToDriver(string value)
        {
            FlexAction.UseDriver ud = FlexAction.UseDriver.Chrome;
            switch (value)
            {
                case "Chrome":
                    ud = FlexAction.UseDriver.Chrome;
                    break;
                case "Edge":
                    ud = FlexAction.UseDriver.Edge;
                    break;
                case "IE":
                    ud = FlexAction.UseDriver.IE;
                    break;
                case "FireFox":
                    ud = FlexAction.UseDriver.FireFox;
                    break;
            }

            return ud;
        }
        /// <summary>
        /// Runs the selenium IDE file.
        /// </summary>
        /// <param name="useDriver">The use driver.</param>
        /// <param name="file">The file.</param>
        /// <param name="testName">Name of the test.</param>
        /// <param name="results">The results.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception">ERROR!  There is no url set in the file or was unable to pull it from teh json file!</exception>
        /// <exception cref="System.Exception"></exception>
        public static bool RunSeleniumIdeFile(FlexAction.UseDriver useDriver, string file, string testName, out string results, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            results = @"";
            try
            {
                List<SideFile> myCommands = ReadSeleniumIdeFile(file);
                List<BatchCommandList> bCmd = new List<BatchCommandList>();

                string url = "";

                foreach (SideFile s in myCommands)
                {
                    url = s.url;
                    foreach (Test t in s.tests)
                    {
                        if (t.name.Equals(testName))
                        {
                            foreach (Command c in t.commands)
                            {
                                if (!c.command.Equals("open") && !c.command.Equals("setWindowSize") && !c.command.Equals("close"))
                                {
                                    string myTestName = c.comment.Length == 0 ? $"{c.command} on {c.target}" : c.comment;
                                    string cmd = @"";
                                    string sendKeys = c.value;
                                    GeneralActions.FindBy fb = GeneralActions.FindBy.Id;
                                    GeneralActions.MyAction ma = GeneralActions.MyAction.Click;

                                    if (c.target.StartsWith("id="))
                                    {
                                        fb = GeneralActions.FindBy.Id;
                                        cmd = c.target.Replace("id=", "");
                                    }
                                    else if (c.target.StartsWith("name="))
                                    {
                                        fb = GeneralActions.FindBy.Name;
                                        cmd = c.target.Replace("name=", "");
                                    }
                                    else if (c.target.StartsWith("css="))
                                    {
                                        fb = GeneralActions.FindBy.CssSelector;
                                        cmd = c.target.Replace("css=", "");
                                    }
                                    else if (c.target.StartsWith("xpath="))
                                    {
                                        fb = GeneralActions.FindBy.XPath;
                                        cmd = c.target.Replace("xpath=", "");
                                    }
                                    else if (c.target.StartsWith("linkText="))
                                    {
                                        fb = GeneralActions.FindBy.LinkText;
                                        cmd = c.target.Replace("linkText=", "");
                                    }

                                    switch (c.command)
                                    {
                                        case "click":
                                            ma = GeneralActions.MyAction.Click;
                                            break;
                                        case "type":
                                            ma = GeneralActions.MyAction.ClearSendKeys;
                                            break;
                                        case "sendKeys":
                                            ma = GeneralActions.MyAction.SendKeys;
                                            break;
                                            //case "":
                                            //    ma = GeneralActions.MyAction.Click;
                                            //    break;
                                            //case "":
                                            //    ma = GeneralActions.MyAction.Click;
                                            //    break;
                                            //case "":
                                            //    ma = GeneralActions.MyAction.Click;
                                            //    break;
                                    }

                                    bCmd.Add(new BatchCommandList()
                                    {
                                        TestName = myTestName,
                                        FindBy = fb,
                                        Actions = ma,
                                        UseCommand = GeneralActions.UseCommand.WaitFound,
                                        SendKeys = sendKeys,
                                        ElementName = cmd
                                    });

                                }

                            }
                        }
                    }
                }
                if (url.Length == 0) throw new Exception("ERROR!  There is no url set in the file or was unable to pull it from teh json file!");

                string settingsScreenShotLocation = "ExceptionShots";

                string fullExceptionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsScreenShotLocation);
                if (!Directory.Exists(fullExceptionPath)) Directory.CreateDirectory(fullExceptionPath);

                FlexAction sa = new FlexAction(useDriver);
                sa.DoSleep = true;
                sa.SettingsScreenShotLocation = fullExceptionPath;
                sa.Url = url;
                sa.TestName = testName;
                sa.Initializer();
                List<BatchCommandList> myResults = sa.RunBatchCommands(bCmd, out errOut);
                results = sa.GenerateResults(myResults, out errOut);
                if (errOut?.Length > 0) throw new Exception(errOut);
                bAns = sa.AllTestsPassed(myResults);
                sa.Close();
            }
            catch (Exception e)
            {
                errOut = e.Message;
            }
            return bAns;
        }
    }
}
