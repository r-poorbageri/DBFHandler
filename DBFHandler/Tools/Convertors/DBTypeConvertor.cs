using System;

namespace DBFHandler.Tools.Convertors
{
    public static class DBTypeConvertor
    {
        public static Type DBTypes(string type)
        {
            Type dataType;
            switch (type)
            {
                case "Character":
                    dataType = typeof(string);
                    break;
                case "Numeric":
                    dataType = typeof(double);
                    break;
                case "Logical":
                    dataType = typeof(bool);
                    break;
                case "Date":
                    dataType = typeof(DateTime);
                    break;
                case "Integer":
                    dataType = typeof(Int32);
                    break;
                case "Memo":
                    dataType = typeof(string);
                    break;
                case "DateTime":
                    dataType = typeof(DateTime);
                    break;
                case "Currency":
                    dataType = typeof(float);
                    break;
                default:
                    dataType = typeof(string);
                    break;
            }
            return dataType;
        }
    }
}