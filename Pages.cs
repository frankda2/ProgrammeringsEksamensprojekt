using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Pages
    {
        PageElement[] PageElementArray;

        public static void DrawBox(int width, int height, int startX, int startY, string text)
        {
            //Multiplying by 2 to make squares instead of rectangles, since a single character height equals two character width
            startX *= 2;
            //Sets specified startposition
            Console.SetCursorPosition(startX, startY);
            //Upper left corner piece
            Console.Write("╔");
            //for-loop for horizontal lines
            for (int i = 0; i < width; i++)
            {
                Console.Write("══");
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + (height + 1));
                Console.Write("══");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (height + 1));
            }
            //Upper right corner piece
            Console.Write("╗");
            //Setting starting position to draw vertical lines
            Console.SetCursorPosition(startX, startY + 1);
            //for-loop for vertical lines
            for (int i = 0; i < height; i++)
            {
                Console.Write("║");
                Console.SetCursorPosition(Console.CursorLeft + (width * 2), Console.CursorTop);
                Console.Write("║");
                Console.SetCursorPosition(Console.CursorLeft - (width * 2 + 2), Console.CursorTop + 1);
            }
            //Lower left corner piece
            Console.Write("╚");
            //Position for lower right corner piece
            Console.SetCursorPosition(startX + 1 + (width * 2), startY + 1 + height);
            //Lower right corner piece
            Console.Write("╝");

            Console.SetCursorPosition(startX + 1, startY + 1);
            Console.Write(text);
        }
    }
}
