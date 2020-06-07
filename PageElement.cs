using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class PageElement
    {
        //Constructor for PageElement, width and startX timed by 2 as two console width equals the same length, as one console height length 
        public PageElement(int function, int width, int height, int startX, int startY, string text)
        {
            this.function = function;
            Width = width * 2;
            Height = height;
            StartX = startX * 2;
            StartY = startY;
            Text = text;
        }

        //Readonly private integer for storing this specific PageElements function, defined once in constructor
        readonly private int function;
        public int Width { get; set; }
        public int Height { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string Text { get; set; }

        //String and int for storing database inputs
        private string stringInputToDatabase;
        private int intInputToDatabase = 0;

        //Bool for keeping track of product removing in database
        public static bool productRemoved = true;

        //Width of menu application
        static readonly int lineWidth = 56;

        //Method for limiting the amount of characters being typed at a input
        string LimitCharacterAmount(int limit)
        {
            Console.SetCursorPosition(StartX + 1, StartY + 2);

            //Empty string for storing final output
            string str = string.Empty;

            do
            {
                //reads next key input as a char value
                char c = Console.ReadKey().KeyChar;

                if (c == 13) //Enter
                {
                    //Stops input if enter is pressed
                    break;
                }else if (c == 8) //Backspace
                {
                    int x = Console.CursorLeft;
                    int y = Console.CursorTop;
                    if (str.Length > 0)
                    {
                        str = str.Remove(str.Length - 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        Console.SetCursorPosition(x + 1, y);
                    }
                }
                else
                {
                    //Adds char to string final string
                    str += c;
                }
            } while (str.Length < limit); //Ends loop when character limit is reached

            //Returns completed string
            return str;
        }

        //Method for controlling the individual function of each PageElement
        public void PageElementFunction()
        {
            switch (function)
            {
                case 1:
                    //Text input field

                    //Clears current line
                    Console.WriteLine(new string(' ', lineWidth));
                    //Makes console cursor visible
                    Console.CursorVisible = true;
                    //Reads input
                    stringInputToDatabase = LimitCharacterAmount(20);
                    //Makes console cursor invisible
                    Console.CursorVisible = false;
                    //Goes back to menu
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

                case 2:
                    //Numeric input field

                    Console.WriteLine(new string(' ', lineWidth));
                    Console.SetCursorPosition(StartX + 1, StartY + 2);
                    Console.CursorVisible = true;

                    //Variables for parsing string to int
                    int parsed;
                    string str;

                    //do-while loop for tryparse until succes
                    do
                    {
                        Console.SetCursorPosition(StartX + 1, StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth));
                        str = LimitCharacterAmount(7);
                    } while (int.TryParse(str, out parsed) == false);

                    //Saves parsed output
                    intInputToDatabase = parsed;

                    Console.CursorVisible = false;
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

                case 3:
                    //Go to ProductRegistrationPage
                    Console.Clear();
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

                case 4:
                    //Go to ProductOverviewPage
                    Console.CursorVisible = false;
                    Console.Clear();
                    Console.SetCursorPosition(StartX + 1, StartY + 3);
                    Page.PrintAllProducts();
                    Page.Menu(Page.ProductOverviewPage);
                    break;

                case 5:
                    //Go to MenuPage
                    Console.Clear();
                    Page.Menu(Page.MenuPage);
                    break;

                case 6:
                    //Exit application
                    Environment.Exit(0);
                    break;

                case 7:
                    //Delete product from product number

                    //Product number input
                    Console.CursorVisible = true;
                    string productNo = LimitCharacterAmount(20);
                    Console.CursorVisible = false;

                    Console.SetCursorPosition(StartX - 1, StartY + 9);

                    //Removes specified product from database if possible
                    Item product = new Item(productNo);
                    product.RemoveFromDB();

                    if (productRemoved)
                    {
                        //Updates page if a product was cleared from the database
                        Console.Clear();
                        Console.SetCursorPosition(StartX + 1, StartY - 3 - Convert.ToInt32(DatabaseInterface.CountItems()));
                        Page.PrintAllProducts();
                    }
                    else
                    {
                        //Clears product numberinput line
                        Console.SetCursorPosition(StartX + 1, StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth));
                    }
                    Page.Menu(Page.ProductOverviewPage);
                    break;

                case 8:
                    //Registers new product if inputs are not empty
                    if (!string.IsNullOrEmpty(Page.ProductRegistrationPage.pageElementList[2].stringInputToDatabase) && 
                        !string.IsNullOrEmpty(Page.ProductRegistrationPage.pageElementList[1].stringInputToDatabase) && 
                        !string.IsNullOrEmpty(Page.ProductRegistrationPage.pageElementList[4].stringInputToDatabase))
                    {
                        new Item(Page.ProductRegistrationPage.pageElementList[2].stringInputToDatabase,
                                 Page.ProductRegistrationPage.pageElementList[1].stringInputToDatabase,
                                 Page.ProductRegistrationPage.pageElementList[3].intInputToDatabase,
                                 Page.ProductRegistrationPage.pageElementList[4].stringInputToDatabase);
                    }

                    //Clears product value input lines
                    for (int i = 1; i < 5; i++)
                    {
                        Console.SetCursorPosition(Page.ProductRegistrationPage.pageElementList[i].StartX + 1, Page.ProductRegistrationPage.pageElementList[i].StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth));
                    }

                    Page.Menu(Page.ProductRegistrationPage);
                    break;

            }
        }
    }
}
