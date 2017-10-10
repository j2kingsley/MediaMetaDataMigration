using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MediaMetaDataMigrationService
{
    public partial class MediaMigrationService : ServiceBase
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        DateTime _now = DateTime.Now;

        private Timer migrationTimer = null;
        public static int counter = 0;

        public MediaMigrationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Read all configs
            BusinessLayer.ReadConfigs();

            //Logs
            Debug.WriteLine("MediaMetaData Migration Started @ " + _now);
            log.Info("MediaMetaData Migration Started");

            migrationTimer = new Timer();
            this.migrationTimer.Interval = General.refreshInterval; //Every 10 Sec = 10000


            this.migrationTimer.Elapsed += new System.Timers.ElapsedEventHandler(migrationTimer_Tick);
            migrationTimer.Enabled = true;


        }

        protected override void OnStop()
        {
            migrationTimer.Enabled = false;
            Debug.WriteLine("EvMediaMetaData MigrationentNotifier Stopped @ " + _now);
            log.Info("MediaMetaData Migration Stopped");
        }
        //Tick Event
        // Concurrent Event is disabled.
        private void migrationTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch totalStopwatch = new Stopwatch();
            Stopwatch jobStopwatch = new Stopwatch();
            jobStopwatch.Start();

            //If Event is processing return
            if (General.gBoolProcessingEvent) return;


            try
            {
                //Turning this toggle on when it reaches assigned thread
                General.gBoolProcessingEvent = true;
                totalStopwatch.Start();
                stopwatch.Start();

                BusinessLayer.ProcessMediaRecords("Hello", General.dbName);

                stopwatch.Reset();
                General.gBoolProcessingEvent = false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
                log.Debug(MethodBase.GetCurrentMethod().Name + " Exception : " + ex.Message);
                General.gBoolProcessingEvent = false;
            }
            finally
            {
                General.gBoolProcessingEvent = false;
            }

        }

        
    }

}
