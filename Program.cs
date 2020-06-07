using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup();
            Console.ReadKey();
        }

        //Controls startup of program
        static void Startup()
        {
            Console.SetWindowSize(66, 34);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;
            Page.Menu(Page.MenuPage);
        }
    }
}
