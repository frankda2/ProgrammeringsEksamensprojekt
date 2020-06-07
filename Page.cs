using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class Page
    {
        //Bool for keeping track of menu defines
        static bool defined = false;

        //Creating the 3 menu pages
        public static Page MenuPage = new Page();
        public static Page ProductRegistrationPage = new Page();
        public static Page ProductOverviewPage = new Page();

        //List for storing PageElements
        public List<PageElement> pageElementList = new List<PageElement>();

        //Character sets for DrawBox method
        static readonly string[] characterSet1 = { "──", "│", "┌", "┐", "└", "┘" };
        static readonly string[] characterSet2 = { "══", "║", "╔", "╗", "╚", "╝" };

        //Method for adding PageElements to a Page objects pageElementList
        void AddPageElement(int function, int width, int height, int startX, int startY, string text)
        {
            PageElement Element = new PageElement(function, width, height, startX, startY, text);
            pageElementList.Add(Element);
        }

        //Adding PageElements to MenuPage object, to define the look of the main menu
        static void MenuDefine()
        {
            MenuPage.AddPageElement(0, 30, 14, 1, 1, "Menu");
            MenuPage.AddPageElement(4, 28, 2, 2, 4, "Product overview");
            MenuPage.AddPageElement(3, 28, 2, 2, 8, "Registration of new products");
            MenuPage.AddPageElement(6, 28, 1, 2, 13, "Exit");
        }

        //Adding PageElements to ProductRegistrationPage object, to define the look of the registration page
        static void ProductRegistrationDefine()
        {
            ProductRegistrationPage.AddPageElement(0, 30, 29, 1, 1, "Registration of new products");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2, 4, "Name:");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2, 9, "Product number:");
            ProductRegistrationPage.AddPageElement(2, 28, 3, 2, 14, "Amount:");
            ProductRegistrationPage.AddPageElement(1, 28, 3, 2, 19, "Location:");
            ProductRegistrationPage.AddPageElement(8, 28, 1, 2, 24, "Register product");
            ProductRegistrationPage.AddPageElement(5, 28, 1, 2, 28, "<Back");
        }

        //Adding PageElements to ProductOverviewPage object, clears pageElementList each time as this method gets called with each menu update,
        //since a change in the database might have occurred
        static void ProductListDefine()
        {
            ProductOverviewPage.pageElementList.Clear();
            ProductOverviewPage.AddPageElement(0, 30, Convert.ToInt32(DatabaseInterface.CountItems()) + 15, 1, 1, "Product overview");
            ProductOverviewPage.AddPageElement(4, 28, Convert.ToInt32(DatabaseInterface.CountItems()) + 3, 2, 4, "Product list");
            ProductOverviewPage.AddPageElement(7, 28, 2, 2, Convert.ToInt32(DatabaseInterface.CountItems()) + 9, "Remove product - enter product number");
            ProductOverviewPage.AddPageElement(5, 28, 1, 2, Convert.ToInt32(DatabaseInterface.CountItems()) + 14, "<Back");
        }


        //Draws a menu, from a list of PageElements
        static void DrawMenu(List<PageElement> pageElementList)
        {
            foreach (PageElement pageElement in pageElementList)
            {
                DrawBox(pageElement, characterSet1);
            }
        }

        //Method for drawing a box with ASCII characters, from the two character sets defined earlier
        static void DrawBox(PageElement pageElement, string[] characterSet)
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

            //Drawing menu text
            Console.SetCursorPosition(pageElement.StartX + 1, pageElement.StartY + 1);
            Console.WriteLine(pageElement.Text);
            Console.SetCursorPosition(pageElement.StartX + 1, pageElement.StartY + 2);
        }

        //Main method for controlling the programs menu system, takes a specific page as a parameter
        public static void Menu(Page page)
        {
            //Makes sure static pages dont get defined twice
            if (!defined)
            {
                MenuDefine();
                ProductRegistrationDefine();
                defined = true;
            }

            //Gets redefined each time, as a new product might have been added
            ProductListDefine();

            //Object for storing key press
            ConsoleKeyInfo key;

            //Menu index number, always 1 or higher as 0 would cause highligt of the outer sorrounding menu box
            int indexer = 1;

            //Initial menu draw
            DrawMenu(page.pageElementList);
            DrawBox(page.pageElementList[indexer], characterSet2);

            //do-while loop for controlling menu with up and down arrows and enter
            do
            {
                //Reading key input
                key = Console.ReadKey(true);

                //If up arrow is pressed and the index is higher than 1 - to prevent selection of outer box
                if (key.Key.ToString() == "UpArrow" && indexer > 1)
                {
                    //Draw box with character set 1 (non-highlight)
                    DrawBox(page.pageElementList[indexer], characterSet1);
                    //Go 1 step up in menu system, by decreasing index
                    indexer--;
                    //Draw box with character set 2 (highlight)
                    DrawBox(page.pageElementList[indexer], characterSet2);
                }
                //If down arrow is pressed and the index is lower than the highest menu option
                else if (key.Key.ToString() == "DownArrow" && indexer < page.pageElementList.Count() - 1)
                {
                    DrawBox(page.pageElementList[indexer], characterSet1);
                    indexer++;
                    DrawBox(page.pageElementList[indexer], characterSet2);
                }

            } while (key.KeyChar != 13); //Ends loop if Enter key is pressed

            //Executes specific PageElement function based on index number
            page.pageElementList[indexer].PageElementFunction();
        }

        //Prints all products in the current database
        public static void PrintAllProducts()
        {
            //Keeping track of x start position
            int xPosition = Console.CursorLeft;

            //storing all products from database in Item list
            Item[] itemList = DatabaseInterface.GetAllItems();

            //Header line for product overview
            Console.Write("Name: \t\tProduct no:\tStock: \tLocation:");
            Console.SetCursorPosition(xPosition, Console.CursorTop + 1);

            //Foreach loop for printing all products in itemList
            foreach (Item item in itemList)
            {
                //Shortening long product names
				string name;
                if (item.Name.Length > 10)
				{
					name = item.Name.Remove(7) + "...";
				}
				else
				{
					name = item.Name;
				}

                //Printing a single product to console
				Console.Write(name + "\t\t" + item.ItemNo.PadRight(10) + "\t" + item.Stock + "\t" + item.GetLocationName());

                //Resetting cursor position
                Console.SetCursorPosition(xPosition, Console.CursorTop + 1);
            }
        }
    }
}
