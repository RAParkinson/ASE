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
            RichTextBox hiddenRTB = new RichTextBox();

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
                        MessageBox.Show("in moveto");
                    }
                    if (command == "drawto")
                    {
                        MessageBox.Show("in drawto");
                    }
                    if (command == "clear")
                    {
                        MessageBox.Show("in clear");
                    }
                    if (command == "reset")
                    {
                        MessageBox.Show("in reset");
                    }
                    //Shapes
                    if (command == "rectangle")
                    {
                        MessageBox.Show("in rectangle");
                    }
                    if (command == "circle")
                    {
                        MessageBox.Show("in circle");
                    }
                    if (command == "triangle")
                    {
                        MessageBox.Show("in triangle");
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
            }
        }
    }
}