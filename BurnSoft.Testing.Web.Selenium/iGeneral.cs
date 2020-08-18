using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Testing.Web.Selenium
{
    internal interface iGeneral
    {
        GeneralActions Ga { get; set; }
        int _sleepInterval { get; set; }
        int SleepInterval { get; set; }
        string Url { get; set; }
        string SettingsScreenShotLocation { get; set; }
        bool DoSleep { get; set; }
        string TestName { get; set; }
        void Initializer();
        void ScreenShotIt();
        void GoToAnotherPage(string url);
        void FindElements(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma, string sendText = "");
        void SelectElementInPage(string field, GeneralActions.FindBy fb, string textToSelect);

        void WaitTillElementFound(string field, GeneralActions.FindBy fb, GeneralActions.MyAction ma,
            string sendKeys = "");

        void DoWait(string field, GeneralActions.FindBy fb);

    }
}
