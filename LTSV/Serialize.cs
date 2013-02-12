using System.Reflection;

namespace LTSV
{
    internal static class Serialize
    {
        public static string Line(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            Record record = new Record();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                record[propertyInfo.Name] = propertyInfo.GetValue(obj, null).ToString();
            }
            return record.ToString();
        }

        public static string Line(Record record)
        {
            return record.ToString();
        }
    }
}