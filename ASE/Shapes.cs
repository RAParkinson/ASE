using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        public void Rectangle(int x, int y, int height, int width, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawRectangle(new Pen(Color.Black, penSize), x, y, height, width);
        }
        public void Circle(int x, int y, int radius, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawEllipse(new Pen(Color.Black, penSize), x, y, radius, radius);
        }
        public void Triangle(Point point1, Point point2, Point point3, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);

            Point[] points = new Point[3];

            points[0] = point1;
            points[1] = point2;
            points[2] = point3;

            g.DrawPolygon(new Pen(Color.Black, penSize), points);
        }
        //COMMANDS
        public void DrawTo(int x, int y, int height, int width, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawLine(new Pen(Color.Black, penSize), x, y, height, width);
        }
        public void Save()
        {
            myBitmap.Save(@"C:\Users\rapar\OneDrive\Desktop\file.png", ImageFormat.Png);
        }

    }
}