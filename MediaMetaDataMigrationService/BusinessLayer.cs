using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaMetaDataMigrationService
{
    public static class BusinessLayer
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region [ ProcessMediaEntries ]

        public static void ProcessMediaRecords(string value, string configValue)
        {
            try
            {
                log.Info(" Message : " + value);
                log.Info(" Read config value : " + configValue);
                Debug.WriteLine(" Read config value : " + configValue);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
                log.Debug(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
            }
        }

        #endregion


        public static void ReadConfigs()
        {
            try
            {
                General.dbHost = ConfigurationManager.AppSettings["dbHost"];
                General.dbPort = ConfigurationManager.AppSettings["dbPort"];
                General.dbName = ConfigurationManager.AppSettings["dbName"];
                General.dbUserName = ConfigurationManager.AppSettings["dbUserName"];
                General.dbPassword = ConfigurationManager.AppSettings["dbPassword"];


                string tempStrRefInterval = ConfigurationManager.AppSettings["refreshInterval"];
                int intervalTime;
                bool isNumeric = false;
                //Validating entered string Value is integer or NOT
                isNumeric = int.TryParse(tempStrRefInterval, out intervalTime);
                if (isNumeric)
                {
                    General.refreshInterval = Utils.Seconds2MilliSec(double.Parse(tempStrRefInterval));

                }
                else
                {
                    General.refreshInterval = Utils.Seconds2MilliSec(10); //By Default on every 10 Sec,
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
                log.Debug(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
            }
        }
    }
}
