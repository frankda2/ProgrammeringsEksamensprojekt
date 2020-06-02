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
			/*
			Item item = new Item("12345678");

			Console.WriteLine(item.ItemNo);
			Console.WriteLine(item.Name);*/

			Location location = new Location(1);

			Console.WriteLine(location.Name);
			
			location = new Location(15);

			Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
