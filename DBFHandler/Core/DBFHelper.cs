using dBASE.NET;
using DBFHandler.Core.Fields;
using DBFHandler.Core.Models;
using DBFHandler.Core.Validations;
using DBFHandler.Tools.Convertors;
using DBFHandler.Tools.Convertors.IranSystemConvertor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DBFHandler.Core
{

    public class DBFHelper
    {
        /// <summary>
        /// Arabic 1256 text encoding code page
        /// </summary>
        private const int Arabic1256 = 1256;

        private readonly Encoding Arabic1256Encoding = Encoding.GetEncoding(Arabic1256);

        private readonly Dictionary<string, int> DSKKAR00FieldsIndex = DSKKAR00Field.ToList().ToDictionary(x => x.Value.Name, x => x.Key);
        private readonly Dictionary<string, int> DSKWOR00FieldsIndex = DSKWOR00Field.ToList().ToDictionary(x => x.Value.Name, x => x.Key);
        private Dbf dbf;

        public DBFHelper()
        {
            dbf = new Dbf(Arabic1256Encoding);
        }

        public DataTable ReadDbfFile(string filePath)
        {
            var path = Path.GetDirectoryName(filePath);
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("آدرس فایل ورودی معتبر نمی باشد.");
            }

            dbf.Read(filePath);

            DataTable dtResult = new DataTable();
            WriteToDataTable(dtResult);

            dtResult = new ConvertToUnicode().ConvertIranSystemToUnicode(dtResult);

            return dtResult;
        }

        /// <summary>
        /// ساخت فایل اطلاعات کارگاه برای دیسکت بیمه
        /// </summary>
        /// <param name="data"></param>
        /// <param name="directoryPath">نام آدرس ذخیره سازی</param>
        public void CreateDSKKAR00File(DataTable data, string directoryPath)
        {
            var filePath = Path.GetDirectoryName(directoryPath);
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("آدرس ورودی معتبر نمی باشد.");
            }

            AddDSKKAR00Fields();

            ValidateDSKKAR00List(data);

            data = new ConvertToIranSystem().ConvertUnicodeToIranSystem(data);

            AddDataToDbf(data, DSKKAR00FieldsIndex);

            dbf.Write(directoryPath + @"\DSKKAR00.DBF", DbfVersion.FoxBaseDBase3NoMemo);
        }



        /// <summary>
        /// ساخت فایل اطلاعات بیمه شدگان برای دیسکت بیمه
        /// </summary>
        /// <param name="data"></param>
        /// <param name="directoryPath">نام آدرس ذخیره سازی</param>
        public void CreateDSKWOR00File(DataTable data, string directoryPath)
        {
            var filePath = Path.GetDirectoryName(directoryPath);
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("آدرس ورودی معتبر نمی باشد.");
            }

            AddDSKWOR00Fields();

            ValidateDSKWOR00List(data);

            data = new ConvertToIranSystem().ConvertUnicodeToIranSystem(data);

            AddDataToDbf(data, DSKWOR00FieldsIndex);

            dbf.Write(directoryPath + @"\DSKWOR00.DBF", DbfVersion.FoxBaseDBase3NoMemo);
        }



        private void AddDataToDbf(DataTable data, Dictionary<string, int> fieldIndex)
        {
            foreach (DataRow row in data.Rows)
            {
                DbfRecord record = dbf.CreateRecord();
                foreach (var field in dbf.Fields)
                {
                    var type = Enum.GetName(typeof(DbfFieldType), field.Type);
                    record.Data[fieldIndex[field.Name]] = Convert.ChangeType(row[field.Name], DBTypeConvertor.DBTypes(type));
                }
            }
        }

        private void AddDSKKAR00Fields()
        {
            var fields = DSKKAR00Field.ToList();

            if (dbf.Fields.Count == 0)
            {
                foreach (var field in fields)
                {
                    dbf.Fields.Add(field.Value);
                }
            }
        }

        private void AddDSKWOR00Fields()
        {
            var fields = DSKWOR00Field.ToList();

            if (dbf.Fields.Count == 0)
            {
                foreach (var field in fields)
                {
                    dbf.Fields.Add(field.Value);
                }
            }

        }

        private void WriteToDataTable(DataTable data)
        {
            foreach (DbfField field in dbf.Fields)
            {
                data.Columns.Add(field.Name, DBTypeConvertor.DBTypes(field.Type.ToString()));
            }
            foreach (DbfRecord record in dbf.Records)
            {
                data.Rows.Add(record.Data.ToArray());
            }
        }

        private void ValidateDSKKAR00List(DataTable data)
        {
            var validator = new DSKKAR00ListValidation();
            var ModelList = new DSKKAR00List();
            ModelList.DSKKAR00s = DataTableConvertor.ConvertToModel<DSKKAR00>(data);
            validator.ValidateAndThrow(ModelList);
        }

        private void ValidateDSKWOR00List(DataTable data)
        {
            var validator = new DSKWOR00ListValidation();
            var ModelList = new DSKWOR00List();
            ModelList.DSKWOR00s = DataTableConvertor.ConvertToModel<DSKWOR00>(data);
            validator.ValidateAndThrow(ModelList);
        }

    }
}