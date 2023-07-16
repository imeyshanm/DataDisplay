using DataAccess;
using DataDisplay.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace DataDisplay
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var IDataContexts = new DataContext(ConfigurationManager.ConnectionStrings["DataDisplay"].ConnectionString);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StudentList(IDataContexts));
        }
    }
}
