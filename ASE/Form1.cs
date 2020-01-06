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
        int width = 0;
        int height = 0;
        int radius = 0;
        Point[] points = new Point[3];
        int point1x = 0, point2x = 0, point3x = 0;
        int point1y = 0, point2y = 0, point3y = 0;
        RichTextBox hiddenRTB = new RichTextBox();

        int loopLineNum = 0;

        int userCount = 0; int userCount2 = 0;  int loopCount = 1;
        Boolean bCount = false;
        Boolean bIf = false;

        int methodLocation = 0;

        int ifRadius = 0; int ifWidth = 0; int ifHeight = 0;
        int ifLocation = 0;
        int endifLineNum = 0;

        int i = 0;

        String[] ifArray = new string[2];
        String[] methodArray = new string[2];

        String[] lineArray = new string[50];
        int lineArrayCount = 0;

        int penSize = 2;

        /// <summary>
        /// the event handler for the load button
        /// opens a dialogue box for the user to select a text file to load into the richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {   
                richTextBox1.Text = opentext.FileName;
            }
        }

        /// <summary>
        /// the event handler for the save button
        /// calls the save method from the shapes class
        /// displays a message to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            shape.Save();
            MessageBox.Show("Image saved to the Desktop.");
        }

        /// <summary>
        /// The main method which calls the initializecomponent method
        /// calls the bmap method from the shapes class passing the parameters width and height with type size
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            shape.bMap(Size.Width, Size.Height);
        }

        /// <summary>
        /// calls the drawimageunscaled method from graphics passing through the bitmap and 0 as the parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(shape.myBitmap, 0, 0);
        }

        /// <summary>
        /// the event handler for the submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //For each of the lines in the richTextBox
            foreach (var line in hiddenRTB.Lines)
            {
                temp = line;
                temp = temp.ToLower();
                temp = temp.Replace(" ", "");

                lineArray[lineArrayCount] = temp;
                lineArrayCount++;
            }

            //While the i count is not equal to the lineArrayCount variable the following is executed
            while(i != lineArrayCount)
            {
                try
                {
                    //Splits string by the , character and assigns the first value to the command variable
                    String[] sSplit = lineArray[i].Split(',');
                    command = sSplit[0];

                    //If command is equal to “moveto” the second and third elements in the sSplit array are converted to integers 
                    //These values are then assigned to “x” and “y” with the i count itself plus one
                    if (command.Equals("moveto"))
                    {
                        //Converts string into integer and assigns the value
                        x = Int32.Parse(sSplit[1]);
                        y = Int32.Parse(sSplit[2]);
                        i++;
                    }
                    //If command is equal to “drawto” the second and third elements in the sSplit array are converted to integers and then set to “width” and “height”
                    //The DrawTo method is called from the shape class method with the x, y, height width and penSize parameters with the i count itself plus one
                    else if (command.Equals("drawto"))
                    {
                        width = Int32.Parse(sSplit[1]);
                        height = Int32.Parse(sSplit[2]);
                        shape.DrawTo(x, y, height, width, penSize);
                        i++;
                    }
                    //If command is equal to “clear” the graphics method is utilised from the bitmap
                    //The clear method is called with the default colour white
                    //The refresh method is called with the i count itself plus one
                    else if (command.Equals("clear"))
                    {
                        Graphics g = Graphics.FromImage(shape.myBitmap);
                        g.Clear(Color.White);
                        Refresh();
                        i++;
                    }
                    //If command is equal to “reset” the value 0 is assigned to both x and y
                    //penSize is assigned to its default of 2 and the i count itself plus one
                    else if (command.Equals("reset"))
                    {
                        x = 0;
                        y = 0;
                        penSize = 2;
                        i++;
                    }
                    //SHAPES
                    //If command is equal to "rectangle" the try statement is utilised to convert what the second and third elements are in the sSplit array to integers
                    //If no exceptions are thrown the Rectangle() method is called with the x, y, height width and penSize parameters then the i count is itself plus one
                    //When an exception is thrown it is caught with catch
                    //And if the second and third elements in the sSplit array equal “width” and “height” the Rectangle() method is called with the i count itself plus one
                    //Else a message box is displayed to the user
                    else if (command.Equals("rectangle"))
                    {
                        try
                        {
                            width = Int32.Parse(sSplit[1]);
                            height = Int32.Parse(sSplit[2]);
                            shape.Rectangle(x, y, height, width, penSize);
                            i++;
                        }
                        catch
                        {
                            if (sSplit[1].Equals("width") && sSplit[2].Equals("height"))
                            {
                                shape.Rectangle(x, y, height, width, penSize);
                                i++;
                            }
                            else
                            {
                                MessageBox.Show("Width or Height parameters entered incorrectly");
                                i++;
                            }
                        }
                    }
                    //If command is equal to "circle" the try statement is utilised to convert what the second element in the sSplit array to an integer
                    //If no exceptions are thrown the Circle() method is called with the x, y, radius and penSize parameters then the i count itself plus one
                    //When an exception is thrown it is caught with catch
                    //And if the second element in the sSplit array equal “radius” the Circle() method is called with the i count plus one
                    //Else a message box is displayed to the user
                    else if (command.Equals("circle"))
                    {
                        try
                        {
                            radius = Int32.Parse(sSplit[1]);
                            shape.Circle(x, y, radius, penSize);
                            i++;
                        }
                        catch
                        {
                            if (sSplit[1].Equals("radius"))
                            {
                                shape.Circle(x, y, radius, penSize);
                                i++;
                            }
                            else
                            {
                                MessageBox.Show("Radius parameter entered incorrectly"); ;
                                i++;
                            }
                        }
                    }
                    //If command is equal to "triangle" the try statement is utilised to convert the next six elements in the sSplit array to an integer
                    //If no exceptions are thrown these values are then assigned to different points in a point struct
                    //The Triangle() method is called with the three point types as the parameters then i count itself plus one
                    //When an exception is thrown it is caught with catch and a message box is displayed to the user
                    else if (command.Equals("triangle"))
                    {
                        try
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

                            shape.Triangle(points[0], points[1], points[2], penSize);
                            i++;
                        }
                        catch
                        {
                            MessageBox.Show("Error when entering points on the triangle");
                            i++;
                        }
                    }
                    //PARAMETERS
                    //If command starts with “radius=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the radius
                    //the i count is then itself plus one
                    else if (command.StartsWith("radius="))
                    {
                        String[] sSplitRE = command.Split('=');
                        radius = Int32.Parse(sSplitRE[1]);
                        i++;
                    }
                    //If command starts with “width=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the width
                    //the i count is then itself plus one
                    else if (command.StartsWith("width="))
                    {
                        String[] sSplitWE = command.Split('=');
                        width = Int32.Parse(sSplitWE[1]);
                        i++;
                    }
                    //If command starts with “height=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the height
                    //the i count is then itself plus one
                    else if (command.StartsWith("height="))
                    {
                        String[] sSplitHE = command.Split('=');
                        height = Int32.Parse(sSplitHE[1]);
                        i++;
                    }
                    //If command starts with “radius+” a string array is created to split the command by ‘+’
                    //The second value in the array is converted to an integer and assigned to the radiusAdd
                    //The radius is then assigned to itself plus radiusAdd with the i count being itself plus one
                    else if (command.StartsWith("radius+"))
                    {
                        String[] sSplitRA = command.Split('+');
                        int radiusAdd = Int32.Parse(sSplitRA[1]);
                        radius = radius + radiusAdd;
                        i++;
                    }
                    //If command starts with “width+” a string array is created to split the command by ‘+’
                    //The second value in the array is converted to an integer and assigned to the widthAdd
                    //The width is then assigned to itself plus widthAdd with the i count being itself plus one
                    else if (command.StartsWith("width+"))
                    {
                        String[] sSplitWA = command.Split('+');
                        int widthAdd = Int32.Parse(sSplitWA[1]);
                        width = width + widthAdd;
                        i++;
                    }
                    //If command starts with “height+” a string array is created to split the command by ‘+’
                    //The second value in the array is converted to an integer and assigned to the heightAdd
                    //The height is then assigned to itself plus heightAdd with the i count being itself plus one
                    else if (command.StartsWith("height+"))
                    {
                        String[] sSplitHA = command.Split('+');
                        int heightAdd = Int32.Parse(sSplitHA[1]);
                        height = height + heightAdd;
                        i++;
                    }
                    //If command starts with “radius-” a string array is created to split the command by ‘-’
                    //The second value in the array is converted to an integer and assigned to the radiusSubtract
                    //The radius is then assigned to itself subtract radiusSubtract with the i count being itself plus one
                    else if (command.StartsWith("radius-"))
                    {
                        String[] sSplitRS = command.Split('-');
                        int radiusSubtract = Int32.Parse(sSplitRS[1]);
                        radius = radius + radiusSubtract;
                        i++;
                    }
                    //If command starts with “width-” a string array is created to split the command by ‘-’
                    //The second value in the array is converted to an integer and assigned to the widthSubtract
                    //The width is then assigned to itself subtract widthSubtract with the i count being itself plus one
                    else if (command.StartsWith("width-"))
                    {
                        String[] sSplitWS = command.Split('-');
                        int widthSubtract = Int32.Parse(sSplitWS[1]);
                        width = width + widthSubtract;
                        i++;
                    }
                    //If command starts with “height-” a string array is created to split the command by ‘-’
                    //The second value in the array is converted to an integer and assigned to the heightSubtract
                    //The height is then assigned to itself subtract heightSubtract with the i count being itself plus one
                    else if (command.StartsWith("height-"))
                    {
                        String[] sSplitHS = command.Split('-');
                        int heightSubtract = Int32.Parse(sSplitHS[1]);
                        height = height + heightSubtract;
                        i++;
                    }
                    //If command starts with “radius*” a string array is created to split the command by ‘*’
                    //The second value in the array is converted to an integer and assigned to the radiusMultiplication
                    //The radius is then assigned to itself multiplied radiusMultiplication with the i count being itself plus one
                    else if (command.StartsWith("radius*"))
                    {
                        String[] sSplitRM = command.Split('*');
                        int radiusMultiplication = Int32.Parse(sSplitRM[1]);
                        radius = radius * radiusMultiplication;
                        i++;
                    }
                    //If command starts with “width*” a string array is created to split the command by ‘*’
                    //The second value in the array is converted to an integer and assigned to the widthMultiplication
                    //The width is then assigned to itself multiplied widthMultiplication with the i count being itself plus one
                    else if (command.StartsWith("width*"))
                    {
                        String[] sSplitWM = command.Split('*');
                        int widthMultiplication = Int32.Parse(sSplitWM[1]);
                        width = width * widthMultiplication;
                        i++;
                    }
                    //If command starts with “height*” a string array is created to split the command by ‘*’
                    //The second value in the array is converted to an integer and assigned to the heightMultiplication
                    //The height is then assigned to itself multiplied heightMultiplication with the i count being itself plus one
                    else if (command.StartsWith("height*"))
                    {
                        String[] sSplitHM = command.Split('*');
                        int heightMultiplication = Int32.Parse(sSplitHM[1]);
                        height = height * heightMultiplication;
                        i++;
                    }
                    //If command starts with “count=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the userCount
                    //the i count is then itself plus one
                    else if (command.StartsWith("count="))
                    {
                        String[] sSplitCount = command.Split('=');
                        userCount = Int32.Parse(sSplitCount[1]);
                        i++;
                    }
                    //IF'S
                    //If command starts with “if” the first value in the ifArray is set to the command with the first two characters removed
                    //Within the try statement ”endif” is searched for in the lineArray and when found its index value is assigned to endifLineNum
                    //If the first element in the ifArray equals “radius=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the ifRadius
                    //If the first element in the ifArray equals “width=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the ifWidth
                    //If the first element in the ifArray equals “height=” a string array is created to split the command by ‘=’
                    //The second value in the array is converted to an integer and assigned to the ifHeight
                    //bIf is set to true and count is made equal to itself plus one
                    // The second element in the ifArray is then made equal to i count to be used as pointer in the future and i is assigned to endifLineNum plus one so the loop reads the next line
                    //When an exception is thrown it is caught with catch and a message box is displayed to the user
                    else if (command.StartsWith("if"))
                    {
                        ifArray[0] = lineArray[i].Remove(0, 2);

                        try
                        {
                            endifLineNum = Array.FindIndex(lineArray, row => row.Contains("endif"));

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

                            bIf = true;
                            i++;
                            ifArray[1] = "" + i;
                            i = endifLineNum + 1;

                        }
                        catch
                        {
                            MessageBox.Show("Error endif needed");
                            i++;
                        }
                    }
                    //If command is equal to "endif" the i count is made equal to ifLocation
                    else if (command.Equals("endif"))
                    {
                        i = ifLocation;
                    }
                    //LOOP
                    //If command starts with “loop” a string array is created to split command by “for”
                    //Within the try statement ”endloop” is searched for in the lineArray and when found its index value is assigned to endloopLineNum
                    //If the second element in the sSplitLoop equals “count” userCount2 is set to userCount
                    //bCount is assigned to true and i count is itself plus one
                    //Else a message box is displayed to the user and i is set equal to endLoopLineNum plus one
                    //loopLineNum is set equal to i 
                    //When an exception is thrown it is caught with catch and a message box is displayed to the user
                    else if (command.StartsWith("loop"))
                    {
                        String[] sSplitLoop = lineArray[i].Split(new string[] { "for" }, StringSplitOptions.None);

                        try
                        {
                            int endloopLineNum = Array.FindIndex(lineArray, row => row.Contains("endloop"));

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
                        catch
                        {
                            MessageBox.Show("Error endloop needed");
                            i++;
                        }
                        
                    }
                    //If command starts with “endloop” and bCount is equal to true
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
                        methodArray[1] = "" + i;

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
                    //Additional commands
                    else if (command.StartsWith("pensize="))
                    {
                        String[] sSplitPenSize = command.Split('=');
                        penSize = Int32.Parse(sSplitPenSize[1]);

                        i++;
                    }
                    else if (command.StartsWith("pensize+"))
                    {
                        String[] sSplitPenSizeA = command.Split('+');
                        penSize = penSize + Int32.Parse(sSplitPenSizeA[1]);

                        i++;
                    }
                    else if (command.StartsWith("pensize-"))
                    {
                        String[] sSplitPenSizeS = command.Split('-');
                        penSize = penSize - Int32.Parse(sSplitPenSizeS[1]);

                        i++;
                    }
                    else if (command.StartsWith("savetext"))
                    {
                        System.IO.File.WriteAllLines(@"C:\Users\rapar\OneDrive\Desktop\text.txt", lineArray);
                        i++;
                    }
                    else if (command.StartsWith("loadtext"))
                    {
                        //System.IO.File.ReadAllLines(@"C:\Users\rapar\OneDrive\Desktop\text.txt".FileName);

                        //richTextBox1.Text = System.IO.File.ReadAllText(@"C:\Users\rapar\OneDrive\Desktop\text.txt", lineArray);

                        i++;
                    }
                }
                catch (FormatException)
                {
                    //Displays message box to the user
                    MessageBox.Show("Error when entering parameter, please try again.");
                    i++;
                }

                //After each loop in the while the value of radius is compared to
                if(radius.Equals(ifRadius) && radius != 0 && bIf == true)
                {
                    ifLocation = i + 1;
                    i = Int32.Parse(ifArray[1]);

                    bIf = false;
                }
                if (width.Equals(ifWidth) && width != 0 && bIf == true)
                {
                    ifLocation = i + 1;
                    i = Int32.Parse(ifArray[1]);

                    bIf = false;
                }
                if (height.Equals(ifHeight) && height != 0 && bIf == true)
                {
                    ifLocation = i + 1;
                    i = Int32.Parse(ifArray[1]);

                    bIf = false;
                }

                //Sets values for both richTextBox and textBox
                textBox1.Text = "";
                richTextBox1.Text = "";

                //Calls the refresh method
                Refresh();
            }
        }
    }
}