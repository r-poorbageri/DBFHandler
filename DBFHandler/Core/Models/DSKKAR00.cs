using System.Collections.Generic;

namespace DBFHandler.Core.Models
{
    internal class DSKKAR00
    {
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public string DSK_ID { get; set; }
        /// <summary>
        /// نام کارگاه
        /// </summary>
        public string DSK_NAME { get; set; }
        /// <summary>
        /// نام کارفرما
        /// </summary>
        public string DSK_FARM { get; set; }
        /// <summary>
        /// آدرس کارگاه
        /// </summary>
        public string DSK_ADRS { get; set; }
        /// <summary>
        /// نوع لیست همیشه مقدار 0 دارد
        /// </summary>
        public string DSK_KIND { get; set; }
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public string DSK_YY { get; set; }
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public string DSK_MM { get; set; }
        /// <summary>
        /// شماره لیست
        /// </summary>
        public string DSK_LISTNO { get; set; }
        /// <summary>
        /// شرح لیست
        /// </summary>
        public string DSK_DISC { get; set; }
        /// <summary>
        /// تعداد کارکنان
        /// </summary>
        public string DSK_NUM { get; set; }
        /// <summary>
        /// مجموع روزهای کارکرد
        /// </summary>
        public string DSK_TDD { get; set; }
        /// <summary>
        /// مجموع دستمزد روزانه
        /// </summary>
        public string DSK_TROOZ { get; set; }
        /// <summary>
        /// مجموع دستمزد ماهانه
        /// </summary>
        public string DSK_TMAH { get; set; }
        /// <summary>
        /// مجموع مزایای ماهانه مشمول
        /// </summary>
        public string DSK_TMAZ { get; set; }
        /// <summary>
        /// مجموع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public string DSK_TMASH { get; set; }
        /// <summary>
        /// مجموع کل دستمزد و مزایای ماهانه (مشمول و غیر مشمول)
        /// </summary>
        public string DSK_TTOTL { get; set; }
        /// <summary>
        /// مجموع حق بیمه سهم بیمه شده
        /// </summary>
        public string DSK_TBIME { get; set; }
        /// <summary>
        /// مجموع حق بیمه سهم کارفرما
        /// </summary>
        public string DSK_TKOSO { get; set; }
        /// <summary>
        /// مجموع حق بیمه بیکاری
        /// </summary>
        public string DSK_BIC { get; set; }
        /// نرخ حق بیمه
        /// </summary>
        public string DSK_RATE { get; set; }
        /// <summary>
        /// نرخ پورسانتاژ
        /// </summary>
        public string DSK_PRATE { get; set; }
        /// <summary>
        /// نرخ مشاغل و سخت و زیان آور
        /// </summary>
        public string DSK_BIMH { get; set; }
        /// <summary>
        /// ردیف پیمان
        /// </summary>
        public string MON_PYM { get; set; }
    }


    internal class DSKKAR00List
    {
        public List<DSKKAR00> DSKKAR00s { get; set; }
    }

}

