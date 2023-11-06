using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DBFHandler.Tools.Convertors.IranSystemConvertor
{

    /// <summary>
    /// تبدیل کد پیج فارسی داس ایران سیستم به فارسی ویندوز 
    /// </summary>
    public class ConvertToUnicode
    {
        public enum TextEncoding
        {
            Arabic1256 = 1256,
            CP1252 = 1252
        }
        #region private Members (3)

        // متغیری برای نگهداری اعدادی که در رشته ایران سیستم وجود دارند
        Stack<string> NumbersInTheString;

        // کد کاراکترها در ایران سیستم و معادل آنها در عربی 1256
        Dictionary<byte, byte> CharactersMapper = new Dictionary<byte, byte>
    {
    {128,48}, // 0
    {129,49}, // 1
    {130,50}, // 2
    {131,51}, // 3
    {132,52}, // 4
    {133,53}, // 5
    {134,54}, // 6
    {135,55}, // 7
    {136,56}, // 8
    {137,57}, // 9
    {138,161}, // ،
    {139,220}, // -
    {140,191}, // ؟
    {141,194}, // آ
    {142,196}, // ﺋ
    {143,154}, // ء
    {144,199}, // ﺍ
    {145,199}, // ﺎ
    {146,200}, // ﺏ
    {147,200}, // ﺑ
    {148,129}, // ﭖ
    {149,129}, // ﭘ
    {150,202}, // ﺕ
    {151,202}, // ﺗ
    {152,203}, // ﺙ
    {153,203}, // ﺛ
    {154,204}, //ﺝ
    {155,204},// ﺟ
    {156,141},//ﭼ
    {157,141},//ﭼ
    {158,205},//ﺡ
    {159,205},//ﺣ
    {160,206},//ﺥ
    {161,206},//ﺧ
    {162,207},//د
    {163,208},//ذ
    {164,209},//ر
    {165,210},//ز
    {166,142},//ژ
    {167,211},//ﺱ
    {168,211},//ﺳ
    {169,212},//ﺵ
    {170,212},//ﺷ
    {171,213},//ﺹ
    {172,213},//ﺻ
    {173,214},//ﺽ
    {174,214},//ﺿ
    {175,216},//ط
    {224,217},//ظ
    {225,218},//ﻉ
    {226,218},//ﻊ
    {227,218},//ﻌ
    {228,218},//ﻋ
    {229,219},//ﻍ
    {230,219},//ﻎ
    {231,219},//ﻐ
    {232,219},//ﻏ
    {233,221},//ﻑ
    {234,221},//ﻓ
    {235,222},//ﻕ
    {236,222},//ﻗ
    {237,152},//ﮎ
    {238,152},//ﮐ
    {239,144},//ﮒ
    {240,144},//ﮔ
    {241,225},//ﻝ
    {242,225},//ﻻ
    {243,225},//ﻟ
    {244,227},//ﻡ
    {245,227},//ﻣ
    {246,228},//ﻥ
    {247,228},//ﻧ
    {248,230},//و
    {249,229},//ﻩ
    {250,229},//ﻬ
    {251,170},//ﻫ
    {252,236},//ﯽ
    {253,237},//ﯼ
    {254,237},//ﯾ
    {255,160} // فاصله
    };

        /// <summary>
        /// لیست کاراکترهایی که بعد از آنها باید یک فاصله اضافه شود
        /// </summary>
        byte[] charactersWithSpaceAfter = {
                                         146, // ب
                                         148, // پ
                                         150, // ت
                                         152, // ث
                                         154, // ج
                                         156, // چ
                                         158, // ح
                                         160, // خ
                                         167, // س
                                         169, // ش
                                         171, // ص
                                         173, // ض
                                         225, // ع
                                         229, // غ
                                         233, // ف
                                         235, // ق
                                         237, // ک
                                         239, // گ
                                         241, // ل
                                         244, // م
                                         246, // ن
                                         249, // ه
                                         252, //ﯽ
                                         253 // ی
                                     };


        #endregion

        /// <summary>
        /// تبدیل یک رشته ایران سیستم به یونیکد با استفاده از عربی 1256
        /// </summary>
        /// <param name="iranSystemEncodedString">رشته ایران سیستم</param>
        /// <returns></returns>
        [Obsolete("بهتر است از UnicodeFrom استفاده کنید")]
        public string Unicode(string iranSystemEncodedString)
        {
            return UnicodeFrom(TextEncoding.Arabic1256, iranSystemEncodedString);
        }

        /// <summary>
        /// تبدیل یک رشته ایران سیستم به یونیکد
        /// </summary>
        /// <param name="textEncoding">کدپیج رشته ایران سیستم</param>
        /// <param name="iranSystemEncodedString">رشته ایران سیستم</param>
        /// <returns></returns>
        public string UnicodeFrom(TextEncoding textEncoding, string iranSystemEncodedString)
        {
            // حذف فاصله های موجود در رشته
            //iranSystemEncodedString = iranSystemEncodedString.Replace(" ", "");

            /// بازگشت در صورت خالی بودن رشته
            if (string.IsNullOrWhiteSpace(iranSystemEncodedString))
            {
                return string.Empty;
            }

            // در صورتی که رشته تماماً عدد نباشد
            if (!IsNumber(iranSystemEncodedString))
            {
                /// تغییر ترتیب کاراکترها از آخر به اول 
                iranSystemEncodedString = Reverse(iranSystemEncodedString);

                /// خارج کردن اعداد درون رشته
                iranSystemEncodedString = ExcludeNumbers(iranSystemEncodedString);
            }

            // وهله سازی از انکودینگ صحیح برای تبدیل رشته ایران سیستم به بایت
            Encoding encoding = Encoding.GetEncoding((int)textEncoding);

            // تبدیل رشته به بایت
            byte[] stringBytes = encoding.GetBytes(iranSystemEncodedString.Trim());


            // آرایه ای که بایت های معادل را در آن قرار می دهیم
            // مجموع تعداد بایت های رشته + بایت های اضافی محاسبه شده 
            byte[] newStringBytes = new byte[stringBytes.Length + CountCharactersRequireTwoBytes(stringBytes)];

            int index = 0;

            // بررسی هر بایت و پیدا کردن بایت (های) معادل آن
            for (int i = 0; i < stringBytes.Length; ++i)
            {
                byte charByte = stringBytes[i];

                // اگر جز 128 بایت اول باشد که نیازی به تبدیل ندارد چون کد اسکی است
                if (charByte < 128)
                {
                    newStringBytes[index] = charByte;
                }
                else
                {
                    // اگر جز حروف یا اعداد بود معادلش رو قرار می دیم
                    if (CharactersMapper.ContainsKey(charByte))
                    {
                        newStringBytes[index] = CharactersMapper[charByte];
                    }
                }

                // اگر کاراکتر ایران سیستم "لا" بود چون کاراکتر متناظرش در عربی 1256 "ل" است و باید یک "ا" هم بعدش اضافه کنیم
                if (charByte == 242)
                {
                    newStringBytes[++index] = 199;
                }

                // اگر کاراکتر یکی از انواعی بود که بعدشان باید یک فاصله باشد
                // و در عین حال آخرین کاراکتر رشته نبود
                if (charactersWithSpaceAfter.Contains(charByte) && Array.IndexOf(stringBytes, charByte) != stringBytes.Length - 1)
                {
                    // یک فاصله بعد ان اضافه می کنیم
                    newStringBytes[++index] = 32;
                }

                index += 1;
            }

            // تبدیل به رشته و ارسال به فراخواننده
            byte[] unicodeContent = Encoding.Convert(encoding, Encoding.Unicode, newStringBytes);

            string convertedString = Encoding.Unicode.GetString(unicodeContent).Trim();

            return IncludeNumbers(convertedString);
        }

        public DataTable ConvertIranSystemToUnicode(DataTable source, DataTable columns)
        {
            foreach (DataRow row in source.Rows)
            {
                var col = columns.Select("TYPE = 'String' or TYPE = 'Character'").CopyToDataTable();
                foreach (DataRow column in col.Rows)
                {

                    row.SetField(column["NAME"].ToString(),
                        UnicodeFrom(TextEncoding.Arabic1256, row[column["NAME"].ToString()].ToString()));
                }
            }
            return source;
        }
        public DataTable ConvertIranSystemToUnicode(DataTable source)
        {
            foreach (DataRow row in source.Rows)
            {
                foreach (DataColumn column in source.Columns)
                {
                    row.SetField(column, UnicodeFrom(TextEncoding.Arabic1256, row[column].ToString()));
                }
            }
            return source;
        }



        #region Private Methods (4)

        /// <summary>
        /// رشته ارسال شده تنها حاوی اعداد است یا نه
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool IsNumber(string str)
        {
            return Regex.IsMatch(str, @"^[\d]+$");
        }

        /// <summary>
        ///  محاسبه تعداد کاراکترهایی که بعد از آنها یک کاراکتر باید اضافه شود
        ///  شامل کاراکتر لا
        ///  و کاراکترهای غیرچسبان تنها در صورتی که کاراکتر پایانی رشته نباشند
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        int CountCharactersRequireTwoBytes(byte[] irTextBytes)
        {
            return (from b in irTextBytes
                    where (
                    charactersWithSpaceAfter.Contains(b) // یکی از حروف غیرچسبان باشد
                    && Array.IndexOf(irTextBytes, b) != irTextBytes.Length - 1) // و کاراکتر آخر هم نباشد
                    || b == 242 // یا کاراکتر لا باشد
                    select b).Count();
        }

        /// <summary>
        /// خارج کردن اعدادی که در رشته ایران سیستم قرار دارند
        /// </summary>
        /// <param name="iranSystemString"></param>
        /// <returns></returns>
        string ExcludeNumbers(string iranSystemString)
        {
            /// گرفتن لیستی از اعداد درون رشته
            NumbersInTheString = new Stack<string>(Regex.Split(iranSystemString, @"\D+"));

            /// جایگزین کردن اعداد با یک علامت جایگزین
            /// در نهایت بعد از تبدیل رشته اعداد به رشته اضافه می شوند
            return Regex.Replace(iranSystemString, @"\d+", "#");
        }

        /// <summary>
        /// اضافه کردن اعداد جدا شده پس از تبدیل رشته
        /// </summary>
        /// <param name="convertedString"></param>
        /// <returns></returns>
        string IncludeNumbers(string convertedString)
        {
            while (convertedString.IndexOf("#") >= 0)
            {
                string number = Reverse(NumbersInTheString.Pop());
                if (!string.IsNullOrWhiteSpace(number))
                {
                    int index = convertedString.IndexOf("#");

                    convertedString = convertedString.Remove(index, 1);
                    convertedString = convertedString.Insert(index, number);
                }
            }

            return convertedString;
        }

        string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion
    }

    /// <summary>
    /// تبدیل کد پیج فارسی ویندوز به فارسی داس ایران سیستم
    /// </summary>
    public class ConvertToIranSystem
    {
        /// <summary>
        /// نحوه‌ي تبديل اعداد
        /// </summary>
        public enum IranSystemNumbers
        {
            /// <summary>
            /// اعداد موجود به فرمت ايران سيستم تبديل نشوند و به همان شكل اصلي باقي بمانند
            /// </summary>
            DontConvert,

            /// <summary>
            /// اعداد موجود هم به قالب ايران سيستم تبديل شوند
            /// </summary>
            Convert
        }

        const byte AlefChasban = 145;
        const byte LaaArabic = 242;
        const byte LaamAvval = 243;
        const byte QuestionMark = 191;

        private readonly IDictionary<byte, byte> _charMapperCharIsNotFinal =
            new Dictionary<byte, byte>
        {
        {48 , 128}, // 0
        {49 , 129}, // 1
        {50 , 130}, // 2
        {51 , 131}, // 3
        {52 , 132}, // 4
        {53 , 133}, // 5
        {54 , 134}, // 6
        {55 , 135}, // 7
        {56 , 136}, // 8
        {57 , 137}, // 9
        {161, 138}, // ،
        {191, 140}, // ؟
        {193,143}, //
        {194,141}, // آ
        {195,145}, // ﺎ
        {196, /*248*/ 142}, //
        {197,145}, //
        {198,254}, //
        {199,145}, //
        {200,147}, //
        {201,250}, //
        {202,151}, //
        {203,153}, //
        {204,155}, //
        {205,159}, //
        {206,161}, //
        {207,162}, //
        {208,163}, //
        {209,164}, //
        {210,165}, //ز
        {211,168}, //
        {212,170}, //
        {213,172}, //
        {214,174}, //
        {216,175}, //
        {217,224}, //
        {218,227}, //
        {219,231}, //
        {220,139}, // -
        {221,234}, //
        {222,236}, //
        {223,238}, //
        {225,243}, //
        {227,245}, //
        {228,247}, //
        {229,250}, //
        {230,248}, //
        {236,254}, //
        {237,254}, //
        {129,149}, //
        {141,157}, //
        {142,166}, //
        {152,238}, //
        {144,240} //
            };

        private readonly IDictionary<byte, byte> _charMapperNextCharFinal =
            new Dictionary<byte, byte>
        {
        {198, 252}, //
        {200, 146}, //
        {201, 249}, //
        {202, 150}, //
        {203, 152}, //
        {204, 154}, //
        {205, 158}, //
        {206, 160}, //
        {211, 167}, //
        {212, 169}, //
        {213, 171}, //
        {214, 173}, //
        {218, 226}, //
        {219, 230}, //
        {221, 233}, //
        {222, 235}, //
        {223, 237}, //
        {225, 241}, //
        {227, 244 /*245*/}, //
        {228, 246}, //
        {229, 249}, //
        {236, 252}, //
        {237, 252}, //
        {129, 148}, //
        {141, 156}, //
        {142, 166}, //
        {152, 237}, //
        {144, 239} //
            };

        private readonly IDictionary<byte, byte> _charMapperPreviousCharFinal =
            new Dictionary<byte, byte>
        {
       {195, 144},//أ
       {197, 144},//إ
       {199, 144},//ا
       {201, 251},//ة
       {218, 228},//ع
       {219, 232},//غ
       {229, 251},//ه
       {170, 251}//ﻫ
            };

        private readonly IDictionary<byte, byte> _charMapperPreviousCharNextCharFinal =
            new Dictionary<byte, byte>
        {
        {195, 144}, // أ
        {197, 144}, //إ
        {199, 144},//ا
        {200, 146}, //ب
        {201, 249}, //ة
        {202, 150}, //ت
        {203, 152}, //ث
        {204, 154}, //ﺝ
        {205, 158}, //ﺡ
        {206, 160}, //ﺥ
        {211, 167},//س
        {212, 169},//ش
        {213, 171}, //ص
        {214, 173}, //ض
        {218, 225}, //ع
        {219, 229}, //غ
        {221, 233},//ف
        {222, 235},//ق
        {223, 237},//ك
        {225, 241},//ل
        {227, 244},//م
        {228, 246},//ن
        {229, 249},//ه
        {236, /*253*/ 252},//ى
        {237, 253},//ی
        {129, 148},//پ
        {141, 156},//چ
        {152, 237},//ک
        {144, 239}//گ
            };

        private readonly Encoding _encoding1256 = Encoding.GetEncoding("windows-1256");

        private readonly byte[] _singles = Encoding.GetEncoding("windows-1256").GetBytes("ءآأؤإادذرزژو");

        /// <summary>
        /// تبديل رشته‌ي يونيكد به رشته‌ي ايران سيستمي
        /// </summary>
        /// <param name="text">رشته‌ي يونيكد</param>
        /// <param name="iranSystemNumbers">تبديل اعداد</param>
        /// <returns>رشته‌ي ايران سيستمي</returns>
        public string ToIranSystem(
            string text,
            IranSystemNumbers iranSystemNumbers = IranSystemNumbers.DontConvert)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = reverseNumbersAndLetters(text);
            var iranSystemBytes = getUnicodeToIranSystem(text, iranSystemNumbers);
            var iranSystemText = _encoding1256.GetString(iranSystemBytes.ToArray()).Trim();
            return new string(iranSystemText.Reverse().ToArray());

        }

        public DataTable ConvertUnicodeToIranSystem(DataTable source)
        {
            foreach (DataRow row in source.Rows)
            {
                foreach (DataColumn column in source.Columns)
                {
                    row.SetField(column, ToIranSystem(TrimIllegalcharacters(row[column].ToString())));
                }
            }
            return source;
        }

        private string TrimIllegalcharacters(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var result = str.Trim()
                .Replace("\"", "")
                .Replace("\'", "")
                .Replace(">", "")
                .Replace("<", "")
                .Replace("&", "");
            return result;
        }
        private byte getLattinLetter(byte c)
        {
            return char.IsNumber((char)c) ? (byte)(c + 80) : getMirroredCharacter(c);
        }

        private byte getMapperCharIsNotFinal(byte currentChar)
        {
            byte value;
            return _charMapperCharIsNotFinal.TryGetValue(currentChar, out value) ? value : currentChar;
        }

        private byte getMapperNextCharFinal(byte currentChar)
        {
            byte value;
            return _charMapperNextCharFinal.TryGetValue(currentChar, out value) ? value : getMapperCharIsNotFinal(currentChar);
        }

        private byte getMapperPreviousCharFinal(byte currentChar)
        {
            byte value;
            return _charMapperPreviousCharFinal.TryGetValue(currentChar, out value) ? value : getMapperCharIsNotFinal(currentChar);
        }

        private byte getMapperPreviousCharNextCharFinal(byte currentChar)
        {
            byte value;
            return _charMapperPreviousCharNextCharFinal.TryGetValue(currentChar, out value) ? value : getMapperCharIsNotFinal(currentChar);
        }

        private byte getMirroredCharacter(byte c)
        {
            switch (c)
            {
                case (byte)'(': return (byte)')';
                case (byte)'{': return (byte)'}';
                case (byte)'[': return (byte)']';
                case (byte)')': return (byte)'(';
                case (byte)'}': return (byte)'{';
                case (byte)']': return (byte)'[';
                default: return c;
            }
        }

        private List<byte> getUnicodeToIranSystem(string text, IranSystemNumbers iranSystemNumbers)
        {
            var unicodeString = string.Format(" {0} ", text);
            var textBytes = _encoding1256.GetBytes(unicodeString);

            byte pre = 0;
            var length = textBytes.Length;
            var results = new List<byte>(length);

            for (var i = 0; i < length; i++)
            {
                byte cur;
                var currentChar = textBytes[i];

                if (isNumber(currentChar) && iranSystemNumbers == IranSystemNumbers.DontConvert)
                {
                    cur = currentChar;
                    results.Add(cur);
                    pre = cur;
                }
                else if (isLattinLetter(currentChar))
                {
                    cur = getLattinLetter(currentChar);
                    results.Add(cur);
                    pre = cur;
                }
                else if (i != 0 && i != length - 1)
                {
                    cur = getUnicodeToIranSystemChar(textBytes[i - 1], currentChar, textBytes[i + 1]);
                    if (cur == AlefChasban) // برای بررسی استثنای لا
                    {
                        if (pre == LaamAvval)
                        {
                            results.RemoveAt(results.Count - 1);
                            results.Add(LaaArabic);
                        }
                        else
                        {
                            results.Add(cur);
                        }
                    }
                    else
                    {
                        results.Add(cur);
                    }

                    pre = cur;
                }
            }

            return results;
        }

        private byte getUnicodeToIranSystemChar(byte previousChar, byte currentChar, byte nextChar)
        {
            var isPreviousCharFinal =
                isWhitespaceOrLattinOrQuestionMark(previousChar) ||
                isFinalLetter(previousChar);

            var isNextCharFinal = isWhitespaceOrLattinOrQuestionMark(nextChar);

            if (isPreviousCharFinal && isNextCharFinal)
            {
                return getMapperPreviousCharNextCharFinal(currentChar);
            }

            if (isPreviousCharFinal)
            {
                return getMapperPreviousCharFinal(currentChar);
            }

            if (isNextCharFinal)
            {
                return getMapperNextCharFinal(currentChar);
            }

            return getMapperCharIsNotFinal(currentChar);
        }

        private bool isFinalLetter(byte c)
        {
            return _singles.Contains(c);
        }

        private bool isLattinLetter(byte c)
        {
            return c < 128 && c > 31;
        }

        private bool isNumber(byte currentChar)
        {
            return currentChar >= 48 && currentChar <= 57;
        }

        private bool isWhiteSpaceLetter(byte c)
        {
            return c == 8 || c == 09 || c == 10 || c == 13 || c == 27 || c == 32 || c == 0;
        }

        private bool isWhitespaceOrLattinOrQuestionMark(byte c)
        {
            return isWhiteSpaceLetter(c) || isLattinLetter(c) || c == QuestionMark;
        }

        private string reverseNumbersAndLetters(string text)
        {
            return Regex.Replace(text, @"[a-zA-Z0-9]+", match =>
            {
                return new string(match.Value.Reverse().ToArray());
            }).Trim();
        }
    }
}