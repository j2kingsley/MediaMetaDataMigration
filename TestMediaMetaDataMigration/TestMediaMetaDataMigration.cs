using System;
using MediaMetaDataMigrationService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMediaMetaDataMigration
{
    [TestClass]
    public class TestMediaMetaDataMigration
    {
        [TestMethod]
        public void TestMethod1()
        {
            BusinessLayer.ReadConfigs();

            BusinessLayer.ProcessMediaRecords("TestHello", General.dbName);

        }
    }
}
