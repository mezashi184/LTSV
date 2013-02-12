using System.Collections.Generic;
using System.Text;

namespace LTSV
{
	public class Record
	{
	    readonly Dictionary<string,string> dic_ = new Dictionary<string, string>();

	    public Record()
	    {
	        
	    }
		internal Record (IEnumerable<KeyValuePair<string,string>> pairs)
		{
			foreach (KeyValuePair<string,string> pair in pairs) {
				dic_[pair.Key]=pair.Value;
			}
		}

		public string this [string key] {
			get{
				return dic_[key];
			}
            set {
                dic_[key] = value;
            }
		}
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<string,string> pair in dic_)
            {
                if(builder.Length > 0)
                {
                    builder.Append("\t");
                }
                builder.AppendFormat("{0}:{1}",pair.Key,pair.Value);
            }
            return builder.ToString();
        }
	}
}

