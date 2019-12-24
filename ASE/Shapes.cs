using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE
{
    class Shapes
    {
        public Bitmap myBitmap;

        public void bMap(int width, int height)
        {
            myBitmap = new Bitmap( width, height);
            Graphics g = Graphics.FromImage(myBitmap);
        }

        //SHAPES
        public void Rectangle(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawRectangle(new Pen(Color.Black, 2), x, y, height, width);
            //Refresh();
        }
        public void Circle(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawEllipse(new Pen(Color.Black, 2), x, y, height, width);
            //Refresh();
        }
        public void Triangle()
        {
            Graphics g = Graphics.FromImage(myBitmap);
            //g.DrawPolygon(new Pen(Color.Black, 2), points);
            //Refresh();
        }
        //COMMANDS
        public void DrawTo(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawLine(new Pen(Color.Black, 2), x, y, height, width);
            //Refresh();
        }
    }
}