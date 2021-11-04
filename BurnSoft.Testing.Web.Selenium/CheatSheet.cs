

// ReSharper disable UnusedMember.Local
namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Private class for documentation based on the Most Complete Selenium WebDriver C# Cheat Sheet @ https://www.automatetheplanet.com/selenium-webdriver-csharp-cheat-sheet/
    /// </summary>
    class CheatSheet
    {
        /// <summary>
        /// <h1>Initialize</h1> <br/>
        /// <br/>
        /// //NuGet: Selenium.WebDriver.ChromeDriver <br/>
        /// using OpenQA.Selenium.Chrome; <br/>
        /// IWebDriver driver = new ChromeDriver(); <br/>
        /// // NuGet: Selenium.Mozilla.Firefox.Webdriver <br/>
        /// using OpenQA.Selenium.Firefox; <br/>
        /// IWebDriver driver = new FirefoxDriver(); <br/>
        /// // NuGet: Selenium.WebDriver.PhantomJS <br/>
        /// using OpenQA.Selenium.PhantomJS; <br/>
        /// IWebDriver driver = new PhantomJSDriver(); <br/>
        /// // NuGet: Selenium.WebDriver.IEDriver <br/>
        /// using OpenQA.Selenium.IE; <br/>
        /// IWebDriver driver = new InternetExplorerDriver(); <br/>
        /// // NuGet: Selenium.WebDriver.EdgeDriver <br/>
        /// using OpenQA.Selenium.Edge; <br/>
        /// IWebDriver driver = new EdgeDriver(); <br/>
        /// <br/>
        ///<h1>Locators</h1> <br/>
        /// <br/>
        /// this.driver.FindElement(By.ClassName("className")); <br/>
        /// this.driver.FindElement(By.CssSelector("css")); <br/>
        /// this.driver.FindElement(By.Id("id")); <br/>
        /// this.driver.FindElement(By.LinkText("text")); <br/>
        /// this.driver.FindElement(By.Name("name")); <br/>
        /// this.driver.FindElement(By.PartialLinkText("pText")); <br/>
        /// this.driver.FindElement(By.TagName("input")); <br/>
        /// this.driver.FindElement(By.XPath("//*[@id='editor']")); <br/>
        /// // Find multiple elements <br/>
        /// IReadOnlyCollection&lt;IWebElement&gt; anchors = this.driver.FindElements(By.TagName("a")); <br/>
        /// // Search for an element inside another <br/>
        /// var div = this.driver.FindElement(By.TagName("div")).FindElement(By.TagName("a")); <br/>
        /// <br/>
        /// <h1>Basic Elements Operations</h1> <br/>
        /// <br/>
        /// IWebElement element = driver.FindElement(By.Id("id")); <br/>
        /// element.Click(); <br/>
        /// element.SendKeys("someText"); <br/>
        /// element.Clear(); <br/>
        /// element.Submit(); <br/>
        /// string innerText = element.Text; <br/>
        /// bool isEnabled = element.Enabled; <br/>
        /// bool isDisplayed = element.Displayed; <br/>
        /// bool isSelected = element.Selected; <br/>
        /// IWebElement element = driver.FindElement(By.Id("id")); <br/>
        /// SelectElement select = new SelectElement(element); <br/>
        /// select.SelectByIndex(1); <br/>
        /// select.SelectByText("Ford"); <br/>
        /// select.SelectByValue("ford"); <br/>
        /// select.DeselectAll(); <br/>
        /// select.DeselectByIndex(1); <br/>
        /// select.DeselectByText("Ford"); <br/>
        /// select.DeselectByValue("ford"); <br/>
        /// IWebElement selectedOption = select.SelectedOption; <br/>
        /// IList&lt;IWebElement&gt; allSelected = select.AllSelectedOptions; <br/>
        /// bool isMultipleSelect = select.IsMultiple; <br/>
        /// <br/>
        /// <h1>Advanced Elements Operations</h1> <br/>
        /// <br/>
        /// // Drag and Drop <br/>
        /// IWebElement element = <br/>
        /// /// driver.FindElement(By.XPath("//*[@id='project']/p[1]/div/div[2]")); &lt;br/&gt;
        /// /// Actions move = new Actions(driver); &lt;br/&gt;
        /// /// move.DragAndDropToOffset(element, 30, 0).Perform(); &lt;br/&gt;
        /// /// // How to check if an element is visible &lt;br/&gt;
        /// /// Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='tve_editor']/div")).Displayed); &lt;br/&gt;
        /// /// // Upload a file &lt;br/&gt;
        /// /// IWebElement element = driver.FindElement(By.Id("RadUpload1file0")); &lt;br/&gt;
        /// /// String filePath = @"D:WebDriver.Series.TestsWebDriver.xml"; &lt;br/&gt;
        /// /// element.SendKeys(filePath); &lt;br/&gt;
        /// /// // Scroll focus to control &lt;br/&gt;
        /// /// IWebElement link = driver.FindElement(By.PartialLinkText("Previous post")); &lt;br/&gt;
        /// /// string js = string.Format("window.scroll(0, {0});", link.Location.Y); &lt;br/&gt;
        /// /// ((IJavaScriptExecutor)driver).ExecuteScript(js); &lt;br/&gt;
        /// /// link.Click(); &lt;br/&gt;
        /// /// // Taking an element screenshot &lt;br/&gt;
        /// /// IWebElement element = driver.FindElement(By.XPath("//*[@id='tve_editor']/div")); &lt;br/&gt;
        /// /// var cropArea = new Rectangle(element.Location, element.Size); &lt;br/&gt;
        /// /// var bitmap = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat); &lt;br/&gt;
        /// /// bitmap.Save(fileName); &lt;br/&gt;
        /// /// // Focus on a control &lt;br/&gt;
        /// /// IWebElement link = driver.FindElement(By.PartialLinkText("Previous post")); &lt;br/&gt;
        /// /// // Wait for visibility of an element &lt;br/&gt;
        /// /// WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); &lt;br/&gt;
        /// /// wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy( &lt;br/&gt;
        /// /// By.XPath("//*[@id='tve_editor']/div[2]/div[2]/div/div"))); &lt;br/&gt;
        /// /// &lt;br/&gt;
        /// /// &lt;h1&gt;Basic Browser Operations&lt;/h1&gt; &lt;br/&gt;
        /// /// &lt;br/&gt;
        /// /// // Navigate to a page  &lt;br/&gt;
        /// /// this.driver.Navigate().GoToUrl(@"http://google.com"); &lt;br/&gt;
        /// /// // Get the title of the page &lt;br/&gt;
        /// /// string title = this.driver.Title; &lt;br/&gt;
        /// /// // Get the current URL &lt;br/&gt;
        /// /// string url = this.driver.Url; &lt;br/&gt;
        /// /// // Get the current page HTML source &lt;br/&gt;
        /// /// string html = this.driver.PageSource; &lt;br/&gt;
        /// /// &lt;br/&gt;
        /// /// &lt;h1&gt;Advanced Browser Operations&lt;/h1&gt; &lt;br/&gt;
        /// /// &lt;br/&gt;
        /// /// // Handle JavaScript pop-ups &lt;br/&gt;
        /// ///        IAlert a = driver.SwitchTo().Alert(); &lt;br/&gt;
        /// ///        a.Accept(); &lt;br/&gt;
        /// ///        a.Dismiss(); &lt;br/&gt;
        /// /// // Switch between browser windows or tabs &lt;br/&gt;
        /// ///        ReadOnlyCollection&lt;string&gt; windowHandles = driver.WindowHandles; &lt;br/&gt;
        /// ///        string firstTab = windowHandles.First(); &lt;br/&gt;
        /// ///        string lastTab = windowHandles.Last(); &lt;br/&gt;
        /// ///        driver.SwitchTo().Window(lastTab); &lt;br/&gt;
        /// /// // Navigation history &lt;br/&gt;
        /// ///            this.driver.Navigate().Back(); &lt;br/&gt;
        /// ///            this.driver.Navigate().Refresh(); &lt;br/&gt;
        /// ///            this.driver.Navigate().Forward(); &lt;br/&gt;
        /// ///        // Option 1. &lt;br/&gt;
        /// ///        link.SendKeys(string.Empty); &lt;br/&gt;
        /// /// // Option 2. &lt;br/&gt;
        /// ///        ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].focus();", link); &lt;br/&gt;
        /// /// // Maximize window &lt;br/&gt;
        /// ///        this.driver.Manage().Window.Maximize(); &lt;br/&gt;
        /// /// // Add a new cookie &lt;br/&gt;
        /// ///        Cookie cookie = new OpenQA.Selenium.Cookie("key", "value"); &lt;br/&gt;
        /// ///            this.driver.Manage().Cookies.AddCookie(cookie); &lt;br/&gt;
        /// /// // Get all cookies &lt;br/&gt;
        /// ///         var cookies = this.driver.Manage().Cookies.AllCookies; &lt;br/&gt;
        /// /// // Delete a cookie by name &lt;br/&gt;
        /// ///             this.driver.Manage().Cookies.DeleteCookieNamed("CookieName"); &lt;br/&gt;
        /// /// // Delete all cookies &lt;br/&gt;
        /// ///         this.driver.Manage().Cookies.DeleteAllCookies(); &lt;br/&gt;
        /// /// //Taking a full-screen screenshot &lt;br/&gt;
        /// ///         Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot(); &lt;br/&gt;
        /// ///         screenshot.SaveAsFile(@"pathToImage", ImageFormat.Png); &lt;br/&gt;
        /// /// // Wait until a page is fully loaded via JavaScript &lt;br/&gt;
        /// ///        WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30)); &lt;br/&gt;
        /// ///        wait.Until((x) =&gt; &lt;br/&gt;
        /// ///        { &lt;br/&gt;
        /// ///            return ((IJavaScriptExecutor)this.driver).ExecuteScript("return document.readyState").Equals("complete"); &lt;br/&gt;
        /// ///        }); &lt;br/&gt;
        /// /// // Switch to frames &lt;br/&gt;
        /// ///        this.driver.SwitchTo().Frame(1); &lt;br/&gt;
        /// ///    this.driver.SwitchTo().Frame("frameName"); &lt;br/&gt;
        /// ///    IWebElement element = this.driver.FindElement(By.Id("id")); &lt;br/&gt;
        /// ///    this.driver.SwitchTo().Frame(element); &lt;br/&gt;
        /// /// // Switch to the default document &lt;br/&gt;
        /// ///    this.driver.SwitchTo().DefaultContent(); &lt;br/&gt;
        /// ///  &lt;br/&gt;
        /// &lt;h1&gt;Advanced Browser Configurations&lt;/h1&gt; &lt;br/&gt;
        /// /// &lt;br/&gt;
        /// /// // Use a specific Firefox profile &lt;br/&gt;
        /// /// FirefoxProfileManager profileManager = new FirefoxProfileManager(); &lt;br/&gt;
        /// /// FirefoxProfile profile = profileManager.GetProfile("HARDDISKUSER"); &lt;br/&gt;
        /// /// IWebDriver driver = new FirefoxDriver(profile); &lt;br/&gt;
        /// /// // Set a HTTP proxy Firefox &lt;br/&gt;
        /// /// FirefoxProfile firefoxProfile = new FirefoxProfile(); &lt;br/&gt;
        /// /// firefoxProfile.SetPreference("network.proxy.type", 1); &lt;br/&gt;
        /// /// firefoxProfile.SetPreference("network.proxy.http", "myproxy.com"); &lt;br/&gt;
        /// /// firefoxProfile.SetPreference("network.proxy.http_port", 3239); &lt;br/&gt;
        /// /// IWebDriver driver = new FirefoxDriver(firefoxProfile); &lt;br/&gt;
        /// /// // Set a HTTP proxy Chrome &lt;br/&gt;
        /// /// ChromeOptions options = new ChromeOptions(); &lt;br/&gt;
        /// /// var proxy = new Proxy(); &lt;br/&gt;
        /// /// proxy.Kind = ProxyKind.Manual; &lt;br/&gt;
        /// /// proxy.IsAutoDetect = false; &lt;br/&gt;
        /// /// proxy.HttpProxy = &lt;br/&gt;
        /// /// proxy.SslProxy = "127.0.0.1:3239"; &lt;br/&gt;
        /// /// options.Proxy = proxy; &lt;br/&gt;
        /// /// options.AddArgument("ignore-certificate-errors"); &lt;br/&gt;
        /// /// IWebDriver driver = new ChromeDriver(options); &lt;br/&gt;
        /// /// // Accept all certificates Firefox v
        /// /// FirefoxProfile firefoxProfile = new FirefoxProfile(); &lt;br/&gt;
        /// /// firefoxProfile.AcceptUntrustedCertificates = true; &lt;br/&gt;
        /// /// firefoxProfile.AssumeUntrustedCertificateIssuer = false; &lt;br/&gt;
        /// /// IWebDriver driver = new FirefoxDriver(firefoxProfile); &lt;br/&gt;
        /// /// // Accept all certificates Chrome  &lt;br/&gt;
        /// /// DesiredCapabilities capability = DesiredCapabilities.Chrome(); &lt;br/&gt;
        /// /// Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:PathToChromeDriver.exe"); &lt;br/&gt;
        /// /// capability.SetCapability(CapabilityType.AcceptSslCertificates, true); &lt;br/&gt;
        /// /// IWebDriver driver = new RemoteWebDriver(capability); &lt;br/&gt;
        /// /// // Set Chrome options. &lt;br/&gt;
        /// /// ChromeOptions options = new ChromeOptions(); &lt;br/&gt; &lt;br/&gt;
        /// /// DesiredCapabilities dc = DesiredCapabilities.Chrome(); &lt;br/&gt;
        /// /// dc.SetCapability(ChromeOptions.Capability, options); &lt;br/&gt;
        /// /// IWebDriver driver = new RemoteWebDriver(dc); &lt;br/&gt;
        /// /// // Turn off the JavaScript Firefox &lt;br/&gt;
        /// /// FirefoxProfileManager profileManager = new FirefoxProfileManager(); &lt;br/&gt;
        /// /// FirefoxProfile profile = profileManager.GetProfile("HARDDISKUSER"); &lt;br/&gt;
        /// /// profile.SetPreference("javascript.enabled", false); &lt;br/&gt;
        /// /// IWebDriver driver = new FirefoxDriver(profile); &lt;br/&gt;
        /// /// // Set the default page load timeout &lt;br/&gt;
        /// /// driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(10)); &lt;br/&gt;
        /// /// // Start Firefox with plugins &lt;br/&gt;
        /// /// FirefoxProfile profile = new FirefoxProfile(); &lt;br/&gt;
        /// /// profile.AddExtension(@"C:extensionsLocationextension.xpi"); &lt;br/&gt;
        /// /// IWebDriver driver = new FirefoxDriver(profile); &lt;br/&gt;
        /// /// // Start Chrome with an unpacked extension &lt;br/&gt;
        /// /// ChromeOptions options = new ChromeOptions(); &lt;br/&gt;
        /// /// options.AddArguments("load-extension=/pathTo/extension"); &lt;br/&gt;
        /// /// DesiredCapabilities capabilities = new DesiredCapabilities(); &lt;br/&gt;
        /// /// capabilities.SetCapability(ChromeOptions.Capability, options); &lt;br/&gt;
        /// /// DesiredCapabilities dc = DesiredCapabilities.Chrome(); &lt;br/&gt;
        /// /// dc.SetCapability(ChromeOptions.Capability, options); &lt;br/&gt;
        /// /// IWebDriver driver = new RemoteWebDriver(dc); &lt;br/&gt;
        /// /// // Start Chrome with a packed extension &lt;br/&gt;
        /// /// ChromeOptions options = new ChromeOptions(); &lt;br/&gt;
        /// /// options.AddExtension(Path.GetFullPath("localpathto/extension.crx")); &lt;br/&gt;
        /// /// DesiredCapabilities capabilities = new DesiredCapabilities(); &lt;br/&gt;
        /// /// capabilities.SetCapability(ChromeOptions.Capability, options); &lt;br/&gt;
        /// /// DesiredCapabilities dc = DesiredCapabilities.Chrome(); &lt;br/&gt;
        /// /// dc.SetCapability(ChromeOptions.Capability, options); &lt;br/&gt;
        /// /// IWebDriver driver = new RemoteWebDriver(dc); &lt;br/&gt;
        /// /// // Change the default files’ save location &lt;br/&gt;
        /// /// String downloadFolderPath = @"c:temp"; &lt;br/&gt;
        /// /// FirefoxProfile profile = new FirefoxProfile(); &lt;br/&gt;
        /// /// profile.SetPreference("browser.download.folderList", 2); &lt;br/&gt;
        /// /// profile.SetPreference("browser.download.dir", downloadFolderPath); &lt;br/&gt;
        /// /// profile.SetPreference("browser.download.manager.alertOnEXEOpen", false); &lt;br/&gt;
        /// /// profile.SetPreference("browser.helperApps.neverAsk.saveToDisk",  &lt;br/&gt; 
        /// /// "application/msword, application/binary, application/ris, text/csv, image/png, application/pdf,  &lt;br/&gt;
        /// /// text/html, text/plain, application/zip, application/x-zip, application/x-zip-compressed, application/download, &lt;br/&gt;
        /// /// application/octet-stream");&lt;br/&gt;
        /// /// this.driver = new FirefoxDriver(profile);&lt;br/&gt;
        /// 
        /// </summary>
        private void Article()
        {
            
        }
    }
}
