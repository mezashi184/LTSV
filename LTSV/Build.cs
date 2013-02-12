using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LTSV
{
    public static class Build
    {
        public static string Line(Record record)
        {
            return Serialize.Line(record);
        }

        public static string Line(object obj)
        {
            return Serialize.Line(obj);
        }
        public static string Lines(IEnumerable<Record> records)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Record record in records)
            {
                builder.AppendLine(record.ToString());
            }
            return builder.ToString();
        }

        public static string Lines(IEnumerable<object> records)
        {
            StringBuilder builder = new StringBuilder();
            foreach (object record in records)
            {
                builder.AppendLine(Serialize.Line(record));
            }
            return builder.ToString();
        }

        public static void File(string filePath, Record record)
        {
            File(filePath, One(record));
        }
        public static void File(string filePath, object record)
        {
            File(filePath, One(record));
        }
        public static void File(string filePath, string line)
        {
            File(filePath, One(line));
        }
        public static void File(string filePath, IEnumerable<Record> records)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                File(writer, records);
            }
        }
        public static void File(string filePath, IEnumerable<object> records)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                File(writer, records);
            }
        }
        public static void File(string filePath, IEnumerable<string> lines)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                File(writer,lines);
            }
        }

        public static void File(TextWriter writer, Record record)
        {
            File(writer, One(record));
        }
        public static void File(TextWriter writer, object record)
        {
            File(writer, One(record));
        }
        public static void File(TextWriter writer, string line)
        {
            File(writer, One(line));
        }
        internal static void File(TextWriter writer, IEnumerable<Record> records)
        {
            File(writer, Map<Record, string>(records, Serialize.Line));
        }
        public static void File(TextWriter writer, IEnumerable<object> records)
        {
            File(writer, Map<object, string>(records, Serialize.Line));
        }
        public static void File(TextWriter writer, IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                writer.WriteLine(Serialize.Line(line));
            }
        }

        private static IEnumerable<T> One<T>(T value)
        {
            yield return value;
        }

        private static IEnumerable<U> Map<T, U>(IEnumerable<T> enumerable, ConvertFunc<T, U> func)
        {
            foreach (T t in enumerable)
            {
                yield return func(t);
            }
        }
    }
}