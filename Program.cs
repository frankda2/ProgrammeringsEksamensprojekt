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

        static void Startup()
        {
            Console.WriteLine("");
            Console.ReadKey();
            Console.CursorVisible = false;
            Page.Menu(Page.MenuPage);
        }
    }
}
