using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaMetaDataMigrationService
{
    public static class Utils
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static double Seconds2MilliSec(double seconds)
        {
            double retVal = 0;

            try
            {
                TimeSpan inMilliSec = TimeSpan.FromSeconds(seconds);

                return retVal = inMilliSec.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                log.Error(MethodBase.GetCurrentMethod().Name + " Function : Exception :  " + ex.Message);
                Debug.WriteLine(ex.Message);
                return retVal;
            }
        }

    }
}
