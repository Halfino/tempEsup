using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempEsup
{
    class SquawkCounter
    {
        public SquawkCounter() { }

        public int countSquawk(int min, int max, int previous)
        {
            int nextSquawk;
            if (Enumerable.Range(min, max).Contains(previous))
            {
                nextSquawk = previous + 1;
            }
            else
            {
                nextSquawk = min;
            }
            if (nextSquawk > max)
            {
                nextSquawk = min;
            }

            Globals.previous = nextSquawk;
            WhazzupParser parser = new WhazzupParser();
            List<String> assignedSquawks = parser.getSquawks(Path.Combine(Environment.CurrentDirectory, @"Data\", "whazzup.txt"));
            if (assignedSquawks.Contains(nextSquawk.ToString()))
            {
                return countSquawk(min, max, nextSquawk);
            }
            return nextSquawk;
        }


    }
}
