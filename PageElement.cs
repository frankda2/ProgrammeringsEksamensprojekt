using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class PageElement //Child class til specifikke side elementer
    {
        public PageElement(int width, int height, int startX, int startY, string text)
        {
            Width = width;
            Height = height;
            StartX = startX;
            StartY = startY;
            Text = text;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string Text { get; set; }
    }
}
