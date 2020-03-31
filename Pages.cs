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

        public static void DrawBox(int width, int height, int startX, int startY)
        {
            //Multiplying by 2 to make sqaures instead of rectangles, as a single character heigth equals two character width
            startX = startX * 2;
            //Sets specified startposition
            Console.SetCursorPosition(startX, startY);
            //Upper left cornerpiece
            Console.Write("╔");
            //for-loop for horizontal lines
            for (int i = 0; i < width; i++)
            {
                Console.Write("══");
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + (height + 1));
                Console.Write("══");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (height + 1));
            }
            //Upper right cornerpiece
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
            //Lower left cornerpiece
            Console.Write("╚");
            //Position for lower right cornerpiece
            Console.SetCursorPosition(startX + 1 + (width * 2), startY + 1 + height);
            //Lower right cornerpiece
            Console.Write("╝");
            Console.ReadKey();
        }
    }
}
