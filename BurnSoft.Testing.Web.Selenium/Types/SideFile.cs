using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace BurnSoft.Testing.Web.Selenium.Types
{
    /// <summary>
    /// Class SideFile.
    /// </summary>
    [Serializable]
    public class SideFile
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string version { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string url { get; set; }
        /// <summary>
        /// Gets or sets the tests.
        /// </summary>
        /// <value>The tests.</value>
        public List<Test> tests { get; set; }
        /// <summary>
        /// Gets or sets the suites.
        /// </summary>
        /// <value>The suites.</value>
        public List<Suite> suites { get; set; }
        /// <summary>
        /// Gets or sets the urls.
        /// </summary>
        /// <value>The urls.</value>
        public List<object> urls { get; set; }
        /// <summary>
        /// Gets or sets the plugins.
        /// </summary>
        /// <value>The plugins.</value>
        public List<object> plugins { get; set; }
    }
    //public class Root
    //{
    //    public string id { get; set; }
    //    public string version { get; set; }
    //    public string name { get; set; }
    //    public string url { get; set; }
    //    public List<Test> tests { get; set; }
    //    public List<Suite> suites { get; set; }
    //    public List<object> urls { get; set; }
    //    public List<object> plugins { get; set; }
    //}
    /// <summary>
    /// Class Command.
    /// </summary>
    [Serializable]
    public class Command
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string comment { get; set; }
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public string command { get; set; }
        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public string target { get; set; }
        /// <summary>
        /// Gets or sets the targets.
        /// </summary>
        /// <value>The targets.</value>
        public List<List<string>> targets { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
    }
    /// <summary>
    /// Class Test.
    /// </summary>
    [Serializable]
    public class Test
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>The commands.</value>
        public List<Command> commands { get; set; }
    }
    /// <summary>
    /// Class Suite.
    /// </summary>
    [Serializable]
    public class Suite
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [persist session].
        /// </summary>
        /// <value><c>true</c> if [persist session]; otherwise, <c>false</c>.</value>
        public bool persistSession { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Suite"/> is parallel.
        /// </summary>
        /// <value><c>true</c> if parallel; otherwise, <c>false</c>.</value>
        public bool parallel { get; set; }
        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public int timeout { get; set; }
        /// <summary>
        /// Gets or sets the tests.
        /// </summary>
        /// <value>The tests.</value>
        public List<string> tests { get; set; }
    }
}
