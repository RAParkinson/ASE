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
        //creation of a BitMap
        public Bitmap myBitmap;

        /// <summary>
        /// assigns a width and height to the public Bitmap 
        /// assigns the Bitmap to Graphics
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void bMap(int width, int height)
        {
            myBitmap = new Bitmap( width, height);
            Graphics g = Graphics.FromImage(myBitmap);
        }

        //SHAPES
        /// <summary>
        /// utilises the Graphics.DrawEllipse Method from the System.Drawing namespace
        /// when called draws a rectangle based on four integers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="penSize"></param>
        public void Rectangle(int x, int y, int height, int width, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawRectangle(new Pen(Color.Black, penSize), x, y, height, width);
        }

        /// <summary>
        /// utilises the Graphics.DrawEllipse Method from the System.Drawing namespace
        /// when called draws a circle based on four integers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="penSize"></param>
        public void Circle(int x, int y, int radius, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawEllipse(new Pen(Color.Black, penSize), x, y, radius, radius);
        }

        /// <summary>
        /// utilises the Graphics.DrawPolygon Method from the System.Drawing namespace
        /// when called draws a triangle based on three seperate point constructors
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="penSize"></param>
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
        /// <summary>
        /// utilises the Graphics.DrawLine Method from the System.Drawing namespace
        /// when called draws a line from one point to another based on four integers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="penSize"></param>
        public void DrawTo(int x, int y, int height, int width, int penSize)
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawLine(new Pen(Color.Black, penSize), x, y, height, width);
        }

        /// <summary>
        /// utilises the Image.Save method from the System.Drawing namespace
        /// when called saves the bitmap as a .png file on the desktop
        /// </summary>
        public void Save()
        {
            myBitmap.Save(@"C:\Users\rapar\OneDrive\Desktop\file.png", ImageFormat.Png);
        }

    }
}