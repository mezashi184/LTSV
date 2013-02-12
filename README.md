# C# LTSV Parser

## Usage
### using
	using LTSV

### parse line
	Record record = Parse.Line("host:127.0.0.1\tident:-\tuser:frank");
	Console.WriteLine(record["host"]); // "127.0.0.1"
	Console.WriteLine(record["ident"]); // "-"
	Console.WriteLine(record["user"]); // "frank"

### parse file
	IEnumerable<Record> records = Parse.Line("host:127.0.0.1\tident:-\tuser:frank");
	foreach (Record record in records)
	{
		Console.WriteLine(record); // "host:127.0.0.1\tident:-\tuser:frank"
	}

### create line
	Record record = new Record();
	record["test"] = "sample";
	record["foo"] = "bar";
	Console.WriteLine(record.ToString()); // "test:sample\tfoo:bar"

### object serialization
    public class Sample
    {
        private string host_;
        public string Host
        {
            get { return host_; }
            set { host_ = value; }
        }
        private int status_;
        public int Status
        {
            get { return status_; }
            set { status_ = value; }
        }
    }

   // Deserialize
    Sample sample = Parse.Line<Sample>("Host:127.0.0.1\tStatus:200");
    Console.WriteLine(sample.Host); // "127.0.0.1"
    Console.WriteLine(sample.Status); // 200

   // Serialize
    string line = Build.Line(sample);
    Console.WriteLine(line); // "Host:127.0.0.1\tStatus:200"



## License
Public Domain

## Author
Nobuyoshi Tachibana.(mezashi184@gmail.com)
