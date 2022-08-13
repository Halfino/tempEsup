using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;

namespace tempEsup
{
    class WhazzupParser
    {
        public WhazzupParser() { }

        public List<String> getSquawks(string filePath)
        {
            List<String> assignedSquawks = new List<String>();


                StreamReader r = new StreamReader(filePath);
                string jsonString = r.ReadToEnd();

                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    JsonElement root = document.RootElement;
                    JsonElement clientsElement = root.GetProperty("clients");
                    JsonElement pilotElement = clientsElement.GetProperty("pilots");


                    foreach (JsonElement pilot in pilotElement.EnumerateArray())
                    {
                        JsonElement track = pilot.GetProperty("lastTrack");
                        int squawk = track.GetProperty("transponder").GetInt32();

                        assignedSquawks.Add(squawk.ToString());
                    }

                }
            

            return assignedSquawks;
        }
    }
}
