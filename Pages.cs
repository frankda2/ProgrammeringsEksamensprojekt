using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Pages
    {
        //List for storing PageElement's            Invert selected box, with single box draw method, indexer - never draw 0 as it would be the sorrounding box
        static public List<PageElement> PageElementList { get; private set; } = new List<PageElement>(); //Remove static if more pages are needed

        public static void DrawBox(List<PageElement> pageElementList) //Requires the full list of page elements
        {
            foreach(PageElement pageElement in pageElementList)
            {
                //Multiplying by 2 to make sqaures instead of rectangles, since a single character height equals two character width
                pageElement.StartX *= 2;
                //Sets specified startposition
                Console.SetCursorPosition(pageElement.StartX, pageElement.StartY);
                //Upper left corner piece
                Console.Write("╔");
                //for-loop for horizontal lines
                for (int i = 0; i < pageElement.Width; i++)
                {
                    Console.Write("══");
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + (pageElement.Height + 1));
                    Console.Write("══");
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (pageElement.Height + 1));
                }
                //Upper right corner piece
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
                //Lower left corner piece
                Console.Write("╚");
                //Position for lower right corner piece
                Console.SetCursorPosition(pageElement.StartX + 1 + (pageElement.Width * 2), pageElement.StartY + 1 + pageElement.Height);
                //Lower right corner piece
                Console.Write("╝");

                Console.SetCursorPosition(pageElement.StartX + 1, pageElement.StartY + 1);
                Console.Write(pageElement.Text);
            }
        }
    }
}
