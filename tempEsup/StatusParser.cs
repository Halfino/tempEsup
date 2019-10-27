using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace tempEsup
{
    class StatusParser
    {
        public StatusParser() { }

        public string parseStatus(string fileUrl)
        {
            string uri = "";
            Regex pattern = new Regex(@"^url0=");
            using (StreamReader reader = File.OpenText(fileUrl))
            {
                string line;
                string toParse = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = pattern.Match(line);
                    if (match.Success)
                    {
                        toParse = line;
                        break;
                    }
                }
                uri = toParse.Remove(0, 5);
            }

            return uri;
        }
    }
}
