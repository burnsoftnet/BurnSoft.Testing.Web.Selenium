using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Testing.Web.Selenium.UnitTest.Settings
{
    public class VS2019
    {
        private static List<Tuple<string, string>> GeneralSettings()
        {
            List<Tuple<string,string>> ls = new List<Tuple<string, string>>();
            ls.Add(new Tuple<string, string>("url_main","http://www.burnsoft.test"));
            ls.Add(new Tuple<string, string>("url_login", "http://www.burnsoft.test/login.aspx"));
            ls.Add(new Tuple<string, string>("UsrLogin", ""));
            ls.Add(new Tuple<string, string>("UsrPwd", ""));
            ls.Add(new Tuple<string, string>("SettingsScreenShotLocation", $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ScreenShots")}"));
            //ls.Add(new Tuple<string, string>("", ""));
            //ls.Add(new Tuple<string, string>("", ""));
            return ls;
        }

        private static string GetSettings(string value)
        {
            string sAns = @"";
            List<Tuple<string,string>> ls = GeneralSettings();
            foreach (Tuple<string, string> l in ls)
            {
                if (l.Item1.Equals(value))
                {
                    sAns = l.Item2;
                    break;
                }
            }
            return sAns;
        }

        public static string GetSetting(string value) => GetSettings(value);
        public static int iGetSetting(string value) => Convert.ToInt32(GetSettings(value));
        public static double dGetSetting(string value) => Convert.ToDouble(GetSettings(value));
        public static bool bGetSetting(string value) => Convert.ToBoolean(GetSettings(value));
    }
}
