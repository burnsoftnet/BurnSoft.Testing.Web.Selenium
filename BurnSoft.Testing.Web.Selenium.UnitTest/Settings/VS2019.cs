﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace BurnSoft.Testing.Web.Selenium.UnitTest.Settings
{
    public class Vs2019
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vs2019"/> class.
        /// </summary>
        /// <param name="con">The con.</param>
        public Vs2019(TestContext con)
        {
            TestContext = con;
        }
        /// <summary>
        /// Generals the settings.
        /// </summary>
        /// <returns>List&lt;Tuple&lt;System.String, System.String&gt;&gt;.</returns>
        private static List<Tuple<string, string>> GeneralSettings()
        {
            List<Tuple<string,string>> ls = new List<Tuple<string, string>>();
            ls.Add(new Tuple<string, string>("url_main","http://www.burnsoft.net"));
            ls.Add(new Tuple<string, string>("url_login", "http://www.burnsoft.net/login.aspx"));
            ls.Add(new Tuple<string, string>("UsrLogin", ""));
            ls.Add(new Tuple<string, string>("UsrPwd", ""));
            ls.Add(new Tuple<string, string>("SettingsScreenShotLocation", $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ScreenShots")}"));
            ls.Add(new Tuple<string, string>("SIDE_FileName", $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "burnsoft.side")}"));
            ls.Add(new Tuple<string, string>("SIDE_TestName", "MGC"));
            //ls.Add(new Tuple<string, string>("", ""));
            //ls.Add(new Tuple<string, string>("", ""));
            return ls;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        private static string GetSettings(string value)
        {
            string sAns = @"";
            List<Tuple<string, string>> ls = GeneralSettings();
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
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.String.</returns>
        private static string GetSettings(string value, TestContext con)
        {
            string sAns;

            Vs2019 obj = new Vs2019(con);
            if (obj.TestSettingsLoaded(value))
            {
                sAns = con.Properties[value].ToString();
            }
            else
            {
                sAns = GetSetting(value);
            }

            return sAns;
        }
        /// <summary>
        /// Tests the settings loaded.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool TestSettingsLoaded(string property)
        {
            bool bAns = false;
            try
            {
                if (TestContext != null)
                {
                    if (TestContext.Properties[property] != null)
                    {
                        string value = TestContext.Properties[property].ToString();
                        bAns = value.Length > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetSetting(string value) => GetSettings(value);
        /// <summary>
        /// is the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int IGetSetting(string value) => Convert.ToInt32(GetSettings(value));
        /// <summary>
        /// ds the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Double.</returns>
        public static double DGetSetting(string value) => Convert.ToDouble(GetSettings(value));
        /// <summary>
        /// bs the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool BGetSetting(string value) => Convert.ToBoolean(GetSettings(value));
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.String.</returns>
        public static string GetSetting(string value, TestContext con) => GetSettings(value, con);
        /// <summary>
        /// is the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.Int32.</returns>
        public static int IGetSetting(string value, TestContext con) => Convert.ToInt32(GetSettings(value, con));
        /// <summary>
        /// ds the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.Double.</returns>
        public static double DGetSetting(string value, TestContext con) => Convert.ToDouble(GetSettings(value, con));
        /// <summary>
        /// bs the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool BGetSetting(string value, TestContext con) => Convert.ToBoolean(GetSettings(value, con));
    }
}
