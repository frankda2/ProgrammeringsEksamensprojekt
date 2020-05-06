using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Pages
    {
        static PageElement[] pageElementArray = new PageElement[2]; //For storing all page element class instances

        public static void AddStuff()
        {
            PageElement Element1 = new PageElement(4, 4, 4, 4);
            PageElement Element2 = new PageElement(3, 3, 10, 10);
            pageElementArray[0] = Element1;
            pageElementArray[1] = Element2;
            DrawBox(pageElementArray);
        }

        //Eventuelt opdater med Console.WriteLine(("").PadRight(24, '-'));

        public static void DrawBox(PageElement[] pageElementArray) //Requires the full list of page elements
        {
            foreach(PageElement pageElement in pageElementArray)
            {
                //Multiplying by 2 to make sqaures instead of rectangles, since a single character heigth equals two character width
                pageElement.StartX = pageElement.StartX * 2;
                //Sets specified startposition
                Console.SetCursorPosition(pageElement.StartX, pageElement.StartY);
                //Upper left cornerpiece
                Console.Write("╔");
                //for-loop for horizontal lines
                for (int i = 0; i < pageElement.Width; i++)
                {
                    Console.Write("══");
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + (pageElement.Height + 1));
                    Console.Write("══");
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (pageElement.Height + 1));
                }
                //Upper right cornerpiece
                Console.Write("╗");
                //Setting starting position to draw vertical lines
                Console.SetCursorPosition(pageElement.StartX, pageElement.StartY + 1);
                //for-loop for vertical lines
                for (int i = 0; i < pageElement.Height; i++)
                {
                    Console.Write("║");
                    Console.SetCursorPosition(Console.CursorLeft + (pageElement.Width * 2), Console.CursorTop);
                    Console.Write("║");
                    Console.SetCursorPosition(Console.CursorLeft - (pageElement.Width * 2 + 2), Console.CursorTop + 1);
                }
                //Lower left cornerpiece
                Console.Write("╚");
                //Position for lower right cornerpiece
                Console.SetCursorPosition(pageElement.StartX + 1 + (pageElement.Width * 2), pageElement.StartY + 1 + pageElement.Height);
                //Lower right cornerpiece
                Console.Write("╝");
            }
        }
    }
}
