using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Collections;

namespace D1T2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            //CheckFile(filename);

            int numEntries = CountEntries(filename);
            int[] values = new int[numEntries];

            ReadFile(filename, values);
            CountDeeper(numEntries, values);

            ReadLine();

        }

        private static void CountDeeper(int numEntries, int[] values)
        {
            int tally = 0;
            for (int i = 0; i < numEntries - 1; i++)
            {
                if (values[i + 1] > values[i]) { tally++; }
            }
            WriteLine(tally);
        }

        private static void ReadFile(string filename, int[] values)
        {
            StreamReader SR = new StreamReader(filename);

            int x = 0;
            while (!SR.EndOfStream)
            {

                int val = Convert.ToInt32(SR.ReadLine());
                values[x] = val;
                x++;
            }
            SR.Close();
        }

        private static void CheckFile(string filename) //For future use.
        {

            if (File.Exists(filename))
            {
                WriteLine("File Exists");
                WriteLine("File was created " + File.GetCreationTime(filename));
                WriteLine("File was laast written to " + File.GetLastWriteTime(filename));
            }
            else
            {
                WriteLine("File does not exist.");
            }

        }

        private static int CountEntries(string filename)
        {
            var file = new StreamReader(filename).ReadToEnd();
            var lines = file.Split(new char[] { '\n' });
            var count = lines.Length;
            return count - 1;

        }


    }
}

