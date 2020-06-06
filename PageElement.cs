﻿using System;
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

        int tempInt;
        string tempString;

        string stringInputToDatabase;
        int intInputToDatabase;

        readonly private int function;
        public int Width { get; set; } //Make private get or set
        public int Height { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string Text { get; set; }

        public void PageElementFunction()
        {
            switch (function)
            {
                case 1:
                    //Text input field
                    Console.CursorVisible = true;
                    this.stringInputToDatabase = Console.ReadLine();
                    Console.CursorVisible = false;
                    Page.Menu(Page.ProductRegistrationPage);
                    break;
                case 2:
                    //Numeric input field
                    Console.CursorVisible = true;
                    this.intInputToDatabase = Convert.ToInt32(Console.ReadLine()); //Fix with tryparse later
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
                    Console.Clear();
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
                    //Register new product

                    //read from specific page elements to database
                    tempString = Page.ProductRegistrationPage.pageElementList[1].stringInputToDatabase;
                    tempString = Page.ProductRegistrationPage.pageElementList[2].stringInputToDatabase;
                    tempInt = Page.ProductRegistrationPage.pageElementList[3].intInputToDatabase;
                    tempString = Page.ProductRegistrationPage.pageElementList[4].stringInputToDatabase;

                    for (int i = 1; i < 5; i++)
                    {
                        Console.SetCursorPosition(Page.ProductRegistrationPage.pageElementList[i].StartX + 1, Page.ProductRegistrationPage.pageElementList[i].StartY + 2);
                        Console.WriteLine(new string(' ', 56)); //Should prob not be a fixed value
                    }
                    Page.Menu(Page.ProductRegistrationPage);
                    break;

            }
        }
    }
}
