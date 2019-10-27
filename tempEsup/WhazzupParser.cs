using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace tempEsup
{
    class WhazzupParser
    {
        public WhazzupParser() { }

        public List<String> getSquawks(string filePath)
        {
            List<String> assignedSquawks = new List<String>();
            Regex pattern = new Regex(@"^!SERVERS");
            using (StreamReader reader = File.OpenText(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] splitLine = line.Split(':');
                    if (splitLine.Length > 2)
                    {
                        if (splitLine[3] == "PILOT")
                        {
                            int sq = Int32.Parse(splitLine[17]);
                            assignedSquawks.Add(sq.ToString("D4"));
                        }
                    }
                }
            }

            return assignedSquawks;
        }
    }
}
