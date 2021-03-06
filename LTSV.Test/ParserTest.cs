using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LTSV.Test
{
	[TestFixture]
	public class ParserTest
	{
		[Test]
		public void parse_line ()
		{
			Record record = Parse.Line("host:127.0.0.1\tident:-\tuser:frank\ttime:[10/Oct/2000:13:55:36 -0700]\treq:GET /apache_pb.gif HTTP/1.0\tstatus:200\tsize:2326\treferer:http://www.example.com/start.html\tua:Mozilla/4.08 [en] (Win98; I ;Nav)");
			Assert.That(record["host"], Is.EqualTo("127.0.0.1"));
			Assert.That(record["ident"], Is.EqualTo("-"));
			Assert.That(record["user"], Is.EqualTo("frank"));
			Assert.That(record["time"], Is.EqualTo("[10/Oct/2000:13:55:36 -0700]"));
			Assert.That(record["req"], Is.EqualTo("GET /apache_pb.gif HTTP/1.0"));
			Assert.That(record["status"], Is.EqualTo("200"));
			Assert.That(record["size"], Is.EqualTo("2326"));
			Assert.That(record["referer"], Is.EqualTo("http://www.example.com/start.html"));
			Assert.That(record["ua"], Is.EqualTo("Mozilla/4.08 [en] (Win98; I ;Nav)"));
            Console.WriteLine(record);
		}
        [Test]
        public void serialize_line()
        {
            Sample instance = new Sample();
            instance.Host = "127.0.0.1";
            instance.Status = 200;
            string line = Build.Line(instance);
            Assert.That(line,Is.EqualTo("Host:127.0.0.1\tStatus:200"));
        }
        [Test]
        public void deserialize_line()
        {
            Sample sample = Parse.Line<Sample>("Host:127.0.0.1\tStatus:200");
            Assert.That(sample.Host, Is.EqualTo("127.0.0.1"));
            Assert.That(sample.Status, Is.EqualTo(200));
        }
        [Test]
		public void parse_end_of_new_line ()
		{
			Record record = Parse.Line("host:127.0.0.1\tident:-\tuser:frank\ttime:[10/Oct/2000:13:55:36 -0700]\treq:GET /apache_pb.gif HTTP/1.0\tstatus:200\tsize:2326\treferer:http://www.example.com/start.html\tua:Mozilla/4.08 [en] (Win98; I ;Nav)\n");
			Assert.That(record["host"], Is.EqualTo("127.0.0.1"));
			Assert.That(record["ident"], Is.EqualTo("-"));
			Assert.That(record["user"], Is.EqualTo("frank"));
			Assert.That(record["time"], Is.EqualTo("[10/Oct/2000:13:55:36 -0700]"));
			Assert.That(record["req"], Is.EqualTo("GET /apache_pb.gif HTTP/1.0"));
			Assert.That(record["status"], Is.EqualTo("200"));
			Assert.That(record["size"], Is.EqualTo("2326"));
			Assert.That(record["referer"], Is.EqualTo("http://www.example.com/start.html"));
			Assert.That(record["ua"], Is.EqualTo("Mozilla/4.08 [en] (Win98; I ;Nav)"));
		}
		[Test]
		public void parse_end_of_line_feed_new_line ()
		{
			Record record = Parse.Line("host:127.0.0.1\tident:-\tuser:frank\ttime:[10/Oct/2000:13:55:36 -0700]\treq:GET /apache_pb.gif HTTP/1.0\tstatus:200\tsize:2326\treferer:http://www.example.com/start.html\tua:Mozilla/4.08 [en] (Win98; I ;Nav)\r\n");
			Assert.That(record["host"], Is.EqualTo("127.0.0.1"));
			Assert.That(record["ident"], Is.EqualTo("-"));
			Assert.That(record["user"], Is.EqualTo("frank"));
			Assert.That(record["time"], Is.EqualTo("[10/Oct/2000:13:55:36 -0700]"));
			Assert.That(record["req"], Is.EqualTo("GET /apache_pb.gif HTTP/1.0"));
			Assert.That(record["status"], Is.EqualTo("200"));
			Assert.That(record["size"], Is.EqualTo("2326"));
			Assert.That(record["referer"], Is.EqualTo("http://www.example.com/start.html"));
			Assert.That(record["ua"], Is.EqualTo("Mozilla/4.08 [en] (Win98; I ;Nav)"));
		}
		[Test]
		public void parse_file ()
		{
			IEnumerable<Record> records = Parse.File("sample.ltsv");
			List<Record> list = new List<Record>(records);

			Record record = list[0];
			Assert.That(record["host"], Is.EqualTo("127.0.0.1"));
			Assert.That(record["ident"], Is.EqualTo("-"));
			Assert.That(record["user"], Is.EqualTo("frank"));
			Assert.That(record["time"], Is.EqualTo("[10/Oct/2000:13:55:36 -0700]"));
			Assert.That(record["req"], Is.EqualTo("GET /apache_pb.gif HTTP/1.0"));
			Assert.That(record["status"], Is.EqualTo("200"));
			Assert.That(record["size"], Is.EqualTo("2326"));
			Assert.That(record["referer"], Is.EqualTo("http://www.example.com/start.html"));
			Assert.That(record["ua"], Is.EqualTo("Mozilla/4.08 [en] (Win98; I ;Nav)"));

			record = list[1];
			Assert.That(record["host"], Is.EqualTo("127.0.0.1"));
			Assert.That(record["ident"], Is.EqualTo("-"));
			Assert.That(record["user"], Is.EqualTo("frank"));
			Assert.That(record["time"], Is.EqualTo("[10/Oct/2000:13:55:36 -0700]"));
			Assert.That(record["req"], Is.EqualTo("GET /apache_pb.gif HTTP/1.0"));
			Assert.That(record["status"], Is.EqualTo("200"));
			Assert.That(record["size"], Is.EqualTo("2326"));
			Assert.That(record["referer"], Is.EqualTo("http://www.example.com/start.html"));
			Assert.That(record["ua"], Is.EqualTo("Mozilla/4.08 [en] (Win98; I ;Nav)"));
			Assert.That(record["test"], Is.EqualTo("sample"));
		}

        [Test]
        public void create_line()
        {
            Record record = new Record();
            record["test"] = "sample";
            record["foo"] = "bar";
            Assert.That(record.ToString(), Is.EqualTo("test:sample\tfoo:bar"));
        }
	}

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
}

