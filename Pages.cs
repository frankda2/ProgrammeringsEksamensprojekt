using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Pages //Class might be obsolete because of defining in MenuController, consider new menu structure 01-06-2020
    {
        //List for storing PageElement's
        static public List<PageElement> PageElementList { get; private set; } = new List<PageElement>(); //Remove static if more pages are needed

        public static void DrawMenu(List<PageElement> pageElementList) //Requires the full list of page elements
        {
            foreach (PageElement pageElement in pageElementList)
            {
                DrawBox(pageElement, MenuController.characterSet1);
            }
        }

        public static void DrawBox(PageElement pageElement, string[] characterSet) //Takes PageElement's and draws them
        {
            //Sets specified startposition
            Console.SetCursorPosition(pageElement.StartX, pageElement.StartY);

            //Upper left corner piece
            Console.Write(characterSet[2]);

            //for-loop for horizontal lines
            for (int i = 0; i < pageElement.Width / 2; i++)
            {
                Console.Write(characterSet[0]);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + (pageElement.Height + 1));
                Console.Write(characterSet[0]);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - (pageElement.Height + 1));
            }

            //Upper right corner piece
            Console.Write(characterSet[3]);

            //Setting starting position to draw vertical lines
            Console.SetCursorPosition(pageElement.StartX, pageElement.StartY + 1);

            //for-loop for vertical lines
            for (int i = 0; i < pageElement.Height; i++)
            {
                Console.Write(characterSet[1]);
                Console.SetCursorPosition(Console.CursorLeft + pageElement.Width, Console.CursorTop);
                Console.Write(characterSet[1]);
                Console.SetCursorPosition(Console.CursorLeft - (pageElement.Width + 2), Console.CursorTop + 1);
            }

            //Lower left corner piece
            Console.Write(characterSet[4]);

            //Position for lower right corner piece
            Console.SetCursorPosition(pageElement.StartX + 1 + pageElement.Width, pageElement.StartY + 1 + pageElement.Height);

            //Lower right corner piece
            Console.Write(characterSet[5]);

            //Text
            Console.SetCursorPosition(pageElement.StartX + 1, pageElement.StartY + 1);
            Console.WriteLine(pageElement.Text);
            Console.SetCursorPosition(pageElement.StartX + 1, pageElement.StartY + 2);
        }
    }
}
