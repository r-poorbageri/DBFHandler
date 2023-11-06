using dBASE.NET;
using System.Collections.Generic;

namespace DBFHandler.Core.Fields
{
    internal static class DSKWOR00Field
    {
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public static DbfField DSW_ID { get; private set; } = new DbfField("DSW_ID", DbfFieldType.Character, 10) { Flags = 88 };
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public static DbfField DSW_YY { get; private set; } = new DbfField("DSW_YY", DbfFieldType.Character, 2) { Flags = 88 };
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public static DbfField DSW_MM { get; private set; } = new DbfField("DSW_MM", DbfFieldType.Numeric, 2) { Flags = 88 };
        /// <summary>
        /// شماره لیست
        /// </summary>
        public static DbfField DSW_LISTNO { get; private set; } = new DbfField("DSW_LISTNO", DbfFieldType.Character, 12) { Flags = 88 };
        /// <summary>
        /// شماره بیمه
        /// </summary>
        public static DbfField DSW_ID1 { get; private set; } = new DbfField("DSW_ID1", DbfFieldType.Character, 10) { Flags = 88 };
        /// <summary>
        /// نام
        /// </summary>
        public static DbfField DSW_FNAME { get; private set; } = new DbfField("DSW_FNAME", DbfFieldType.Character, 40) { Flags = 88 };
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public static DbfField DSW_LNAME { get; private set; } = new DbfField("DSW_LNAME", DbfFieldType.Character, 40) { Flags = 88 };
        /// <summary>
        /// نام پدر
        /// </summary>
        public static DbfField DSW_DNAME { get; private set; } = new DbfField("DSW_DNAME", DbfFieldType.Character, 40) { Flags = 88 };
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public static DbfField DSW_IDNO { get; private set; } = new DbfField("DSW_IDNO", DbfFieldType.Character, 15) { Flags = 88 };
        /// <summary>
        /// محل صدور
        /// </summary>
        public static DbfField DSW_IDPLC { get; private set; } = new DbfField("DSW_IDPLC", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public static DbfField DSW_IDATE { get; private set; } = new DbfField("DSW_IDATE", DbfFieldType.Character, 8) { Flags = 88 };
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public static DbfField DSW_BDATE { get; private set; } = new DbfField("DSW_BDATE", DbfFieldType.Character, 8) { Flags = 88 };
        /// <summary>
        /// جنسیت
        /// </summary>
        public static DbfField DSW_SEX { get; private set; } = new DbfField("DSW_SEX", DbfFieldType.Character, 3) { Flags = 88 };
        /// <summary>
        /// ملیت
        /// </summary>
        public static DbfField DSW_NAT { get; private set; } = new DbfField("DSW_NAT", DbfFieldType.Character, 10) { Flags = 88 };
        /// <summary>
        /// شرح شغل
        /// </summary>
        public static DbfField DSW_OCP { get; private set; } = new DbfField("DSW_OCP", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// تاریخ شروع به کار
        /// </summary>
        public static DbfField DSW_SDATE { get; private set; } = new DbfField("DSW_SDATE", DbfFieldType.Character, 8) { Flags = 88 };
        /// <summary>
        /// تاریخ ترک کار
        /// </summary>
        public static DbfField DSW_EDATE { get; private set; } = new DbfField("DSW_EDATE", DbfFieldType.Character, 8) { Flags = 88 };
        /// <summary>
        /// تعداد روزهای کارکرد
        /// </summary>
        public static DbfField DSW_DD { get; private set; } = new DbfField("DSW_DD", DbfFieldType.Numeric, 2) { Flags = 88 };
        /// <summary>
        /// دستمزد روزانه
        /// </summary>
        public static DbfField DSW_ROOZ { get; private set; } = new DbfField("DSW_ROOZ", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// دستمزد ماهانه
        /// </summary>
        public static DbfField DSW_MAH { get; private set; } = new DbfField("DSW_MAH", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مزایای ماهانه
        /// </summary>
        public static DbfField DSW_MAZ { get; private set; } = new DbfField("DSW_MAZ", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// جمع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public static DbfField DSW_MASH { get; private set; } = new DbfField("DSW_MASH", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// جمع کل دستمزد و مزایای ماهانه
        /// </summary>
        public static DbfField DSW_TOTL { get; private set; } = new DbfField("DSW_TOTL", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// حق بیمه سهم بیمه شده
        /// </summary>
        public static DbfField DSW_BIME { get; private set; } = new DbfField("DSW_BIME", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// نرخ پورسانتاژ
        /// </summary>
        public static DbfField DSW_PRATE { get; private set; } = new DbfField("DSW_PRATE", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// کد شغل
        /// </summary>
        public static DbfField DSW_JOB { get; private set; } = new DbfField("DSW_JOB", DbfFieldType.Character, 6) { Flags = 88 };
        /// <summary>
        /// کد ملی
        /// </summary>
        public static DbfField PER_NATCOD { get; private set; } = new DbfField("PER_NATCOD", DbfFieldType.Character, 10) { Flags = 88 };


        public static SortedList<int, DbfField> ToList()
        {
            return new SortedList<int, DbfField>
            {
                { 0, DSW_ID },
                { 1, DSW_YY },
                { 2, DSW_MM },
                { 3, DSW_LISTNO },
                { 4, DSW_ID1 },
                { 5, DSW_FNAME },
                { 6, DSW_LNAME },
                { 7, DSW_DNAME },
                { 8, DSW_IDNO },
                { 9, DSW_IDPLC },
                { 10, DSW_IDATE },
                { 11, DSW_BDATE },
                { 12, DSW_SEX },
                { 13, DSW_NAT },
                { 14, DSW_OCP },
                { 15, DSW_SDATE },
                { 16, DSW_EDATE },
                { 17, DSW_DD },
                { 18, DSW_ROOZ },
                { 19, DSW_MAH },
                { 20, DSW_MAZ },
                { 21, DSW_MASH },
                { 22, DSW_TOTL },
                { 23, DSW_BIME },
                { 24, DSW_PRATE },
                { 25, DSW_JOB },
                { 26, PER_NATCOD }
            };
        }
    }

}

