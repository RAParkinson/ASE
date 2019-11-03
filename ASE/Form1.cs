using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        string temp = "", command = "";
        int x = 0, y = 0, width = 0, height = 0;
        Point[] points = new Point[3];
        int point1x = 0, point2x = 0, point3x = 0;
        int point1y = 0, point2y = 0, point3y = 0;
        RichTextBox hiddenRTB = new RichTextBox();

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*Feature coming soon*");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*Feature coming soon*");
        }

        public Form1()
        {
            InitializeComponent();

            myBitmap = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(myBitmap);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(myBitmap, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "run")
            {
                hiddenRTB = richTextBox1;
            }
            else
            {
                hiddenRTB.AppendText(textBox1.Text);
            }

            foreach (var line in hiddenRTB.Lines)
            {
                temp = line;
                temp = temp.ToLower();
                temp = temp.Replace(" ", "");

                try
                {
                    String[] sSplit = temp.Split(',');
                    command = sSplit[0];

                    if (command == "moveto")
                    {
                        x = Int32.Parse(sSplit[1]);
                        y = Int32.Parse(sSplit[2]);
                    }
                    if (command == "drawto")
                    {
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        DrawTo();
                    }
                    if (command == "clear")
                    {
                        Graphics g = Graphics.FromImage(myBitmap);
                        g.Clear(Color.White);
                        Refresh();
                    }
                    if (command == "reset")
                    {
                        x = 0;
                        y = 0;
                    }
                    //Shapes
                    if (command == "rectangle")
                    {
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        Rectangle();

                    }
                    if (command == "circle")
                    {
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        Circle();
                    }
                    if (command == "triangle")
                    {
                        point1x = Int32.Parse(sSplit[1]);
                        point1y = Int32.Parse(sSplit[2]);
                        point2x = Int32.Parse(sSplit[3]);
                        point2y = Int32.Parse(sSplit[4]);
                        point3x = Int32.Parse(sSplit[5]);
                        point3y = Int32.Parse(sSplit[6]);

                        points[0] = new Point(point1x, point1y);
                        points[1] = new Point(point2x, point2y);
                        points[2] = new Point(point3x, point3y);
                        Triangle();
                    }
                    else
                    {
                        //MessageBox.Show("Error when entering commands.");
                    }
                }
                catch (Exception i)
                {
                    MessageBox.Show("Error when entering parameters.");
                }

                textBox1.Text = "";
                richTextBox1.Text = "";
                Refresh();
            }
        }

        //SHAPES
        public void Rectangle()
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawRectangle(new Pen(Color.Black, 2), x, y, height, width);
            Refresh();
        }
        public void Circle()
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawEllipse(new Pen(Color.Black, 2), x, y, height, width);
            Refresh();
        }
        public void Triangle()
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawPolygon(new Pen(Color.Blue, 5), points);
            Refresh();
        }
        //COMMANDS
        public void DrawTo()
        {
            Graphics g = Graphics.FromImage(myBitmap);
            g.DrawLine(new Pen(Color.Blue, 5), x, y, height, width);
            Refresh();
        }
    }
}