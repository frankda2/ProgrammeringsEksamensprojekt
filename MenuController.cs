using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class MenuController
    {
        static public string[] characterSet1 = { "──", "│", "┌", "┐", "└", "┘" };
        static public string[] characterSet2 = { "══", "║", "╔", "╗", "╚", "╝" };

        static void MenuDefine()
        {
            PageElement Element1 = new PageElement(30, 30, 40, 5, "Login");
            PageElement Element2 = new PageElement(28, 8, 41, 10, "Username");
            PageElement Element3 = new PageElement(28, 8, 41, 20, "Password");
            PageElement Element4 = new PageElement(28, 4, 41, 30, "Continue");
            Pages.PageElementList.Add(Element1);
            Pages.PageElementList.Add(Element2);
            Pages.PageElementList.Add(Element3);
            Pages.PageElementList.Add(Element4);
        }

        public static void Menu()
        {
            MenuDefine();

            ConsoleKeyInfo key;
            int indexer = 1;

            Pages.DrawMenu(Pages.PageElementList);
            Pages.DrawBox(Pages.PageElementList[indexer], characterSet2);

            do
            {
                key = Console.ReadKey(true);

                if (key.Key.ToString() == "UpArrow" && indexer > 1)
                {
                    Pages.DrawBox(Pages.PageElementList[indexer], characterSet1);
                    indexer--;
                    Pages.DrawBox(Pages.PageElementList[indexer], characterSet2);
                }
                else if(key.Key.ToString() == "DownArrow" && indexer < 3)
                {
                    Pages.DrawBox(Pages.PageElementList[indexer], characterSet1);
                    indexer++;
                    Pages.DrawBox(Pages.PageElementList[indexer], characterSet2);
                }
            } while (key.KeyChar != 13);
        }
    }
}
