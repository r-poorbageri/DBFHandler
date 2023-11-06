using DBFHandler.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFHandler.Core.Validations
{
    internal class DSKWOR00Validation : AbstractValidator<DSKWOR00>
    {
        const string NumericRegexPattern = "^([0-9]*)$";
        const string FloatNumericRegexPattern = "^([0-9]+([.][0-9]*)?|[.][0-9]+)$";

        public DSKWOR00Validation()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleForDSW_ID();
            RuleForDSW_YY();
            RuleForDSW_MM();
            RuleForDSW_LISTNO();
            RuleForDSW_ID1();
            RuleForDSW_FNAME();
            RuleForDSW_LNAME();
            RuleForDSW_DNAME();
            RuleForDSW_IDNO();
            RuleForDSW_IDPLC();
            RuleForDSW_IDATE();
            RuleForDSW_BDATE();
            RuleForDSW_SEX();
            RuleForDSW_NAT();
            RuleForDSW_OCP();
            RuleForDSW_SDATE();
            RuleForDSW_EDATE();
            RuleForDSW_DD();
            RuleForDSW_ROOZ();
            RuleForDSW_MAH();
            RuleForDSW_MAZ();
            RuleForDSW_MASH();
            RuleForDSW_TOTL();
            RuleForDSW_BIME();
            RuleForDSW_PRATE();
            RuleForDSW_JOB();
            RuleForPER_NATCOD();
        }

        private void RuleForPER_NATCOD()
        {
            RuleFor(dskwor00 => dskwor00.PER_NATCOD)
                                    .NotEmpty().WithMessage("کد ملی نباید خالی باشد")
                                    .MaximumLength(10).WithMessage("کد ملی نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_JOB()
        {
            RuleFor(dskwor00 => dskwor00.DSW_JOB)
                                    .NotEmpty().WithMessage("کد شغل نباید خالی باشد")
                                    .MaximumLength(6).WithMessage("کد شغل نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_PRATE()
        {
            RuleFor(dskwor00 => dskwor00.DSW_PRATE)
                                    .NotEmpty().WithMessage("نرخ پورسانتاژ نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("نرخ پورسانتاژ نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_BIME()
        {
            RuleFor(dskwor00 => dskwor00.DSW_BIME)
                                    .NotEmpty().WithMessage("حق بیمه سهم بیمه شده نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("حق بیمه سهم بیمه شده نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_TOTL()
        {
            RuleFor(dskwor00 => dskwor00.DSW_TOTL)
                                    .NotEmpty().WithMessage("جمع کل دستمزد و مزایای ماهانه نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("جمع کل دستمزد و مزایای ماهانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_MASH()
        {
            RuleFor(dskwor00 => dskwor00.DSW_MASH)
                                    .NotEmpty().WithMessage("جمع دستمزد و مزایای ماهانه مشمول نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("جمع دستمزد و مزایای ماهانه مشمول نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_MAZ()
        {
            RuleFor(dskwor00 => dskwor00.DSW_MAZ)
                                    .NotEmpty().WithMessage("مزایای ماهانه نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("مزایای ماهانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_MAH()
        {
            RuleFor(dskwor00 => dskwor00.DSW_MAH)
                                    .NotEmpty().WithMessage("دستمزد ماهانه نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("دستمزد ماهانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_ROOZ()
        {
            RuleFor(dskwor00 => dskwor00.DSW_ROOZ)
                                    .NotEmpty().WithMessage("دستمزد روزانه نباید خالی باشد")
                                    .MaximumLength(12).WithMessage("دستمزد روزانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_DD()
        {
            RuleFor(dskwor00 => dskwor00.DSW_DD)
                                    .NotEmpty().WithMessage("تعداد روزهای کارکرد نباید خالی باشد")
                                    .MaximumLength(2).WithMessage("تعداد روزهای کارکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_EDATE()
        {
            RuleFor(dskwor00 => dskwor00.DSW_EDATE)
                                    .MaximumLength(8).WithMessage("تاریخ ترک کار نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_SDATE()
        {
            RuleFor(dskwor00 => dskwor00.DSW_SDATE)
                                    .NotEmpty().WithMessage("تاریخ شروع به کار نباید خالی باشد")
                                    .MaximumLength(8).WithMessage("تاریخ شروع به کار نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_OCP()
        {
            RuleFor(dskwor00 => dskwor00.DSW_OCP)
                                    .MaximumLength(100).WithMessage("شرح شغل نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_NAT()
        {
            RuleFor(dskwor00 => dskwor00.DSW_NAT)
                                    .MaximumLength(10).WithMessage("ملیت نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_SEX()
        {
            RuleFor(dskwor00 => dskwor00.DSW_SEX)
                                    .MaximumLength(3).WithMessage("جنسیت نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Must(DSW_SEX => DSW_SEX == "مرد" || DSW_SEX == "زن").WithMessage("مقدار فیلد جنسیت فقط میتواند شامل مرد یا زن باشد");
        }

        private void RuleForDSW_BDATE()
        {
            RuleFor(dskwor00 => dskwor00.DSW_BDATE)
                                    .MaximumLength(8).WithMessage("تاریخ تولد نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_IDATE()
        {
            RuleFor(dskwor00 => dskwor00.DSW_IDATE)
                                    .MaximumLength(8).WithMessage("تاریخ صدور نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_IDPLC()
        {
            RuleFor(dskwor00 => dskwor00.DSW_IDPLC)
                                    .MaximumLength(100).WithMessage("محل صدور نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_IDNO()
        {
            RuleFor(dskwor00 => dskwor00.DSW_IDNO)
                                    .NotEmpty().WithMessage("شماره شناسنامه نباید خالی باشد")
                                    .MaximumLength(15).WithMessage("شماره شناسنامه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_DNAME()
        {
            RuleFor(dskwor00 => dskwor00.DSW_DNAME)
                                    .MaximumLength(40).WithMessage("نام پدر نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_LNAME()
        {
            RuleFor(dskwor00 => dskwor00.DSW_LNAME)
                                    .NotEmpty().WithMessage("نام خانوادگی نباید خالی باشد")
                                    .MaximumLength(40).WithMessage("نام خانوادگی نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_FNAME()
        {
            RuleFor(dskwor00 => dskwor00.DSW_FNAME)
                                    .NotEmpty().WithMessage("نام نباید خالی باشد")
                                    .MaximumLength(40).WithMessage("نام نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSW_ID1()
        {
            RuleFor(dskwor00 => dskwor00.DSW_ID1)
                                    .NotEmpty().WithMessage("شماره بیمه نباید خالی باشد")
                                    .MaximumLength(10).WithMessage("شماره بیمه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_LISTNO()
        {
            RuleFor(dskwor00 => dskwor00.DSW_LISTNO)
                                    .MaximumLength(12).WithMessage("شماره لیست نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_MM()
        {
            RuleFor(dskwor00 => dskwor00.DSW_MM)
                                    .NotEmpty().WithMessage("ماه عملکرد نباید خالی باشد")
                                    .MaximumLength(2).WithMessage("ماه عملکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_YY()
        {
            RuleFor(dskwor00 => dskwor00.DSW_YY)
                                    .NotEmpty().WithMessage("سال عملکرد نباید خالی باشد")
                                    .MaximumLength(2).WithMessage("سال عملکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSW_ID()
        {
            RuleFor(dskwor00 => dskwor00.DSW_ID)
                                    .NotEmpty().WithMessage("کد کارگاه نباید خالی باشد")
                                    .MaximumLength(10).WithMessage("کد کارگاه نباید بیشتر از {MaxLength} کاراکتر باشد")
                                    .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }
    }

    internal class DSKWOR00ListValidation : AbstractValidator<DSKWOR00List>
    {
        public DSKWOR00ListValidation()
        {
            RuleForEach(dskwor00s => dskwor00s.DSKWOR00s).SetValidator(new DSKWOR00Validation());
        }
    }
}