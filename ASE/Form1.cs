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
        Shapes shape = new Shapes();
        
        //Declares global variables and assigns them a value
        string temp = "", command = "";
        int x = 0, y = 0;
        public int width = 0;
        public int height = 0;
        public int radius = 0;
        Point[] points = new Point[3];
        int point1x = 0, point2x = 0, point3x = 0;
        int point1y = 0, point2y = 0, point3y = 0;
        RichTextBox hiddenRTB = new RichTextBox();

        int tempRadius = 0; int tempWidth = 0; int tempHeight = 0;

        int loopLineNum = 0;

        int userCount = 0; int userCount2 = 0;  int loopCount = 1;
        Boolean bCount = false;

        int methodLocation = 0;

        int ifRadius = 0; int ifWidth = 0; int ifHeight = 0;

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

            shape.bMap(Size.Width, Size.Height);
        }

        //Event handler for painting the panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(shape.myBitmap, 0, 0);
        }

        //Event handler for the Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            //Reads user entered text from the text box
            if (textBox1.Text == "run")
            {
                hiddenRTB = richTextBox1;
            }
            else if(textBox1.Text == "")
            {
                //Displays message box to the user
                MessageBox.Show("No command entered, please try again.");
            }
            else
            {
                hiddenRTB.AppendText(textBox1.Text);
            }

            String[] lineArray = new string[50];
            int lineArrayCount = 0;

            foreach (var line in hiddenRTB.Lines)
            {
                temp = line;
                temp = temp.ToLower();
                temp = temp.Replace(" ", "");

                lineArray[lineArrayCount] = temp;
                lineArrayCount++;
            }

            int i = 0;

            String[] ifArray = new string[2];
            String[] methodArray = new string[2];

            while (lineArray[i] != null)
            {
                //MessageBox.Show(lineArray[i]);

                try
                {
                    //Splits string by the , character
                    String[] sSplit = lineArray[i].Split(',');
                    command = sSplit[0];

                    if (command.Equals("moveto"))
                    {
                        //Converts string into integer and assigns the value
                        x = Int32.Parse(sSplit[1]);
                        y = Int32.Parse(sSplit[2]);

                        i++;
                    }
                    else if (command.Equals("drawto"))
                    {
                        //Converts string into integer and assigns the value
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);

                        //Calls the DrawTo method
                        shape.DrawTo(x, y, height, width);

                        i++;
                    }
                    else if (command.Equals("clear"))
                    {
                        //Sets the bitmap colour to white
                        Graphics g = Graphics.FromImage(shape.myBitmap);
                        g.Clear(Color.White);

                        //Calls the Refresh method
                        Refresh();

                        i++;
                    }
                    else if (command.Equals("reset"))
                    {
                        //Assigns value to x and y
                        x = 0;
                        y = 0;

                        i++;
                    }
                    //Shapes
                    else if (command.Equals("rectangle"))
                    {
                        try
                        {
                            //Converts string into integer and assigns the value
                            width = Int32.Parse(sSplit[1]);
                            height = Int32.Parse(sSplit[2]);

                            //Calls the Rectangle method
                            shape.Rectangle(x, y, height, width);

                            i++;
                        }
                        catch
                        {
                            if (sSplit[1].Equals("width") && sSplit[2].Equals("height"))
                            {
                                shape.Rectangle(x, y, height, width);

                                i++;
                            }
                            else
                            {
                                MessageBox.Show("Width or Height parameters entered incorrectly");
                            }
                        }
                    }
                    else if (command.Equals("circle"))
                    {
                        try
                        {
                            //Converts string into integer and assigns the value
                            radius = Int32.Parse(sSplit[1]);

                            //Calls the Circle method
                            shape.Circle(x, y, radius);

                            i++;
                        }
                        catch
                        {
                            if (sSplit[1].Equals("radius"))
                            {
                                shape.Circle(x, y, radius);

                                i++;
                            }
                            else
                            {
                                MessageBox.Show("Radius parameter entered incorrectly");
                            }
                        }
                    }
                    else if (command.Equals("triangle"))
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
                        shape.Triangle();

                        i++;
                    }
                    //Parameters
                    else if (command.StartsWith("radius="))
                    {
                        String[] sSplitRE = command.Split('=');
                        int radiusValue = Int32.Parse(sSplitRE[1]);

                        radius = radiusValue;

                        i++;
                    }
                    else if (command.StartsWith("width="))
                    {
                        String[] sSplitWE = command.Split('=');
                        int widthValue = Int32.Parse(sSplitWE[1]);

                        width = widthValue;

                        i++;
                    }
                    else if (command.StartsWith("height="))
                    {
                        String[] sSplitHE = command.Split('=');
                        int heightValue = Int32.Parse(sSplitHE[1]);

                        height = heightValue;

                        i++;
                    }
                    else if (command.StartsWith("radius+"))
                    {
                        String[] sSplitRA = command.Split('+');
                        int radiusAdd = Int32.Parse(sSplitRA[1]);

                        radius = radius + radiusAdd;

                        i++;
                    }
                    else if (command.StartsWith("width+"))
                    {
                        String[] sSplitWA = command.Split('+');
                        int widthAdd = Int32.Parse(sSplitWA[1]);

                        width = width + widthAdd;

                        i++;
                    }
                    else if (command.StartsWith("height+"))
                    {
                        String[] sSplitHA = command.Split('+');
                        int heightAdd = Int32.Parse(sSplitHA[1]);

                        height = height + heightAdd;

                        i++;
                    }
                    else if (command.StartsWith("radius-"))
                    {
                        String[] sSplitRS = command.Split('-');
                        int radiusSubtract = Int32.Parse(sSplitRS[1]);

                        radius = radius + radiusSubtract;

                        i++;
                    }
                    else if (command.StartsWith("width-"))
                    {
                        String[] sSplitWS = command.Split('-');
                        int widthSubtract = Int32.Parse(sSplitWS[1]);

                        width = width + widthSubtract;

                        i++;
                    }
                    else if (command.StartsWith("height-"))
                    {
                        String[] sSplitHS = command.Split('-');
                        int heightSubtract = Int32.Parse(sSplitHS[1]);

                        height = height + heightSubtract;

                        i++;
                    }
                    else if (command.StartsWith("count="))
                    {
                        String[] sSplitCount = command.Split('=');
                        userCount = Int32.Parse(sSplitCount[1]);

                        i++;
                    }
                    //If
                    else if (command.StartsWith("if"))
                    {
                        /* lineArray[i] = lineArray[i].Remove(0, 2);

                        int endifLineNum = hiddenRTB.GetLineFromCharIndex(hiddenRTB.Find("endif"));

                        int ifCOunt = 0;

                        while (ifCOunt != endifLineNum)
                        {
                            ifArray[ifCOunt] = lineArray[i];

                            MessageBox.Show(ifArray[ifCOunt]);

                            ifCOunt++;
                            i++;
                        }

                        if (ifArray[0].StartsWith("radius="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            tempRadius = Int32.Parse(sSplitTempR[1]);
                        }
                        if (ifArray[0].StartsWith("width="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            tempWidth = Int32.Parse(sSplitTempR[1]);
                        }
                        if (ifArray[0].StartsWith("height="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            tempHeight = Int32.Parse(sSplitTempR[1]);
                        } */

                        ifArray[0] = lineArray[i].Remove(0, 2);

                        int endifLineNum = hiddenRTB.GetLineFromCharIndex(hiddenRTB.Find("endif"));

                        ifArray[1] = "" + i++;

                        i = endifLineNum++;

                        if (ifArray[0].StartsWith("radius="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            ifRadius = Int32.Parse(sSplitTempR[1]);
                        }
                        if (ifArray[0].StartsWith("width="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            ifWidth = Int32.Parse(sSplitTempR[1]);
                        }
                        if (ifArray[0].StartsWith("height="))
                        {
                            String[] sSplitTempR = ifArray[0].Split('=');

                            ifHeight = Int32.Parse(sSplitTempR[1]);
                        }
                    }
                    /*else if(radius.Equals(ifRadius))
                    {
                        //ifLocation = i;
                        //i = Int32.Parse(methodArray[1]);
                    } */
                    //Loop
                    else if (command.StartsWith("loop"))
                    {
                        String[] sSplitLoop = lineArray[i].Split(new string[] { "for" }, StringSplitOptions.None);

                        int endloopLineNum = hiddenRTB.GetLineFromCharIndex(hiddenRTB.Find("endloop"));

                        if (sSplitLoop[1].Equals("count"))
                        {
                            userCount2 = userCount;
                            bCount = true;

                            i++;
                        }
                        else
                        {
                            MessageBox.Show("No value assigned to count");
                            i = endloopLineNum++;
                        }

                        loopLineNum = i;
                    }
                    else if (command.Equals("endloop"))
                    {
                        if (bCount == true)
                        {
                            if (userCount2 != loopCount)
                            {
                                i = loopLineNum;
                                loopCount++;
                            }
                            else if (userCount2 == loopCount)
                            {
                                i++;
                            }
                            else
                            {
                                MessageBox.Show("No valid count entered");
                            }
                        }
                    }
                    //Method
                    else if (command.StartsWith("method"))
                    {
                        methodArray[0] = lineArray[i].Remove(0, 6);

                        int endmethodLineNum = Array.FindIndex(lineArray, row => row.Contains("endmethod"));

                        i++;
                        methodArray[1] = ""+i;

                        i = endmethodLineNum + 1;
                    }
                    else if (command.Equals(methodArray[0]))
                    {
                        methodLocation = i;
                        i = Int32.Parse(methodArray[1]);
                    }
                    else if (command.Equals("endmethod"))
                    {
                        i = methodLocation + 1;
                    }
                    else
                    {
                        MessageBox.Show("No valid command entered, please try again.");
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

                Refresh();

                //MessageBox.Show("what i is at the end of each loop :"+i);
            }
        }
    }
}