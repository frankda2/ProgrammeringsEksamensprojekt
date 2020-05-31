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
            Console.ReadKey();
            Pages.DrawBox(30, 25, 40, 5, "Login");
            Pages.DrawBox(28, 8, 41, 10, "Username:");
            Pages.DrawBox(28, 8, 41, 20, "Password:");
            Console.ReadKey();
        }
    }
}
