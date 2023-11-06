using dBASE.NET;
using System.Collections.Generic;

namespace DBFHandler.Core.Fields
{



    internal static class DSKKAR00Field
    {
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public static DbfField DSK_ID { get; private set; } = new DbfField("DSK_ID", DbfFieldType.Character, 10) { Flags = 88 };
        /// <summary>
        /// نام کارگاه
        /// </summary>
        public static DbfField DSK_NAME { get; private set; } = new DbfField("DSK_NAME", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// نام کارفرما
        /// </summary>
        public static DbfField DSK_FARM { get; private set; } = new DbfField("DSK_FARM", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// آدرس کارگاه
        /// </summary>
        public static DbfField DSK_ADRS { get; private set; } = new DbfField("DSK_ADRS", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// نوع لیست همیشه مقدار 0 دارد
        /// </summary>
        public static DbfField DSK_KIND { get; private set; } = new DbfField("DSK_KIND", DbfFieldType.Numeric, 1) { Flags = 88 };
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public static DbfField DSK_YY { get; private set; } = new DbfField("DSK_YY", DbfFieldType.Character, 2) { Flags = 88 };
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public static DbfField DSK_MM { get; private set; } = new DbfField("DSK_MM", DbfFieldType.Numeric, 2) { Flags = 88 };
        /// <summary>
        /// شماره لیست
        /// </summary>
        public static DbfField DSK_LISTNO { get; private set; } = new DbfField("DSK_LISTNO", DbfFieldType.Character, 12) { Flags = 88 };
        /// <summary>
        /// شرح لیست
        /// </summary>
        public static DbfField DSK_DISC { get; private set; } = new DbfField("DSK_DISC", DbfFieldType.Character, 100) { Flags = 88 };
        /// <summary>
        /// تعداد کارکنان
        /// </summary>
        public static DbfField DSK_NUM { get; private set; } = new DbfField("DSK_NUM", DbfFieldType.Numeric, 5) { Flags = 88 };
        /// <summary>
        /// مجموع روزهای کارکرد
        /// </summary>
        public static DbfField DSK_TDD { get; private set; } = new DbfField("DSK_TDD", DbfFieldType.Numeric, 6) { Flags = 88 };
        /// <summary>
        /// مجموع دستمزد روزانه
        /// </summary>
        public static DbfField DSK_TROOZ { get; private set; } = new DbfField("DSK_TROOZ", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع دستمزد ماهانه
        /// </summary>
        public static DbfField DSK_TMAH { get; private set; } = new DbfField("DSK_TMAH", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع مزایای ماهانه مشمول
        /// </summary>
        public static DbfField DSK_TMAZ { get; private set; } = new DbfField("DSK_TMAZ", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public static DbfField DSK_TMASH { get; private set; } = new DbfField("DSK_TMASH", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع کل دستمزد و مزایای ماهانه (مشمول و غیر مشمول)
        /// </summary>
        public static DbfField DSK_TTOTL { get; private set; } = new DbfField("DSK_TTOTL", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع حق بیمه سهم بیمه شده
        /// </summary>
        public static DbfField DSK_TBIME { get; private set; } = new DbfField("DSK_TBIME", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع حق بیمه سهم کارفرما
        /// </summary>
        public static DbfField DSK_TKOSO { get; private set; } = new DbfField("DSK_TKOSO", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// مجموع حق بیمه بیکاری
        /// </summary>
        public static DbfField DSK_BIC { get; private set; } = new DbfField("DSK_BIC", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// نرخ حق بیمه
        /// </summary>
        public static DbfField DSK_RATE { get; private set; } = new DbfField("DSK_RATE", DbfFieldType.Numeric, 5) { Flags = 88 };
        /// <summary>
        /// نرخ پورسانتاژ
        /// </summary>
        public static DbfField DSK_PRATE { get; private set; } = new DbfField("DSK_PRATE", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// نرخ مشاغل و سخت و زیان آور
        /// </summary>
        public static DbfField DSK_BIMH { get; private set; } = new DbfField("DSK_BIMH", DbfFieldType.Numeric, 12) { Flags = 88 };
        /// <summary>
        /// ردیف پیمان
        /// </summary>
        public static DbfField MON_PYM { get; private set; } = new DbfField("MON_PYM", DbfFieldType.Character, 3) { Flags = 88 };


        public static SortedList<int, DbfField> ToList()
        {

            return new SortedList<int, DbfField>
        {
            { 0,DSK_ID },
            { 1,DSK_NAME },
            { 2,DSK_FARM },
            { 3,DSK_ADRS },
            { 4,DSK_KIND },
            { 5,DSK_YY },
            { 6,DSK_MM },
            { 7,DSK_LISTNO },
            { 8,DSK_DISC },
            { 9,DSK_NUM },
            { 10,DSK_TDD },
            { 11,DSK_TROOZ },
            { 12,DSK_TMAH },
            { 13,DSK_TMAZ },
            { 14,DSK_TMASH },
            { 15,DSK_TTOTL },
            { 16,DSK_TBIME },
            { 17,DSK_TKOSO },
            { 18,DSK_BIC },
            { 19,DSK_RATE },
            { 20,DSK_PRATE },
            { 21,DSK_BIMH },
            { 22,MON_PYM }
        };

        }
    }
}