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
            PageElement Element1 = new PageElement(4, 4, 4, 4);
            PageElement Element2 = new PageElement(3, 3, 10, 10);
            Pages.PageElementArray[0] = Element1;
            Pages.PageElementArray[1] = Element2;
            Pages.DrawBox(Pages.PageElementArray);
            Console.ReadKey();
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
