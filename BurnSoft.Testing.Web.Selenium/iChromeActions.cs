// ReSharper disable InconsistentNaming

namespace BurnSoft.Testing.Web.Selenium
{
    /// <summary>
    /// Interface iChromeActions
    /// </summary>
    public interface iChromeActions
    {
        /// <summary>
        /// Access Selenium Chrome Actions Class
        /// </summary>
        ChromeActions Ca { get; set; }

        /// <summary>
        /// Gets or sets the main URL.
        /// </summary>
        /// <value>The main URL.</value>
        string MainUrl { get; set; }
        /// <summary>
        /// Gets or sets the usr login.
        /// </summary>
        /// <value>The usr login.</value>
        string UsrLogin { get; set; }
        /// <summary>
        /// Gets or sets the usr password.
        /// </summary>
        /// <value>The usr password.</value>
        string UsrPwd { get; set; }
        /// <summary>
        /// The settings screen shot location
        /// </summary>
        string SettingsScreenShotLocation { get; set; }
        /// <summary>
        /// The full exception path
        /// </summary>
        string FullExceptionPath { get; set; }
        /// <summary>
        /// Gets or sets the pages login.
        /// </summary>
        /// <value>The pages login.</value>
        string PagesLogin { get; set; }
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        void LogIn(string testName);

        /// <summary>
        /// Logs the out.
        /// </summary>
        void LogOut();

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();
    }
}
