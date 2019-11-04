﻿using System;
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
        //Declares global variables and assigns them a value
        Bitmap myBitmap;
        string temp = "", command = "";
        int x = 0, y = 0, width = 0, height = 0;
        Point[] points = new Point[3];
        int point1x = 0, point2x = 0, point3x = 0;
        int point1y = 0, point2y = 0, point3y = 0;
        RichTextBox hiddenRTB = new RichTextBox();

        //Event handler for the Load button
        private void button2_Click(object sender, EventArgs e)
        {
            //Displays message box to the user
            MessageBox.Show("*Load feature coming soon*");
        }

        //Event handler for the Save button
        private void button3_Click(object sender, EventArgs e)
        {
            //Displays message box to the user
            MessageBox.Show("*Save feature coming soon*");
        }

        public Form1()
        {
            InitializeComponent();

            myBitmap = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(myBitmap);
        }

        //Event handler for painting the panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(myBitmap, 0, 0);
        }

        //Event handler for the Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            //Reads user entered text from the text box
            if (textBox1.Text == "run")
            {
                hiddenRTB = richTextBox1;
            }
            if(textBox1.Text == "")
            {
                //Displays message box to the user
                MessageBox.Show("No command entered, please try again.");
            }
            else
            {
                hiddenRTB.AppendText(textBox1.Text);
            }

            foreach (var line in hiddenRTB.Lines)
            {
                temp = line;
                //Sets all characters to lowercase 
                temp = temp.ToLower();
                //Removes spaces
                temp = temp.Replace(" ", "");

                try
                {
                    //Splits string by the , character
                    String[] sSplit = temp.Split(',');
                    command = sSplit[0];

                    if (command.Equals("moveto"))
                    {
                        //Converts string into integer and assigns the value
                        x = Int32.Parse(sSplit[1]);
                        y = Int32.Parse(sSplit[2]);
                    }
                    if (command.Equals("drawto"))
                    {
                        //Converts string into integer and assigns the value
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        
                        //Calls the DrawTo method
                        DrawTo();
                    }
                    if (command.Equals("clear"))
                    {
                        //Sets the bitmap colour to white
                        Graphics g = Graphics.FromImage(myBitmap);
                        g.Clear(Color.White);
                        
                        //Calls the Refresh method
                        Refresh();
                    }
                    if (command.Equals("reset"))
                    {
                        //Assigns value to x and y
                        x = 0;
                        y = 0;
                    }
                    //Shapes
                    if (command.Equals("rectangle"))
                    {
                        //Converts string into integer and assigns the value
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);

                        //Calls the Rectangle method
                        Rectangle();
                    }
                    if (command.Equals("circle"))
                    {
                        //Converts string into integer and assigns the value
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        
                        //Calls the Circle method
                        Circle();
                    }
                    if (command.Equals("triangle"))
                    {
                        //Converts string into integer and assigns the value
                        point1x = Int32.Parse(sSplit[1]);
                        point1y = Int32.Parse(sSplit[2]);
                        point2x = Int32.Parse(sSplit[3]);
                        point2y = Int32.Parse(sSplit[4]);
                        point3x = Int32.Parse(sSplit[5]);
                        point3y = Int32.Parse(sSplit[6]);

                        points[0] = new Point(point1x, point1y);
                        points[1] = new Point(point2x, point2y);
                        points[2] = new Point(point3x, point3y);
                        
                        //Calls the Triangle method
                        Triangle();
                    }
                    else
                    {
                        //MessageBox.Show("No valid command enter, please try again.");
                    }
                }
                catch (FormatException)
                {
                    //Displays message box to the user
                    MessageBox.Show("Error when entering parameter, please try again.");
                }

                //Sets values for both richTextBox and textBox
                textBox1.Text = "";
                richTextBox1.Text = "";
                hiddenRTB.Text = "";

                //Calls the Refresh method
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