using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
    class PageElement
    {
        int width;
        int height;
        int startX;
        int startY;

        public PageElement(int width, int height, int startX, int startY)
        {
            this.width = width;
            this.height = height;
            this.startX = startX;
            this.startY = startY;
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int StartX
        {
            get { return startX; }
            set { startX = value; }
        }
        public int StartY
        {
            get { return startY; }
            set { startY = value; }
        }


        //Child class til specifikke side elementer
    }
}
