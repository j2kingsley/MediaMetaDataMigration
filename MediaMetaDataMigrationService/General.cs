using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMetaDataMigrationService
{
    public class General
    {
       
        public static string dbHost { get; set; }
        public static string dbPort { get; set; }
        public static string dbName { get; set; }
        public static string dbUserName { get; set; }
        public static string dbPassword { get; set; }

        public static double refreshInterval { get; set; }

        public static bool gBoolProcessingEvent { get; set; }

    }
}
