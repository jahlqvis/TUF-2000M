using System;
using TUF_2000M;

namespace TUF_2000M.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultUrl = "http://tuftuf.gambitlabs.fi/feed.txt";

            if (args.Length == 0)
            {
                System.Console.WriteLine("Hello Gambit!\n");
                System.Console.WriteLine("This console program written by Johan Ahlqvist\n" +
                    "is able to interpret the data from the TUF-2000M ultrasonic flowmeter\n " +
                    "\n" +
                    "The data is streamed live at http://tuftuf.gambitlabs.fi/feed.txt \n" +
                    "The console program is able to interpret the first 100 registers of\n" +
                    "the Modbus protocal and list the data in appropriate format with description\n" +
                    "and unit according to the TUF-2000M user manual.\n");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("Type tufspy -h for help\n");
            }
            else if(args.Length == 1)
            {
                if(string.Compare(args[0], "-d") == 0)
                {
                    string[] mock1 = System.IO.File.ReadAllLines(@"feed.txt");
                    Reader reader = new Reader(new VariableStorage(), mock1);
                    reader.Run();
                }
                else if(string.Compare(args[0], "-d2") == 0)
                {
                    string[] mock2 = System.IO.File.ReadAllLines(@"feed2.txt");
                    Reader reader = new Reader(new VariableStorage(), mock2);
                    reader.Run();
                }
                else if(string.Compare(args[0], "-l") == 0)
                {
                    Reader reader = new Reader(new VariableStorage());
                    bool result = false;
                    result = reader.ReadURL(defaultUrl);
                    reader.Run();
                }
                else if (string.Compare(args[0], "-url") == 0)
                {
                    System.Console.WriteLine($"The default url the Modbus data is retrieved from is {defaultUrl}\n");
                }
                else if (string.Compare(args[0], "-h") == 0)
                {
                    System.Console.WriteLine($"Hello Gambit! The console program accepts the following commands:\n");
                    System.Console.WriteLine("\n");
                    System.Console.WriteLine($"\t-h\tProvides this listing of available commands\n");
                    System.Console.WriteLine($"\t-d\tRuns the console offline with a mock set of Modbus (example 1)\n");
                    System.Console.WriteLine($"\t-d2\tRuns the console offline with a mock set of Modbus (example 2)\n");
                    System.Console.WriteLine($"\t-l\tRuns with streamed live Modbus data from server\n");
                    System.Console.WriteLine($"\t-l\tShows url of the server where Modbus data is streamed from\n");
                    System.Console.WriteLine("\n");
                }
                else
                {
                    System.Console.WriteLine("-l (live data), -h (help), -url (server address), -d (offline example 1), -d2 (offline example 2)\n");
                }

            }
            else
            {
                System.Console.WriteLine("-l (live data), -h (help), -url (server address), -d (offline example 1), -d2 (offline example 2)\n");
            }

        }
    }
}
