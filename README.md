# C# LTSV Parser

## Usage
### using
	using LTSV

### parse line
	Record record = Parser.Line("host:127.0.0.1\tident:-\tuser:frank");
	Console.WriteLine(record["host"]); // "127.0.0.1"
	Console.WriteLine(record["ident"]); // "-"
	Console.WriteLine(record["user"]); // "frank"

### parse file
	IEnumerable<Record> records = Parser.Line("host:127.0.0.1\tident:-\tuser:frank");

	foreach (Record record in records)
	{
		Console.WriteLine(record); // "host:127.0.0.1\tident:-\tuser:frank"
	}

### create line
	Record record = new Record();
	record["test"] = "sample";
	record["foo"] = "bar";
	Console.WriteLine(record.ToString()); // "test:sample\tfoo:bar"
