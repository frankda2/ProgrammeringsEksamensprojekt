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
            PageElement Element1 = new PageElement(30, 30, 40, 5, "Login");
            PageElement Element2 = new PageElement(28, 8, 41, 10, "Username");
            PageElement Element3 = new PageElement(28, 8, 41, 20, "Password");
            PageElement Element4 = new PageElement(28, 4, 41, 30, "Continue");
            Pages.PageElementList.Add(Element1);
            Pages.PageElementList.Add(Element2);
            Pages.PageElementList.Add(Element3);
            Pages.PageElementList.Add(Element4);
            Pages.DrawBox(Pages.PageElementList);
            Console.ReadKey();
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
