using System;
using System.Collections.Generic;
using System.IO;

namespace LTSV
{
	public static class Parser
	{
		public static Record Line(string line)
		{
			return LineParser.Parse(line);
		}

		public static IEnumerable<Record> File (string file)
		{
			using (StreamReader reader = new StreamReader(file)) {
				while(!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					if(string.IsNullOrEmpty(line))
					{
						continue;
					}
					yield return LineParser.Parse(line);
				}
			}
		}
	}
}

