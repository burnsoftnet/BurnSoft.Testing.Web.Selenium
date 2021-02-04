
namespace BurnSoft.Testing.Web.Selenium.Types
{
    /// <summary>
    /// Batch Command List to Run a List of Selnium commands and hold all the elements , values and commands
    /// </summary>
    public class BatchCommandList
    {
        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        public string TestName { get; set; }
        /// <summary>
        /// Fing By command, find by id, xpath, css, etc
        /// </summary>
        public GeneralActions.FindBy FindBy { get; set; }
        /// <summary>
        /// Action to perform, send command, click, nothing, etc.
        /// </summary>
        public GeneralActions.MyAction Actions { get; set; }
        /// <summary>
        /// Find, wait till found, wait, etc, performs the function to run
        /// </summary>
        public GeneralActions.UseCommand UseCommand { get; set; }
        /// <summary>
        /// Element Name
        /// </summary>
        public string ElementName { get; set; }
        /// <summary>
        /// Keys or text to send 
        /// </summary>
        public string SendKeys { get; set; }
        /// <summary>
        /// Gets or sets the jump to URL.
        /// </summary>
        /// <value>The jump to URL.</value>
        public string JumpToUrl { get; set; }
        /// <summary>
        /// Move slide x positions over + up, - down
        /// </summary>
        public int SliderMoveTo { get; set; }
        /// <summary>
        /// The slider max value
        /// </summary>
        public int SliderMax { get; set; }
        /// <summary>
        /// The slider min value.
        /// </summary>
        public int SliderMin { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [passed failed].
        /// </summary>
        /// <value><c>true</c> if [passed failed]; otherwise, <c>false</c>.</value>
        public bool PassedFailed { get; set; }
        /// <summary>
        /// Gets or sets the returned value.
        /// </summary>
        /// <value>The returned value.</value>
        public string ReturnedValue { get; set; }
        /// <summary>
        /// Gets or sets the expected returned value.
        /// </summary>
        /// <value>The expected returned value.</value>
        public string ExpectedReturnedValue { get; set; }
        /// <summary>
        /// Gets or sets the sleep interval.
        /// </summary>
        /// <value>The sleep interval.</value>
        public int SleepInterval { get; set; }

    }
}
