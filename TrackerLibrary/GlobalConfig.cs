using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textfile)
        {
            if (database)
            {
                // TODO: Set up the sql connection
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textfile)
            {
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
        
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
