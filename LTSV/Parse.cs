using System.Collections.Generic;
using System.IO;

namespace LTSV
{
    public static class Parse
	{
		public static Record Line(string line)
		{
			return Deserialize.Line(line);
		}
        public static T Line<T>(string line)
        {
            return Deserialize.Line<T>(line);
        }

        public static IEnumerable<Record> File(string file)
        {
            return File<Record>(file, Deserialize.Line);
        }
        public static IEnumerable<T> File<T>(string file)
        {
            return File<T>(file, Deserialize.Line<T>);
        }
        private static IEnumerable<T> File<T>(string file, ConvertFunc<string, T> func)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    yield return func(line);
                }
            }
        }

        public static IEnumerable<Record> File(TextReader reader)
        {
            return File<Record>(reader, Deserialize.Line);
        }
        public static IEnumerable<T> File<T>(TextReader reader)
        {
            return File<T>(reader, Deserialize.Line<T>);
        }
        private static IEnumerable<T> File<T>(TextReader reader, ConvertFunc<string,T>  func)
        {
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                yield return func(line);
            }
        }
    }
}

