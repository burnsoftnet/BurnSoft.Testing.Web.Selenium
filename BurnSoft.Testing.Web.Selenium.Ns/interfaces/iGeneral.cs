
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMemberInSuper.Global
// ReSharper disable UnusedMember.Global
namespace BurnSoft.Testing.Web.Selenium.Ns.interfaces
{
    /// <summary>
    /// Interface iGeneral
    /// </summary>
    internal interface iGeneral
    {
        /// <summary>
        /// Gets or sets the ga.
        /// </summary>
        /// <value>The ga.</value>
        GeneralActions Ga { get; set; }
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        int _sleepInterval { get; set; }
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        int SleepInterval { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        string Url { get; set; }
        /// <summary>
        /// Gets or sets the settings screen shot location.
        /// </summary>
        /// <value>The settings screen shot location.</value>
        string SettingsScreenShotLocation { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [do sleep].
        /// </summary>
        /// <value><c>true</c> if [do sleep]; otherwise, <c>false</c>.</value>
        bool DoSleep { get; set; }
        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        string TestName { get; set; }
        /// <summary>
        /// Initializers this instance.
        /// </summary>
        void Initializer();
        /// <summary>
        /// Screens the shot it.
        /// </summary>
        void ScreenShotIt();
        /// <summary>
        /// Goes to another page.
        /// </summary>
        /// <param name="url">The URL.</param>
        void GoToAnotherPage(string url);
        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma">The ma.</param>
        /// <param name="sendText">The send text.</param>
        void FindElements(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma, string sendText = "");
        /// <summary>
        /// Selects the element in page.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="textToSelect">The text to select.</param>
        void SelectElementInPage(string field, GeneralActions.FindBy fb, string textToSelect);
        /// <summary>
        /// Waits the till element found.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="ma">The ma.</param>
        /// <param name="sendKeys">The send keys.</param>
        void WaitTillElementFound(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma,
            string sendKeys = "");
        /// <summary>
        /// Does the wait.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="fb">The fb.</param>
        void DoWait(string field, GeneralActions.FindBy fb);

    }
}
