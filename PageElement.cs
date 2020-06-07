using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class PageElement
    {
        public PageElement(int function, int width, int height, int startX, int startY, string text)
        {
            this.function = function;
            Width = width * 2;
            Height = height;
            StartX = startX * 2;
            StartY = startY;
            Text = text;
        }

        readonly private int function;
        public int Width { get; set; } //Make private get or set?
        public int Height { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string Text { get; set; }

        private string stringInputToDatabase;
        private int intInputToDatabase;

        public static bool productRemoved = true;
        static int lineWidth = 56;

        string LimitCharacterAmount(int limit)
        {
            Console.SetCursorPosition(StartX + 1, StartY + 2);
            string str = string.Empty;
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (c == 13) //Enter
                {
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
                    str += c;
                }
            } while (str.Length < limit);
            return str;
        }

        public void PageElementFunction()
        {
            switch (function)
            {
                case 1:
                    //Text input field
                    Console.WriteLine(new string(' ', lineWidth));

                    Console.CursorVisible = true;

                    this.stringInputToDatabase = LimitCharacterAmount(20);

                    Console.CursorVisible = false;
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

                case 2:
                    //Numeric input field
                    Console.WriteLine(new string(' ', lineWidth));
                    Console.SetCursorPosition(StartX + 1, StartY + 2);

                    Console.CursorVisible = true;

                    int parsed;
                    string str;

                    do
                    {
                        Console.SetCursorPosition(StartX + 1, StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth));
                        str = LimitCharacterAmount(7);
                    } while (int.TryParse(str, out parsed) == false);

                    this.intInputToDatabase = parsed;

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
                    Console.CursorVisible = true;
                    string productNo = LimitCharacterAmount(20);
                    Console.CursorVisible = false;

                    
                    Console.SetCursorPosition(StartX - 1, StartY + 9);
                    Item product = new Item(productNo);
                    product.RemoveFromDB();

                    if (productRemoved)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(StartX + 1, StartY - 3 - Convert.ToInt32(DatabaseInterface.CountItems()));
                        Page.PrintAllProducts();
                    }
                    else
                    {
                        Console.SetCursorPosition(StartX + 1, StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth));
                    }
                    Page.Menu(Page.ProductOverviewPage);
                    break;

                case 8:
                    //Register new product
                    new Item(Page.ProductRegistrationPage.pageElementList[2].stringInputToDatabase,  //Consider PageElement function taking page as parameter
                             Page.ProductRegistrationPage.pageElementList[1].stringInputToDatabase,      //Or moving PageElementFunction to Page.cs
                             Page.ProductRegistrationPage.pageElementList[3].intInputToDatabase, 
                             Page.ProductRegistrationPage.pageElementList[4].stringInputToDatabase);

                    for (int i = 1; i < 5; i++)
                    {
                        Console.SetCursorPosition(Page.ProductRegistrationPage.pageElementList[i].StartX + 1, Page.ProductRegistrationPage.pageElementList[i].StartY + 2);
                        Console.WriteLine(new string(' ', lineWidth)); //Should prob not be a fixed value
                    }
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

            }
        }
    }
}
