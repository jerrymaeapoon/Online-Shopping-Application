using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartProcess;

namespace UI
{
    public class TableLayout
    {

        public static void ItemTable()
        {


            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Select items from below: ");
            Console.WriteLine();

            PrintLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tItems\t\t\t\tPrices");
            Console.ResetColor();
            PrintLine();
            Console.WriteLine("\t\tBibbed top\t\t\t250");
            Console.WriteLine("\t\tOversized jacket\t\t500");
            Console.WriteLine("\t\tJersery top\t\t\t150");
            Console.WriteLine("\t\tCardigan top\t\t\t180");
            Console.WriteLine("\t\tBoxy top\t\t\t225");
            Console.WriteLine("\t\tHalterneck dress\t\t220");
            Console.WriteLine("\t\tPuffsleeve dress\t\t450");
            Console.WriteLine("\t\tDenim dress\t\t\t300");
            Console.WriteLine("\t\tWidetrouserspants\t\t800");

        }

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', Layouts.tableWidth));
        }

    }
}
