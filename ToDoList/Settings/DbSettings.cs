using System;
using System.Configuration.Provider;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace ToDoList.Settings
{
    internal sealed class DbSettings
    {
        private readonly static string pathToDb = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "//Data")) + "\\Db.mdf;";

        private readonly static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=" + pathToDb + "; Integrated Security=True; Connect Timeout=30;Encrypt = False;";

        internal static string ConnectionString { get { return connectionString; } }
    }
}