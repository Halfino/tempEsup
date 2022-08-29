using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace tempEsup
{
    class SquawkCounter
    {
        public SquawkCounter() { }

        public int countSquawk(int min, int max, int previous)
        {
            int nextSquawk;
            List<String> assignedSquawks = new List<String>();
            WhazzupParser parser = new WhazzupParser();

                assignedSquawks = parser.getSquawks(Path.Combine(Environment.CurrentDirectory, @"Data\", "whazzup.json"));


            if (previous == 4327 || previous == 3326) //rozsireni banky pro LKTB_TWR
            {
                min = 3326;
                max = 3327;
            }

            if(hasFree(min, max, assignedSquawks) == true)
            {
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

                if (assignedSquawks.Contains(nextSquawk.ToString()) || nextSquawk.ToString().Contains(8.ToString()) || nextSquawk.ToString().Contains(9.ToString()))
                {

                    return countSquawk(min, max, nextSquawk);
                }
                if (nextSquawk == 3333 || nextSquawk == 3334)
                {
                    return countSquawk(min, max, nextSquawk);
                }
                return nextSquawk;
            }
            else
            {
                return 0000;
            }
        }
       
        private bool hasFree(int min, int max, List<String> occupiedBank)
        {
            bool result = false;
            for (int i = min; i < max; i++)
            {
                if (!occupiedBank.Contains(i.ToString("D4")))
                {
                    result = true;                 
                }
            }

            if (result == false)
            {
                if(min == 3310) // Pokud je volennka z LKPR dle minimálního SQ, vyhodí hlášku z ifu. Jinak obecnou.
                {
                    MessageBox.Show("Zvolená banka je plná. Použij manuálně SQUAWK v rozsahu 5170 - 5173");
                }
                else
                {
                    MessageBox.Show("Zvolená banka SQUAWK je obsazena. Zvolte náhradní.");
                }               
            }
            return result;
        }
    }
}
