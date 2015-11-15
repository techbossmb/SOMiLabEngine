using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CVE_ExperimentEngine
{
    class EngineConfiguration
    {
        public static string connectionString
        {
            get{ return ConfigurationManager.AppSettings["databaseConnection"]; }
        }

        public static double pollingInterval
        {
            get { return double.Parse(ConfigurationManager.AppSettings["pollingInterval"]); }
        }

    }
}
