using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnection(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.SQL:
                    SqlConnector sql = new();
                    Connection = sql;
                    break;
                case DatabaseType.TextFile:
                    TextConnector textFile = new();
                    Connection = textFile;
                    break;
                default:
                    break;
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
