using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFHandler.Core.Models
{
    internal class DSKWOR00
    {
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public string DSW_ID { get; set; }
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public string DSW_YY { get; set; }
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public string DSW_MM { get; set; }
        /// <summary>
        /// شماره لیست
        /// </summary>
        public string DSW_LISTNO { get; set; }
        /// <summary>
        /// شماره بیمه
        /// </summary>
        public string DSW_ID1 { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string DSW_FNAME { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string DSW_LNAME { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string DSW_DNAME { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string DSW_IDNO { get; set; }
        /// <summary>
        /// محل صدور
        /// </summary>
        public string DSW_IDPLC { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public string DSW_IDATE { get; set; }
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public string DSW_BDATE { get; set; }
        /// <summary>
        /// جنسیت
        /// </summary>
        public string DSW_SEX { get; set; }
        /// <summary>
        /// ملیت
        /// </summary>
        public string DSW_NAT { get; set; }
        /// <summary>
        /// شرح شغل
        /// </summary>
        public string DSW_OCP { get; set; }
        /// <summary>
        /// تاریخ شروع به کار
        /// </summary>
        public string DSW_SDATE { get; set; }
        /// <summary>
        /// تاریخ ترک کار
        /// </summary>
        public string DSW_EDATE { get; set; }
        /// <summary>
        /// تعداد روزهای کارکرد
        /// </summary>
        public string DSW_DD { get; set; }
        /// <summary>
        /// دستمزد روزانه
        /// </summary>
        public string DSW_ROOZ { get; set; }
        /// <summary>
        /// دستمزد ماهانه
        /// </summary>
        public string DSW_MAH { get; set; }
        /// <summary>
        /// مزایای ماهانه
        /// </summary>
        public string DSW_MAZ { get; set; }
        /// <summary>
        /// جمع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public string DSW_MASH { get; set; }
        /// <summary>
        /// جمع کل دستمزد و مزایای ماهانه
        /// </summary>
        public string DSW_TOTL { get; set; }
        /// <summary>
        /// حق بیمه سهم بیمه شده
        /// </summary>
        public string DSW_BIME { get; set; }
        /// <summary>
        /// نرخ پورسانتاژ
        /// </summary>
        public string DSW_PRATE { get; set; }
        /// <summary>
        /// کد شغل
        /// </summary>
        public string DSW_JOB { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        public string PER_NATCOD { get; set; }
    }

    internal class DSKWOR00List
    {
        public List<DSKWOR00> DSKWOR00s { get; set; }
    }
}