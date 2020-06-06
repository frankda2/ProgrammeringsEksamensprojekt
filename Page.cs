using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Page
    {
        static bool defined = false;

        public static Page MenuPage = new Page(); //Should not be public
        public static Page ProductRegistrationPage = new Page(); //Should not be public
        public static Page ProductOverviewPage = new Page(); //Should not be public

        //List for storing PageElement's
        public List<PageElement> pageElementList = new List<PageElement>(); //Should not be public

        static readonly string[] characterSet1 = { "──", "│", "┌", "┐", "└", "┘" };
        static readonly string[] characterSet2 = { "══", "║", "╔", "╗", "╚", "╝" };

        static void MenuDefine()
        {
            MenuPage.AddPageElement(0, 30, 14, 1 + 40, 1 + 4, "Menu");
            MenuPage.AddPageElement(4, 28, 2, 2 + 40, 4 + 4, "Product overview");
            MenuPage.AddPageElement(3, 28, 2, 2 + 40, 8 + 4, "Registration of new products");
            MenuPage.AddPageElement(6, 28, 1, 2 + 40, 13 + 4, "Exit");
        }

        static void ProductRegistrationDefine()
        {
            ProductRegistrationPage.AddPageElement(0, 30, 29, 1 + 40, 1 + 4, "Registration of new products");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2 + 40, 4 + 4, "Name:");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2 + 40, 9 + 4, "Product number:");
            ProductRegistrationPage.AddPageElement(2, 28, 3, 2 + 40, 14 + 4, "Amount:");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2 + 40, 19 + 4, "Location:");
            ProductRegistrationPage.AddPageElement(7, 28, 1, 2 + 40, 24 + 4, "Register product");
            ProductRegistrationPage.AddPageElement(5, 28, 1, 2 + 40, 28 + 4, "<Back");
        }

        static void ProductListDefine()
        {
            ProductOverviewPage.pageElementList.Clear();
            ProductOverviewPage.AddPageElement(0, 30, Convert.ToInt32(DatabaseInterface.CountItems()) + 8, 1 + 40, 1 + 4, "Product overview");
            ProductOverviewPage.AddPageElement(0, 28, Convert.ToInt32(DatabaseInterface.CountItems()), 2 + 40, 4 + 4, "Product list");
            ProductOverviewPage.AddPageElement(5, 28, 1, 2 + 40, Convert.ToInt32(DatabaseInterface.CountItems()) + 11, "<Back");
        }

        //Move to PageElement?
        void AddPageElement(int function, int width, int height, int startX, int startY, string text)
        {
            PageElement Element = new PageElement(function, width, height, startX, startY, text);
            pageElementList.Add(Element);
        }

        //Draws a menu set, from a list of PageElement's
        static void DrawMenu(List<PageElement> pageElementList)
        {
            foreach (PageElement pageElement in pageElementList)
            {
                DrawBox(pageElement, characterSet1);
            }
        }

        static void DrawBox(PageElement pageElement, string[] characterSet) //Takes PageElement's and draws them
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

        public static void Menu(Page page)
        {
            if (!defined)
            {
                MenuDefine();
                ProductRegistrationDefine();
                defined = true;
            }
            ProductListDefine();

            ConsoleKeyInfo key;
            int indexer = 1;

            //Initial menu draw
            DrawMenu(page.pageElementList);
            DrawBox(page.pageElementList[indexer], characterSet2);

            do
            {
                key = Console.ReadKey(true);

                if (key.Key.ToString() == "UpArrow" && indexer > 1)
                {
                    DrawBox(page.pageElementList[indexer], characterSet1);
                    indexer--;
                    DrawBox(page.pageElementList[indexer], characterSet2);
                }
                else if (key.Key.ToString() == "DownArrow" && indexer < page.pageElementList.Count() - 1)
                {
                    DrawBox(page.pageElementList[indexer], characterSet1);
                    indexer++;
                    DrawBox(page.pageElementList[indexer], characterSet2);
                }

            } while (key.KeyChar != 13);

            page.pageElementList[indexer].PageElementFunction();
        }
    }
}
