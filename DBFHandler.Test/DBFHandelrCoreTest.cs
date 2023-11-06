using DBFHandler.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;

namespace DBFHandler.Test
{
    [TestClass]
    public class DBFHandelrCoreTest
    {

        [TestMethod]
        [TestProperty("ExecutionOrder", "1")]
        public void CreateDSKKAR00FileTestMethod()
        {
            // Arrange
            var dbf = new DBFHelper();
            var data = CreateDSKKAR00TestData();

            // Act
            dbf.CreateDSKKAR00File(data, Directory.GetCurrentDirectory());

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "2")]
        public void CreateDSKWOR00FileTestMethod()
        {
            // Arrange
            var dbf = new DBFHelper();
            var data = CreateDSKWOR00TestData();

            // Act
            dbf.CreateDSKWOR00File(data, Directory.GetCurrentDirectory());

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder","3")]
        public void ReadDbfFileTestMethod()
        {
            // Arrange
            var dbf = new DBFHelper();

            // Act
            var dt = dbf.ReadDbfFile(Directory.GetCurrentDirectory() + @"\DSKKAR00.DBF");

            // Assert
            Assert.AreNotEqual(dt.Rows.Count,0);
        }

        private DataTable CreateDSKKAR00TestData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DSK_ID");
            dt.Columns.Add("DSK_NAME");
            dt.Columns.Add("DSK_FARM");
            dt.Columns.Add("DSK_ADRS");
            dt.Columns.Add("DSK_KIND");
            dt.Columns.Add("DSK_YY");
            dt.Columns.Add("DSK_MM");
            dt.Columns.Add("DSK_LISTNO");
            dt.Columns.Add("DSK_DISC");
            dt.Columns.Add("DSK_NUM");
            dt.Columns.Add("DSK_TDD");
            dt.Columns.Add("DSK_TROOZ");
            dt.Columns.Add("DSK_TMAH");
            dt.Columns.Add("DSK_TMAZ");
            dt.Columns.Add("DSK_TMASH");
            dt.Columns.Add("DSK_TTOTL");
            dt.Columns.Add("DSK_TBIME");
            dt.Columns.Add("DSK_TKOSO");
            dt.Columns.Add("DSK_BIC");
            dt.Columns.Add("DSK_RATE");
            dt.Columns.Add("DSK_PRATE");
            dt.Columns.Add("DSK_BIMH");
            dt.Columns.Add("MON_PYM");
            
            dt.Rows.Add("0052368456", "کارگاه", "کارفرما", "آدرس", "0", "02", "01", "125", "", "5", "150", "260000000", "220000000", "1100000", "659999000", "125000", "32555", "123400", "0", "23", "0", "0", "");

            return dt;
        }

        private DataTable CreateDSKWOR00TestData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("DSW_ID");
            dt.Columns.Add("DSW_YY");
            dt.Columns.Add("DSW_MM");
            dt.Columns.Add("DSW_LISTNO");
            dt.Columns.Add("DSW_ID1");
            dt.Columns.Add("DSW_FNAME");
            dt.Columns.Add("DSW_LNAME");
            dt.Columns.Add("DSW_DNAME");
            dt.Columns.Add("DSW_IDNO");
            dt.Columns.Add("DSW_IDPLC");
            dt.Columns.Add("DSW_IDATE");
            dt.Columns.Add("DSW_BDATE");
            dt.Columns.Add("DSW_SEX");
            dt.Columns.Add("DSW_NAT");
            dt.Columns.Add("DSW_OCP");
            dt.Columns.Add("DSW_SDATE");
            dt.Columns.Add("DSW_EDATE");
            dt.Columns.Add("DSW_DD");
            dt.Columns.Add("DSW_ROOZ");
            dt.Columns.Add("DSW_MAH");
            dt.Columns.Add("DSW_MAZ");
            dt.Columns.Add("DSW_MASH");
            dt.Columns.Add("DSW_TOTL");
            dt.Columns.Add("DSW_BIME");
            dt.Columns.Add("DSW_PRATE");
            dt.Columns.Add("DSW_JOB");
            dt.Columns.Add("PER_NATCOD");

            dt.Rows.Add("0052368456", "02", "01", "356", "00659", "تست", "تست زاده", "تستعلی", "123", "تهران", "13720302", "13720302", "مرد", "ایرانی", "کارشناس فروش", "14020701", "", "30", "250000", "56000000", "0", "90000000", "0", "0", "0", "0","0");


            return dt;
        }
    }
}
