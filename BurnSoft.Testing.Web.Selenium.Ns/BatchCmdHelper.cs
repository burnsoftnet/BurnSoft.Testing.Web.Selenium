using System.Collections.Generic;
using BurnSoft.Testing.Web.Selenium.Ns.Types;

// ReSharper disable UnusedMember.Global

namespace BurnSoft.Testing.Web.Selenium.Ns
{
    /// <summary>
    /// Class BatchCmdHelper. A simpified verstion to add commands to the batch command list
    /// </summary>
    public class BatchCmdHelper
    {
        /// <summary>
        /// Clicks the on element., Just pass the basic name and the verification option switch will
        /// tag on Click on or Verify to the main test name, by default we are looking for xpath, but you can change that.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="name">The name.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="verify">if set to <c>true</c> [verify].</param>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public static List<BatchCommandList> ClickOnElement(string element, string name,
            GeneralActions.FindBy fb = GeneralActions.FindBy.XPath, bool verify = false)
        {
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            GeneralActions.MyAction action = verify ? GeneralActions.MyAction.Nothing : GeneralActions.MyAction.Click;
            string testName = verify ? $"Verify {name}" : $"Click On {name}";
            cmd.Add(new BatchCommandList()
            {
                Actions = action,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                ElementName = element,
                FindBy = fb,
                TestName = testName
            });
            return cmd;
        }
        /// <summary>
        /// Sets the text box.Just pass the basic name and the verification option switch will
        /// tag on Click on or Verify to the main test name, by default we are looking for xpath, but you can change that.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="name">The name.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="fb">The fb.</param>
        /// <param name="verify">if set to <c>true</c> [verify].</param>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public static List<BatchCommandList> SetTextBox(string element, string name,string newValue,
            GeneralActions.FindBy fb = GeneralActions.FindBy.XPath, bool verify = false)
        {
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            GeneralActions.MyAction action = verify ? GeneralActions.MyAction.Nothing : GeneralActions.MyAction.Click;
            string testName = verify ? $"Verify {name}" : $"Set {name} to {newValue}";
            cmd.Add(new BatchCommandList()
            {
                FindBy = fb,
                Actions = action,
                TestName = testName,
                ElementName = element,
                UseCommand = GeneralActions.UseCommand.WaitFound,
                SendKeys = newValue

            });
            return cmd;
        }
        /// <summary>
        /// Gets the link and go to.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="name">The name.</param>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public static List<BatchCommandList> GetLinkAndGoTo(string element, string name)
        {
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            cmd.Add(new BatchCommandList()
            {
                UseCommand = GeneralActions.UseCommand.GetUrlAndGoTo,
                ElementName = element,
                TestName = name
            });
            return cmd;
        }

        /// <summary>
        /// Sleep for half a second
        /// </summary>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public static List<BatchCommandList> Sleep500()
        {
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            cmd.Add(new BatchCommandList()
            {
                SleepInterval = 500,
                UseCommand = GeneralActions.UseCommand.Sleep
            });

            return cmd;
        }
        /// <summary>
        /// Sleep for 1 second
        /// </summary>
        /// <returns>List&lt;BatchCommandList&gt;.</returns>
        public static List<BatchCommandList> Sleep(int useInterval = 1000)
        {
            List<BatchCommandList> cmd = new List<BatchCommandList>();
            cmd.Add(new BatchCommandList()
            {
                SleepInterval = useInterval,
                UseCommand = GeneralActions.UseCommand.Sleep
            });

            return cmd;
        }
    }
}
