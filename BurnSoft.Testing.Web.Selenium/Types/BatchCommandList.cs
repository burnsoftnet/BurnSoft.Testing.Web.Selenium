using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Testing.Web.Selenium.Types
{
    public class BatchCommandList
    {
        public GeneralActions.FindBy FindBy { get; set; }
        public GeneralActions.MyAction Actions { get; set; }
        public GeneralActions.UseCommand UseCommand { get; set; }
        public string ElementName { get; set; }
        public string SendKeys { get; set; }
        public int SliderMoveTo { get; set; }
        public int SliderMax { get; set; }
        public int SliderMin { get; set; }

    }
}
