
namespace BurnSoft.Testing.Web.Selenium.Types
{
    /// <summary>
    /// Batch Command List to Run a List of Selnium commands and hold all the elements , values and commands
    /// </summary>
    public class BatchCommandList
    {
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

    }
}
