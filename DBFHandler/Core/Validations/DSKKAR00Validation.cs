using DBFHandler.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFHandler.Core.Validations
{
    internal class DSKKAR00Validation : AbstractValidator<DSKKAR00>
    {
        const string NumericRegexPattern = "^([0-9]*)$";
        const string FloatNumericRegexPattern = "^([0-9]+([.][0-9]*)?|[.][0-9]+)$";

        public DSKKAR00Validation()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleForDSK_ID();
            RuleForDSK_NAME();
            RuleForDSK_FARM();
            RuleForDSK_ADRS();
            RuleForDSK_KIND();
            RuleForDSK_YY();
            RuleForDSK_MM();
            RuleForDSK_LISTNO();
            RuleForDSK_DISC();
            RuleForDSK_NUM();
            RuleForDSK_TDD();
            RuleForDSK_TROOZ();
            RuleForDSK_TMAH();
            RuleForDSK_TMAZ();
            RuleForDSK_TMASH();
            RuleForDSK_TTOTL();
            RuleForDSK_TBIME();
            RuleForDSK_TKOSO();
            RuleForDSK_BIC();
            RuleForDSK_RATE();
            RuleForDSK_PRATE();
            RuleForDSK_BIMH();
            RuleForMON_PYM();
        }

        private void RuleForMON_PYM()
        {
            RuleFor(dskkar00 => dskkar00.MON_PYM)
                           .MaximumLength(12).WithMessage("ردیف پیمان نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_BIMH()
        {
            RuleFor(dskkar00 => dskkar00.DSK_BIMH)
                           .NotEmpty().WithMessage("نرخ مشاغل و سخت و زیان آور نباید خالی باشد")
                           .MaximumLength(12).WithMessage("نرخ مشاغل و سخت و زیان آور نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_PRATE()
        {
            RuleFor(dskkar00 => dskkar00.DSK_PRATE)
                           .NotEmpty().WithMessage("نرخ پورسانتاژ نباید خالی باشد")
                           .MaximumLength(12).WithMessage("نرخ پورسانتاژ نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_RATE()
        {
            RuleFor(dskkar00 => dskkar00.DSK_RATE)
                           .NotEmpty().WithMessage("نرخ حق بیمه نباید خالی باشد")
                           .MaximumLength(5).WithMessage("نرخ حق بیمه نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(FloatNumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_BIC()
        {
            RuleFor(dskkar00 => dskkar00.DSK_BIC)
                           .NotEmpty().WithMessage("مجموع حق بیمه کاری نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع حق بیمه بیکاری نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TKOSO()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TKOSO)
                           .NotEmpty().WithMessage("مجموع حق بیمه سهم کارفرما نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع حق بیمه سهم کارفرما نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TBIME()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TBIME)
                           .NotEmpty().WithMessage("مجموع حق بیمه سهم بیمه شده نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع حق بیمه سهم بیمه شده نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TTOTL()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TTOTL)
                           .NotEmpty().WithMessage("مجموع کل دستمزد و مزایای ماهانه (مشمول و غیر مشمول) نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع کل دستمزد و مزایای ماهانه (مشمول و غیر مشمول) نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TMASH()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TMASH)
                           .NotEmpty().WithMessage("مجموع دستمزد و مزایای ماهانه مشمول نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع دستمزد و مزایای ماهانه مشمول نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TMAZ()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TMAZ)
                           .NotEmpty().WithMessage("مجموع مزایای ماهانه مشمول نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع مزایای ماهانه مشمول نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TMAH()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TMAH)
                           .NotEmpty().WithMessage("مجموع دستمزد ماهانه نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع دستمزد ماهانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TROOZ()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TROOZ)
                           .NotEmpty().WithMessage("مجموع دستمزد روزانه نباید خالی باشد")
                           .MaximumLength(12).WithMessage("مجموع دستمزد روزانه نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_TDD()
        {
            RuleFor(dskkar00 => dskkar00.DSK_TDD)
                           .NotEmpty().WithMessage("مجموع روزهای کارکرد نباید خالی باشد")
                           .MaximumLength(6).WithMessage("مجموع روزهای کارکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_NUM()
        {
            RuleFor(dskkar00 => dskkar00.DSK_NUM)
                           .NotEmpty().WithMessage("تعداد کارکنان نباید خالی باشد")
                           .MaximumLength(5).WithMessage("تعداد کارکنان نباید بیشتر از {MaxLength} کاراکتر باشد")
                           .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_DISC()
        {
            RuleFor(dskkar00 => dskkar00.DSK_DISC)
                          .MaximumLength(100).WithMessage("شرح لیست نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSK_LISTNO()
        {
            RuleFor(dskkar00 => dskkar00.DSK_LISTNO)
                          .MaximumLength(12).WithMessage("شماره لیست نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSK_MM()
        {
            RuleFor(dskkar00 => dskkar00.DSK_MM)
                            .NotEmpty().WithMessage("ماه عملکرد نباید خالی باشد")
                            .MaximumLength(2).WithMessage("ماه عملکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                            .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_YY()
        {
            RuleFor(dskkar00 => dskkar00.DSK_YY)
                            .NotEmpty().WithMessage("سال عملکرد نباید خالی باشد")
                            .MaximumLength(2).WithMessage("سال عملکرد نباید بیشتر از {MaxLength} کاراکتر باشد")
                            .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }

        private void RuleForDSK_KIND()
        {
            RuleFor(dskkar00 => dskkar00.DSK_KIND)
                            .Equal("0").WithMessage("نوع لیس فقط می تواند مقدار 0 را قبول کند");
        }

        private void RuleForDSK_ADRS()
        {
            RuleFor(dskkar00 => dskkar00.DSK_ADRS)
                           .MaximumLength(100).WithMessage("آدرس کارگاه نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSK_FARM()
        {
            RuleFor(dskkar00 => dskkar00.DSK_FARM)
                           .NotEmpty().WithMessage("نام کارفرما نباید خالی باشد")
                           .MaximumLength(100).WithMessage("نام کارفرما نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSK_NAME()
        {
            RuleFor(dskkar00 => dskkar00.DSK_NAME)
                            .NotEmpty().WithMessage("نام کارگاه نباید خالی باشد")
                            .MaximumLength(100).WithMessage("نام کارگاه نباید بیشتر از {MaxLength} کاراکتر باشد");
        }

        private void RuleForDSK_ID()
        {
            RuleFor(dskkar00 => dskkar00.DSK_ID)
                            .NotEmpty().WithMessage("کد کارگاه نباید خالی باشد")
                            .MaximumLength(10).WithMessage("کد کارگاه نباید بیشتر از {MaxLength} کاراکتر باشد")
                            .Matches(NumericRegexPattern).WithMessage("فقط عدد مورد قبول است");
        }
    }

    internal class DSKKAR00ListValidation : AbstractValidator<DSKKAR00List>
    {
        public DSKKAR00ListValidation()
        {
            RuleForEach(dskkar00s => dskkar00s.DSKKAR00s).SetValidator(new DSKKAR00Validation());
        }
    }
}
