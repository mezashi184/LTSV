using System;
using System.Collections.Generic;

namespace LTSV
{
	internal static class LineParser
	{
		public static Record Parse (string line)
		{
			return new Record(GetKeyValuePairs(line));
		}
		static IEnumerable<KeyValuePair<string,string>>GetKeyValuePairs(string line){
			string[] fields = line.Split ('\t');
			foreach (string field in fields) {
				
				int indexOf = field.IndexOf(':');
				if(indexOf <0)
				{
					throw new FormatException("':' is NotFound");
				}
				string key = field.Substring(0,indexOf);
				string value;
				if(field.EndsWith("\r\n"))
				{
					value = field.Substring(indexOf+1,field.Length-indexOf-1-2);
				}
				else if(field.EndsWith("\n"))
				{
					value = field.Substring(indexOf+1,field.Length-indexOf-1-1);
				}
				else 
				{
					value = field.Substring(indexOf+1,field.Length-indexOf-1);
				}
				yield return new KeyValuePair<string, string>(key,value);
			}

		}
	}
}

