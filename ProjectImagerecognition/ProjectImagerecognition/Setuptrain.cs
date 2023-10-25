using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace ProjectImagerecognition
{
    public partial class Setuptrain : Form
    {
        public Setuptrain()
        {
            InitializeComponent();
        }
        bool selected = false;
        int x = 0;
        int y = 0;
        int xx = 0;
        int yy = 0;
        int midx = 0;
        int midy = 0;
        Bitmap bmp;
        Bitmap bitm;
        Bitmap default_bmp;
        int previousx = 0;
        int previousy = 0;
        string location = "";
        int listboxindexnum = 0;
        double[,,] expected = new double[7, 7, 30];
        int[,,] filter_64_7x7 = new int[64, 7, 7];
        int[,,] filter_192_3x3 = new int[192, 3, 3];
        int[] filter_128_1x1 = new int[128];
        int[,,] filter_256_3x3 = new int[256, 3, 3];
        int[,] filter_256_1x1 = new int[256, 2];//changed so more different filters
        int[,] filter_512_1x1 = new int[512, 2];
        int[,,,] filter_512_3x3 = new int[512, 3, 3, 2];
        int[,,,] filter_1024_3x3 = new int[1024, 3, 3, 6];
        public static int loading_value = 0;
        static int loading_max = 0;
        static bool loading = false;
        static bool listboxloaded = false;
        static string loadinglabeltxt = "Abstracting image";

        private void buttonImport_detect_Click(object sender, EventArgs e)
        {
            Bitmap bp;//creates bitmap variable
            OpenFileDialog fl = new OpenFileDialog();
            DialogResult rl = fl.ShowDialog();//opens up a dialog that allows the user to choose the file path
            if (rl == DialogResult.OK)//checks if file path is valid
            {
                try//in case if something goes wrong, the program won't crash but display that something is wrong with filepath
                {
                    bp = new Bitmap(fl.FileName);//opens the image and stores it into bitmap variable
                    default_bmp = new Bitmap(bp, new Size(448, 448));//resizes the image to 448x448 size
                    bmp = default_bmp;
                    pictureBoxImg.Image = default_bmp;//displays the image
                }
                catch (Exception)
                {
                    MessageBox.Show("File cannot be loaded!");
                }
            }
            else
            {
                MessageBox.Show("Could not open the image!");
            }
        }

        private void buttonNextObject_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxImg.Image = default_bmp;//removes drawn bounding boxes by setting the image to the default image that was imported
            for(int y = 0; y<7; y++)//since expected is 7x7x30 in output, I need to do a for loop 7x7 times 
            {
                for(int x = 0; x<7; x++)
                {
                        if (expected[x, y, listboxindexnum + 20] == 1)//checks if anchorbox 2 is being used
                        {
                            expected[x, y, listboxindexnum + 20] = 0;//sets the class to 0
                            expected[x, y, 19] = 0;//sets Bh to 0
                            expected[x, y, 18] = 0;//sets Bw to 0
                            expected[x, y, 17] = 0;//sets By to 0
                            expected[x, y, 16] = 0;//sets Bx to 0
                            expected[x, y, 15] = 0;//sets Pc to 0
                        }
                        if (expected[x, y, listboxindexnum + 5] == 1)//checks if anchorbox 1 is being used
                        {
                            expected[x, y, listboxindexnum + 5] = 0;//sets the class to 0
                            expected[x, y, 4] = 0;//sets Bh to 0
                            expected[x, y, 3] = 0;//sets Bw to 0
                            expected[x, y, 2] = 0;//sets By to 0
                            expected[x, y, 1] = 0;//sets Bx to 0
                            expected[x, y, 0] = 0;//sets Pc to 0
                        }
                    
                }
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {


            int tmp = 0;
            while(File.Exists(location+"\\training\\" + tmp.ToString() + ".txt"))//stores the file once an available number for the file name was found
            {
                tmp++;
            }
            StreamWriter sr = new StreamWriter(location + "\\training\\" + tmp.ToString() + ".txt");//stores it in a text file
            for(int i = 0; i<30; i++)
            {
                for(int y = 0; y< 7; y++)
                {
                    for(int x = 0; x< 7; x++)
                    {
                        sr.WriteLine(expected[x,y,i].ToString());
                    }
                }
            }
            for(int i = 0; i< 50176; i++) 
            {
                sr.WriteLine(Abstractor.inp[i].ToString());
            } 
            default_bmp.Save(location + "\\training\\" + tmp.ToString() + ".png",System.Drawing.Imaging.ImageFormat.Png);
            sr.Close();

        }

        private void pictureBoxImg_MouseClick(object sender, MouseEventArgs e)
        {
            if (selected == false)//when the user clicks first time, the x and y of the location of the first selection click will be recorded
            {
                bmp = new Bitmap(pictureBoxImg.Image);//sets bmp to the image
                selected = true;//sets that the 1st click was used
                x = e.X;//obtains the x co-ordinates of the click
                y = e.Y;//obtains the y co-ordinates of the click
                pictureBoxImg.Image = bmp;

            }
            else//2nd x and y click recorded in which will later on draw the selection and record the location of the object.
            {
                pictureBoxImg.Image = bmp;
                xx = e.X;//get the co-ordinates of the 2nd click
                yy = e.Y;

                int pointer_xx = 0;
                int pointer_yy = 0;
                int pointer_x = 0;
                int pointer_y = 0;
                midx = (xx + x) / 2;//finds midpoint of x
                midy = (yy + y) / 2;//finds midpoint of y
                for(int i = x; i< xx; i++)//draws the selected box
                {
                    bmp.SetPixel(i, y, Color.Red);//draws the top
                }
                for (int i = y; i < yy; i++)
                {
                    bmp.SetPixel(x, i, Color.Red);//draws the left side
                }
                for (int i = x; i < xx; i++)
                {
                    bmp.SetPixel(i, yy, Color.Red);//draws the bottom
                }
                for (int i = y; i < yy; i++)
                {
                    bmp.SetPixel(xx, i, Color.Red);//draws the right side
                }


                pictureBoxImg.Image = bmp;
                for (int i = 0; i < x; i += 64)
                {
                    pointer_x = i;
                }
                for (int i = 0; i < y; i += 64)
                {
                    pointer_y = i;
                }
                for (int i = 0; i< xx; i += 64)
                {
                    pointer_xx = i;
                }
                for(int i = 0; i< yy; i+= 64)
                {
                    pointer_yy = i;
                }
                double num1 = 64;//I did this to fix a simple bug since c# thought that 64 is an integer it automatically rounded up the number 
                for(int yd = pointer_y; yd<pointer_yy + 64; yd+= 64)
                {
                    for (int xd = pointer_x; xd < pointer_xx + 64; xd+= 64)
                    {
                        //MessageBox.Show((xd/64).ToString());
                        int ex = Math.Max(xd- 32,0);
                        int ey = yd;
                        int exx = Math.Min(xd + 96,447);//anchor box 1
                        int eyy = Math.Min(yd + 64,447);

                        int rx = xd;//anchor box 2
                        int ry = Math.Max(yd - 32,0);
                        int rxx = Math.Min(xd + 64,447);
                        int ryy = Math.Min(yd + 96,447);

                        //double anchorbox1iou = IoUgenerator(ex, ey, exx, eyy, x, y, xx, yy);
                       // double anchorbox2iou = IoUgenerator(rx, ry, rxx, ryy, x, y, xx, yy);

                        if(Math.Abs(x-xx) > Math.Abs(y-yy))
                        {


                            expected[xd / 64, yd / 64, listboxindexnum + 5] = 1;
                            bool boxerror = false;
                            for (int i = 5; i < 14; i++)
                            {
                                if (expected[xd / 64, yd / 64, i] == 1 && i != listboxindexnum + 5)
                                {
                                    //MessageBox.Show("Can't fit another object in cell");
                                    expected[xd / 64, yd / 64, listboxindexnum + 5] = 0;
                                    boxerror = true;
                                }
                            }
                            if(boxerror == false)
                            {
                                expected[xd / 64, yd / 64, 0] = 1;
                                expected[xd / 64, yd / 64, 1] = Math.Min((Math.Max(((midx - xd) / num1), 0)), 1); //works out the bx 
                                expected[xd / 64, yd / 64, 2] = Math.Min((Math.Max(((midy - yd) / num1), 0)), 1);//works out the by
                                expected[xd / 64, yd / 64, 3] = Math.Abs(x - xx) / 448.0;//works out the bw
                                expected[xd / 64, yd / 64, 4] = Math.Abs(yy - y) / 448.0;//works out the bh


                                //MessageBox.Show(expected[xd/64, yd/64, 3].ToString());
                                /*for (int i = ex; i < exx; i++)
                                {
                                    bmp.SetPixel(i, ey, Color.Blue);
                                }
                                for (int i = ey; i < eyy; i++)
                                {
                                    bmp.SetPixel(ex, i, Color.Blue);
                                }
                                for (int i = ex; i < exx; i++)
                                {
                                    bmp.SetPixel(i, eyy, Color.Blue);
                                }//DELETE DIS
                                for (int i = ey; i < eyy; i++)
                                {
                                    bmp.SetPixel(exx, i, Color.Blue);
                                }*/
                            }
                            else
                            {
                                MessageBox.Show("Can't fit another object in cell");
                            }
                          
                        }
                        else if(Math.Abs(x - xx) < Math.Abs(y - yy))
                        {
                            expected[xd / 64, yd / 64, listboxindexnum + 20] = 1;
                            bool boxerror = false;
                            for (int i = 20; i < 29; i++)
                            {
                                if (expected[xd / 64, yd / 64, i] == 1 && i != listboxindexnum + 20)
                                {
                                    //MessageBox.Show("Can't fit another object in cell");
                                    expected[xd / 64, yd / 64, listboxindexnum + 20] = 0;
                                    boxerror = true;
                                }
                            }
                            if(boxerror == false)
                            {
                                expected[xd / 64, yd / 64, 15] = 1;
                                expected[xd / 64, yd / 64, 16] = Math.Min((Math.Max(((midx - xd) / num1), 0)), 1); //works out the bx 
                                expected[xd / 64, yd / 64, 17] = Math.Min((Math.Max(((midy - yd) / num1), 0)), 1);//works out the by
                                expected[xd / 64, yd / 64, 18] = Math.Abs(x - xx) / 448.0;//works out the bw
                                expected[xd / 64, yd / 64, 19] = Math.Abs(yy - y) / 448.0;//works out the bh

                                /*for (int i = rx; i < rxx; i++)
                                {
                                    bmp.SetPixel(i, ry, Color.Blue);
                                }
                                for (int i = ry; i < ryy; i++)
                                {
                                    bmp.SetPixel(rx, i, Color.Blue);
                                }
                                for (int i = rx; i < rxx; i++)
                                {
                                    bmp.SetPixel(i, ryy, Color.Blue);
                                }//DELETE DIS
                                for (int i = ry; i < ryy; i++)
                                {
                                    bmp.SetPixel(rxx, i, Color.Blue);
                                }*/
                            }
                            else
                            {
                                MessageBox.Show("Can't fit another object in cell");
                            }

                        }
                        else
                        {
                            expected[xd / 64, yd / 64, listboxindexnum + 20] = 1;
                            bool boxerror = false;
                            for (int i = 20; i < 29; i++)
                            {
                                if (expected[xd / 64, yd / 64, i] == 1 && i != listboxindexnum + 20)
                                {
                                    //MessageBox.Show("Can't fit another object in cell");
                                    expected[xd / 64, yd / 64, listboxindexnum + 20] = 0;
                                    boxerror = true;
                                }
                            }

                            if(boxerror == false)
                            {
                                expected[xd / 64, yd / 64, 15] = 1;
                                expected[xd / 64, yd / 64, 16] = Math.Min((Math.Max(((midx - xd) / num1), 0)), 1); //works out the bx 
                                expected[xd / 64, yd / 64, 17] = Math.Min((Math.Max(((midy - yd) / num1), 0)), 1);//works out the by
                                expected[xd / 64, yd / 64, 18] = Math.Abs(x - xx) / 448.0;//works out the bw
                                expected[xd / 64, yd / 64, 19] = Math.Abs(yy - y) / 448.0;//works out the bh

                                /*for (int i = rx; i < rxx; i++)
                                {
                                    bmp.SetPixel(i, ry, Color.Blue);
                                }
                                for (int i = ry; i < ryy; i++)
                                {
                                    bmp.SetPixel(rx, i, Color.Blue);
                                }
                                for (int i = rx; i < rxx; i++)
                                {
                                    bmp.SetPixel(i, ryy, Color.Blue);
                                }//DELETE DIS
                                for (int i = ry; i < ryy; i++)
                                {
                                    bmp.SetPixel(rxx, i, Color.Blue);
                                }*/
                            }
                            else
                            {
                                MessageBox.Show("Can't fit another object in cell");
                            }


                        }
                        pictureBoxImg.Image = bmp;

                        //MessageBox.Show(x.ToString() + "      " + y.ToString());//for debuging
                        //expected[ex, ey, 0] =  (midx - x) / num1; //works out the bx 
                       // expected[ex, ey, 1] = (midy - y) / num1;//works out the by
                        //MessageBox.Show(expected[ex, ey, 0].ToString() + "x " + expected[ex,ey,1].ToString() + "y ");//for debuging


                    }
                }               
                selected = false;
            }
        }



        private static double IoUgenerator(double x, double y, double xx, double yy, double x_2, double y_2, double xx_2, double yy_2)
        {   
            double area1 = Math.Abs(x - xx) * Math.Abs(y - yy);//all explained in the documentation
            double area2 = Math.Abs(x_2 - xx_2) * Math.Abs(y_2 - yy_2);

            double areaofoverlap = (Math.Min(xx, xx_2) - Math.Max(x, x_2)) * (Math.Min(yy, yy_2) - Math.Max(y, y_2));
            double areaofunion = area1 + area2 - areaofoverlap;
            
            return areaofoverlap/areaofunion;
        }

        private void pictureBoxImg_MouseMove(object sender, MouseEventArgs e)
        {
            if(selected == true)//this is just to make it look nicer.
            {
                int xxx = e.X;
                int yyy = e.Y;
                if (xxx != previousx && yyy != previousy)
                {
                    bitm = new Bitmap(bmp);//creates a copy of the image
                    previousx = x;//to reduce lag, I decided to implement this so it would check if the location of the cursor has changed or not
                    previousy = y;
                    for (int i = x; i < xxx; i++)//draws box 
                    {
                        bitm.SetPixel(i, y, Color.Red);
                    }
                    for (int i = y; i < yyy; i++)
                    {
                        bitm.SetPixel(x, i, Color.Red);
                    }
                    for (int i = x; i < xxx; i++)
                    {
                        bitm.SetPixel(i, yyy, Color.Red);
                    }
                    for (int i = y; i < yyy; i++)
                    {
                        bitm.SetPixel(xxx, i, Color.Red);
                    }
                    pictureBoxImg.Image = bmp;//clears the previous image back to default
                    pictureBoxImg.Image = bitm;//sets the image with the drawn box
                }
            }
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            MessageBox.Show("please select the data folder");
            FolderBrowserDialog fl = new FolderBrowserDialog();
            DialogResult rl = fl.ShowDialog();
            
            if (rl == DialogResult.OK && fl.SelectedPath != "")
            {
               location = fl.SelectedPath.ToString();
               var readmisc = File.ReadAllLines(location + "\\misc.txt");
               string[] sr = new string[21];
               for(int i = 1; i < readmisc.Count(); i++)
               {
                    listBox1.Items.Add(readmisc[i]);      
               }
                listBox1.SelectedIndex = 0;
                load();
            }
            else
            {
                MessageBox.Show("Invalid file path");
            }



        }
        private void load()
        {
            var readf64_7x7 = File.ReadAllLines(location + "\\filters\\f64_7x7.txt");//filters
            var readf128_1x1 = File.ReadAllLines(location + "\\filters\\f128_1x1.txt");
            var readf192_3x3 = File.ReadAllLines(location + "\\filters\\f192_3x3.txt");
            var readf256_1x1 = File.ReadAllLines(location + "\\filters\\f256_1x1.txt");
            var readf256_3x3 = File.ReadAllLines(location + "\\filters\\f256_3x3.txt");
            var readf512_1x1 = File.ReadAllLines(location + "\\filters\\f512_1x1.txt");
            var readf512_3x3 = File.ReadAllLines(location + "\\filters\\f512_3x3.txt");
            var readf1024_3x3 = File.ReadAllLines(location + "\\filters\\f1024_3x3.txt");


            int tem = 0;
            int tem2 = 0;
            int tem3 = 0;
            int tem3_1 = 0;
            int tem_1 = 0;
            int tem4 = 0;
            int tem4_1 = 0;
            for (int i = 0; i < 6144; i++)//1024x3x3x6 = 6144 which is the ammount of loops this will go through
            {
                loading_value++;


                if (i < 6144)//makes sure that the program doesn't execute the code within the if statement more than 1024 times
                {
                    if (tem >= 1024)
                    {
                        tem = 0;
                        tem_1++;
                    }
                    int tmpp = 0;//temporary value
                    string[] word = readf1024_3x3[i].Split(',');//using similar code as the one with weights but since, the data is only fetched -
                    //line by line, this function will have to split that 1 line into many seperate numbers
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {


                            Abstractor.filter_1024_3x3[tem, y, x, tem_1] = Convert.ToInt32(word[tmpp]);//stores the data into a 3d integer array
                            tmpp++;
                        }
                    }
                    tem++;
                }


                if (i < 64)
                {
                    int tmpp = 0;
                    string[] word = readf64_7x7[i].Split(',');
                    for (int y = 0; y < 7; y++)
                    {
                        for (int x = 0; x < 7; x++)
                        {


                            Abstractor.filter_64_7x7[i, y, x] = Convert.ToInt32(word[tmpp]);
                            tmpp++;
                        }
                    }
                }
                if (i < 128)
                {

                    Abstractor.filter_128_1x1[i] = Convert.ToInt32(readf128_1x1[i]);//since filter_128_1x1 is only a 1x1 then there's no need to make a 3d int array so this -
                    //segment of code will be used just like it was used with w1 and w2
                }
                if (i < 192)
                {
                    int tmpp = 0;
                    string[] word = readf192_3x3[i].Split(',');
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Abstractor.filter_192_3x3[i, y, x] = Convert.ToInt32(word[tmpp]);
                            tmpp++;
                        }

                    }
                }
                if (i < 256)
                {
                    int tmpp = 0;
                    string[] word = readf256_3x3[i].Split(',');
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Abstractor.filter_256_3x3[i, y, x] = Convert.ToInt32(word[tmpp]);
                            tmpp++;
                        }

                    }
                    tem2++;
                }
                if (i < 512)
                {
                    if (tem4 >= 256)
                    {
                        tem4 = 0;
                        tem4_1++;
                    }
                    Abstractor.filter_256_1x1[tem4, tem4_1] = Convert.ToInt32(readf256_1x1[i]);
                    tem4++;
                }


                if (i < 1024)//doubled because of filter problem
                {
                    if (tem3 >= 512)
                    {
                        tem3 = 0;//makes sure that tem3 doesn't go over 512 which is the maximum
                        tem3_1++;//increments the filter layer pivot
                    }
                    Abstractor.filter_512_1x1[tem3, tem3_1] = Convert.ToInt32(readf512_1x1[i]);//readf512_1x1 size is 1024 but it will read the first half if -
                    //tem3_1 = 0 and would read the last half if tem3_1 = 1
                    int tmpp = 0;
                    string[] word = readf512_3x3[i].Split(',');//splits the filter values when it finds a ,
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Abstractor.filter_512_3x3[tem3, y, x, tem3_1] = Convert.ToInt32(word[tmpp]);
                            tmpp++;
                        }

                    }
                    tem3++;
                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            listboxindexnum = listBox1.SelectedIndex;
            bmp = new Bitmap(default_bmp);
            pictureBoxImg.Image = default_bmp;
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {

                    if (expected[x, y, 15] == 1.0 && expected[x, y, 16] != 0.0 && expected[x, y, 16] != 1.0 && expected[x, y, 17] != 0.0 && expected[x, y, 17] != 1.0 && expected[x, y, listboxindexnum + 20] == 1)
                    {
                        double bx = (expected[x, y, 16] * 64.0) + (x * 64.0);//works out the centre location of the object x
                        double by = (expected[x, y, 17] * 64.0) + (y * 64.0);//works out the centre location of the object y
                        double bw = (expected[x, y, 18] * 448.0);//works out the width of the object
                        double bh = (expected[x, y, 19] * 448.0);//works out the height of the object
                        int obx = Math.Abs(Convert.ToInt32((bw / 2.0) - bx));
                        int oby = Math.Abs(Convert.ToInt32((bh / 2.0) - by));

                        int obxx = Math.Abs(Convert.ToInt32((bw / 2.0) + bx));
                        int obyy = Math.Abs(Convert.ToInt32((bh / 2.0) + by));


                        for (int i = obx; i < obxx; i++)
                        {
                            bmp.SetPixel(i, oby, Color.Green);
                        }
                        for (int i = oby; i < obyy; i++)
                        {
                            bmp.SetPixel(obx, i, Color.Green);
                        }
                        for (int i = obx; i < obxx; i++)
                        {
                            bmp.SetPixel(i, obyy, Color.Green);
                        }
                        for (int i = oby; i < obyy; i++)
                        {
                            bmp.SetPixel(obxx, i, Color.Green);
                        }
                    }

                    if (expected[x, y, 0] == 1.0 && expected[x, y, 1] != 0.0 && expected[x, y, 1] != 1.0 && expected[x, y, 2] != 0.0 && expected[x, y, 2] != 1.0 && expected[x, y, listboxindexnum + 5] == 1)
                    {
                        double bx = (expected[x, y, 1] * 64.0) + (x * 64.0);
                        double by = (expected[x, y, 2] * 64.0) + (y * 64.0);
                        double bw = (expected[x, y, 3] * 448.0);
                        double bh = (expected[x, y, 4] * 448.0);
                        int obx = Math.Abs(Convert.ToInt32((bw / 2.0) - bx));
                        int oby = Math.Abs(Convert.ToInt32((bh / 2.0) - by));

                        int obxx = Math.Abs(Convert.ToInt32((bw / 2.0) + bx));
                        int obyy = Math.Abs(Convert.ToInt32((bh / 2.0) + by));

                        for (int i = obx; i < obxx; i++)
                        {
                            bmp.SetPixel(i, oby, Color.Green);
                        }
                        for (int i = oby; i < obyy; i++)
                        {
                            bmp.SetPixel(obx, i, Color.Green);
                        }
                        for (int i = obx; i < obxx; i++)
                        {
                            bmp.SetPixel(i, obyy, Color.Green);
                        }
                        for (int i = oby; i < obyy; i++)
                        {
                            bmp.SetPixel(obxx, i, Color.Green);
                        }
                        
                    }
                }

            }
            pictureBoxImg.Image = bmp;

        }

        private void buttonabstract_Click(object sender, EventArgs e)
        {
            Abstractor.trainorform = true;
            Abstractor.bmp = default_bmp;
            Abstractor abs = new Abstractor();
            Thread tr = new Thread(() => abs.main());
            tr.Start();
            loading = true;
            loadinglabeltxt = "Abstracting image";
            loading_max = 28;
            loading_value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Abstractor.finished == true  && Abstractor.trainorform == true)
            {

                loading = false;
                loadinglabeltxt = "";
                loading_max = 0;
                loading_value = 0;
                Abstractor.started = false;
                Abstractor.finished = false;


            }
            if (loading == true)
            {
                progressBar1_loading.Visible = true;
                label1_loading.Visible = true;
                pictureBox_loadingback.Visible = true;
                pictureBox_loadinggif.Visible = true;
                label1_loading.Text = loadinglabeltxt;
                progressBar1_loading.Maximum = loading_max;
                progressBar1_loading.Value = loading_value;


            }
            else if (loading == false)
            {
                progressBar1_loading.Visible = false;
                label1_loading.Visible = false;
                pictureBox_loadinggif.Visible = false;
                pictureBox_loadingback.Visible = false;

            }
        }
    }
}
