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
using System.Windows.Media;

namespace ProjectImagerecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool selectedstatic = true;

        static double[] w1 = new double[205520896];
        static double[] w2 = new double[6021120];
        static double[,,] outpp = new double[7, 7, 30];
        static int[,,] filter_64_7x7 = new int[64,7,7];
        static int[,,] filter_192_3x3 = new int[192, 3, 3];
        static int[] filter_128_1x1 = new int[128];
        static int[,,] filter_256_3x3 = new int[256, 3, 3];
        static int[,] filter_256_1x1 = new int[256,2];//changed so more different filters
        static int[,] filter_512_1x1 = new int[512,2]; 
        static int[,,,] filter_512_3x3 = new int[512, 3, 3,2];
        static int[,,,] filter_1024_3x3 = new int[1024, 3, 3,6];
        public static int loading_value = 0;
        static int loading_max = 0;
        static bool loading = false;
        static bool listboxloaded = false;
        static string loadinglabeltxt = "loading";
        static string location = "";
        static Thread tr;

        static string[] objectlabel = new string[21]; //20 objects +1 
        static Bitmap bp; //main image
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void panel2_file_MouseLeave(object sender, EventArgs e)
        {
            panel2_file.Visible = false;
            label1_file.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void panel2_Neuraledit_MouseLeave(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = false;
        }

        private void pictureBox2_main_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = false;
            panel2_file.Visible = false;
            label1_file.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void pictureBox2_main_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("tmpp.txt");//temporary file
            Random rn = new Random();
            string ss = "";
            for(int f = 0; f < 6144; f++)
            {
                for(int y = 0; y < 3; y++)
                {
                    for(int x = 0; x< 3; x++)
                    {
                        int num = rn.Next(1, 4);//random number generated
                        while (num == 0)//will loop until the random number isn't a 0
                        {
                            num = rn.Next(1, 4);//number randomly generated
                        }
                        ss += "," + num.ToString();
                    }
                }
                sr.WriteLine(ss.ToString());//once there aren't any 0's the number gets written into the filter.
                ss = "";
            }
            sr.Close();//saves the file
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = false;

        }

        private void label1_file_Click(object sender, EventArgs e)
        {

        }

        private void label1_file_MouseEnter(object sender, EventArgs e)
        {
            panel2_file.Visible = true;
            label1_file.BackColor = Color.LightGray;
        }

        private void label1_file_MouseLeave(object sender, EventArgs e)
        {
            label1_file.BackColor = Color.Gray;


        }

        private void label2_edit_MouseEnter(object sender, EventArgs e)
        {
            label2_edit.BackColor = Color.LightGray;
            panel2_file.Visible = false;
            label1_file.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void label3_view_MouseEnter(object sender, EventArgs e)
        {
            label3_view.BackColor = Color.LightGray;
        }

        private void label3_view_MouseLeave(object sender, EventArgs e)
        {
            label3_view.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void label2_edit_MouseLeave(object sender, EventArgs e)
        {
            label2_edit.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1_staticimagemode.BackColor = Color.DimGray;

        }

        private void label1_neuralnetwork_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = true;
            label1_neuralnetwork.BackColor = Color.LightGray;
        }

        private void label1_neuralnetwork_MouseLeave(object sender, EventArgs e)
        {
            label1_neuralnetwork.BackColor = Color.Gray;
            //panel2_Neuraledit.Visible = false;
        }

        private void label1_staticimagemode_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = false;
            label1_staticimagemode.BackColor = Color.LightGray;
        }

        private void label2_liveimagemode_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = false;
            label2_liveimagemode.BackColor = Color.LightGray;
        }

        private void label2_objectdetector_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = true;
        }

        private void label3_imagerecognition_MouseEnter(object sender, EventArgs e)
        {
            panel2_Neuraledit.Visible = true;
        }

        private void label1_staticimagemode_MouseLeave(object sender, EventArgs e)
        {
            if(selectedstatic == true)
            {
                label1_staticimagemode.BackColor = Color.DimGray;
            }
            else
            {
                label1_staticimagemode.BackColor = Color.Gray;
            }

        }

        private void label1_staticimagemode_Click(object sender, EventArgs e)
        {
            selectedstatic = true;
            label1_staticimagemode.BackColor = Color.DarkGray;
            label2_liveimagemode.BackColor = Color.Gray;
        }

        private void label2_liveimagemode_Click(object sender, EventArgs e)
        {
            selectedstatic = false;
            label2_liveimagemode.BackColor = Color.DarkGray;
            label1_staticimagemode.BackColor = Color.Gray;

        }

        private void label2_liveimagemode_MouseLeave(object sender, EventArgs e)
        {
            if (selectedstatic == false)
            {
                label2_liveimagemode.BackColor = Color.DimGray;
            }
            else
            {
                label2_liveimagemode.BackColor = Color.Gray;
            }
            
        }

        private static void fetchdata()
        {

            var readw1 = File.ReadLines(location +"\\w1.txt");//specifies the location of the file
            var readw2 = File.ReadLines(location+"\\w2.txt");//weights
            
       
            var readf64_7x7 = File.ReadAllLines(location+"\\filters\\f64_7x7.txt");//filters
            var readf128_1x1 = File.ReadAllLines(location + "\\filters\\f128_1x1.txt");
            var readf192_3x3 = File.ReadAllLines(location + "\\filters\\f192_3x3.txt");
            var readf256_1x1 = File.ReadAllLines(location + "\\filters\\f256_1x1.txt");
            var readf256_3x3 = File.ReadAllLines(location + "\\filters\\f256_3x3.txt");
            var readf512_1x1 = File.ReadAllLines(location + "\\filters\\f512_1x1.txt");
            var readf512_3x3 = File.ReadAllLines(location + "\\filters\\f512_3x3.txt");
            var readf1024_3x3 = File.ReadAllLines(location + "\\filters\\f1024_3x3.txt");
            var readmisc = File.ReadAllLines(location + "\\misc.txt");
            int teemp = 0;//temporary variable
            loading = true;//for loading progress bar, activates it
            loading_max = 211543040;//specifies the size of progressbar6
            loading_value = 0;//sets the loading value back to 0 which is the start
           
           foreach (var line in readw1)//loops 205520896 times
            {
                
                w1[teemp] = Convert.ToDouble(line);//stores each line in w1.txt to a 1d double array
                teemp++;//incremeants the temporary value
                loading_value++;//increase the loading progressbar value
                loadinglabeltxt = "loading Weights(w1)";
            }
            teemp = 0;
            foreach(var line in readw2)//loops 6021120 times, since that's how many weights and lines there are 
            {
                w2[teemp] = Convert.ToDouble(line);
                teemp++;
                loading_value++;
                loadinglabeltxt = "loading Weights(w2)";
            }
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
                    if(tem >= 1024)
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
                    for (int y = 0; y< 7; y++)
                    {
                        for(int x = 0; x< 7; x++)
                        {
                            
                           
                            Abstractor.filter_64_7x7[i, y, x] = Convert.ToInt32(word[tmpp]);
                            tmpp++;
                        }
                    }
                }
                if(i < readmisc.Count())// loops around how many objects there are in a text file
                {
                    objectlabel[i] = readmisc[i];//stores data in another array
                }
                if(i < 128)
                {

                    Abstractor.filter_128_1x1[i] = Convert.ToInt32(readf128_1x1[i]);//since filter_128_1x1 is only a 1x1 then there's no need to make a 3d int array so this -
                    //segment of code will be used just like it was used with w1 and w2
                }
                if (i< 192)
                {
                    int tmpp = 0;
                    string[] word = readf192_3x3[i].Split(',');
                    for(int y = 0; y < 3; y++)
                    {
                        for(int x = 0; x<3; x++)
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
                    if(tem3 >= 512)
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
            loadinglabeltxt = "loading";
            listboxloaded = true;
            loading_value = 0;//sets the values back to default
            loading_max = 0;
            loading = false;//dissables loading progress bar
            MessageBox.Show("Data fully loaded");

            tr.Abort();


        }
        private void draw()
        {
            double trm = 0;
            int trmx = 0;
            int trmy = 0;
            int trmi = 0;
            outpp = neuralnetwork(Abstractor.inp);
            Bitmap bp = new Bitmap(pictureBox2_main.Image);
            for(int y = 0; y< 7; y++)
            {
                for(int x = 0; x<7; x++)
                {
                    textBox1_logs.Text += "\r\n" + outpp[x, y, 0].ToString();
                    textBox1_logs.Text += "\r\n" + outpp[x, y, 15].ToString();
                    if (outpp[x,y,0] >= 0.2 &&outpp[x,y,0] <= 1.1 && outpp[x,y,1] < 1.0 && outpp[x,y,2] < 1.0)
                    {
                        if(trm < outpp[x, y, 0])
                        {
                            trm = outpp[x, y, 0];
                            trmx = x;
                            trmy = y;
                            trmi = 0;
                            /*int bx = Convert.ToInt32((outpp[x, y, 1] * 64.0) + (x * 64.0));
                            int by = Convert.ToInt32((outpp[x, y, 2] * 64.0) + (y * 64.0));
                            int bw = Convert.ToInt32(outpp[x, y, 3] * 448.0);
                            int bh = Convert.ToInt32(outpp[x, y, 4] * 448.0);

                            int Lx = bx - (bw / 2);
                            int Rx = bx + (bw / 2);
                            int Uy = by - (bh / 2);
                            int Dy = by + (bh / 2);



                            for (int xx = Lx; xx < Rx; xx++)
                            {
                                bp.SetPixel(xx, Uy, Color.Red);//top Left to right
                            }
                            for (int xx = Lx; xx < Rx; xx++)
                            {
                                bp.SetPixel(xx, Dy, Color.Red);//bottom Left to right
                            }
                            for (int yy = Uy; yy < Dy; yy++)
                            {
                                bp.SetPixel(Lx, yy, Color.Red);
                            }
                            for (int yy = Uy; yy < Dy; yy++)
                            {
                                bp.SetPixel(Rx, yy, Color.Red);
                            }*/


                        }



                    }
                    if (outpp[x, y, 15] >= 0.5 && outpp[x, y, 15] <= 1.1 && outpp[x, y, 16] < 1.0 && outpp[x, y, 17] < 1.0)
                    {
                        if(trm < outpp[x, y, 15])
                        {
                            trm = outpp[x, y, 15];
                            trmx = x;
                            trmy = y;
                            trmi = 15;
                            /*int bx = Convert.ToInt32((outpp[x, y, 16] * 64.0) + (x * 64.0));
                            int by = Convert.ToInt32((outpp[x, y, 17] * 64.0) + (y * 64.0));
                            int bw = Convert.ToInt32(outpp[x, y, 18] * 448.0);
                            int bh = Convert.ToInt32(outpp[x, y, 19] * 448.0);

                            int Lx = Math.Min(Math.Max(bx - (bw / 2), 0), 447);
                            int Rx = Math.Min(Math.Max(bx + (bw / 2), 0), 447);
                            int Uy = Math.Min(Math.Max(by - (bh / 2), 0), 447);
                            int Dy = Math.Min(Math.Max(by + (bh / 2), 0), 447);


                            for (int xx = Lx; xx < Rx; xx++)
                            {
                                bp.SetPixel(xx, Uy, Color.Red);//top Left to right
                            }
                            for (int xx = Lx; xx < Rx; xx++)
                            {
                                bp.SetPixel(xx, Dy, Color.Red);//bottom Left to right
                            }
                            for (int yy = Uy; yy < Dy; yy++)
                            {
                                bp.SetPixel(Lx, yy, Color.Red);
                            }
                            for (int yy = Uy; yy < Dy; yy++)
                            {
                                bp.SetPixel(Rx, yy, Color.Red);
                            }*/

                        }
                       


                    }

                }

            }
            int bx = Convert.ToInt32((outpp[trmx,trmy,trmi+1] * 64.0) + (trmx * 64.0));
            int by = Convert.ToInt32((outpp[trmx, trmy, trmi+2] * 64.0) + (trmy * 64.0));
            int bw = Convert.ToInt32(outpp[trmx, trmy, trmi+3] * 448.0);
            int bh = Convert.ToInt32(outpp[trmx, trmy, trmi+4] * 448.0);

            int Lx = bx - (bw / 2);
            int Rx = bx + (bw / 2);
            int Uy = by - (bh / 2);
            int Dy = by + (bh / 2);



            for (int xx = Lx; xx < Rx; xx++)
            {
                bp.SetPixel(xx, Uy, Color.Red);//top Left to right
            }
            for (int xx = Lx; xx < Rx; xx++)
            {
                bp.SetPixel(xx, Dy, Color.Red);//bottom Left to right
            }
            for (int yy = Uy; yy < Dy; yy++)
            {
                bp.SetPixel(Lx, yy, Color.Red);
            }
            for (int yy = Uy; yy < Dy; yy++)
            {
                bp.SetPixel(Rx, yy, Color.Red);
            }
            pictureBox2_main.Image = bp;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Abstractor.finished == true && Abstractor.trainorform == false)
            {
                loading = false;
                loadinglabeltxt = "";
                loading_max = 0;
                loading_value = 0;
                Abstractor.started = false;
                Abstractor.finished = false;
                draw();
                

                
            }
            if(loading == true)
            {
                progressBar1_loading.Visible = true;
                label1_loading.Visible = true;
                pictureBox_loadingback.Visible = true;
                pictureBox_loadinggif.Visible = true;
                label1_loading.Text = loadinglabeltxt;
                progressBar1_loading.Maximum = loading_max;
                progressBar1_loading.Value = loading_value;

                
            }
            else if(loading == false)
            {
                progressBar1_loading.Visible = false;
                label1_loading.Visible = false;
                pictureBox_loadinggif.Visible = false;
                pictureBox_loadingback.Visible = false;
                
            }
        }

        private void button2_load_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            MessageBox.Show("please select the data folder");
            FolderBrowserDialog fl = new FolderBrowserDialog();
            DialogResult rl = fl.ShowDialog();
            
            if (rl == DialogResult.OK && fl.SelectedPath != "")
            {
                location = fl.SelectedPath.ToString();
                tr = new Thread(fetchdata);
                tr.IsBackground = true;
                tr.Start();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(listboxloaded == true)
            {
                listboxloaded = false;
                for(int i = 1; i< 10; i++)
                {
                    if(objectlabel[i] == null)
                    {
                        listBox1.Items.Add("(NULL)");
                    }
                    else
                    {
                        listBox1.Items.Add(objectlabel[i]);//objects
                    }
                }
                label1_objectfilename.Text = objectlabel[0]; // the main name of the file
                textBox1_logs.Text += "\r\n Data loaded";
                timer2.Enabled = false;
            }
        
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            MessageBox.Show("please select the image you want to import");
            OpenFileDialog fl = new OpenFileDialog();
            DialogResult rl = fl.ShowDialog();
            if(rl == DialogResult.OK)
            {
                try
                {
                    bp = new Bitmap(fl.FileName);
                    Bitmap resized = new Bitmap(bp, new Size(448, 448));
                    
                    pictureBox2_main.Image = resized;
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

        private void button1_detect_Click(object sender, EventArgs e)
        {
            try
            {
                double[,,] tmp;
                Bitmap bmp = new Bitmap(pictureBox2_main.Image);

                double[] inp = new double[50176];// 1024x7x7 = 50176
                int temp = 0;//pointer

                Abstractor.trainorform = false;
                Abstractor.bmp = bmp;
                Abstractor abs = new Abstractor();
                Thread tr = new Thread(() => abs.main());
                tr.Start();
                loading = true;
                loadinglabeltxt = "Abstracting image";
                loading_max = 28;
                loading_value = 0;
                
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private static double[,,] neuralnetwork(double[] inp)
        {
            
            
                double[] hiddenlayer = new double[4096];//size ofx the hidden layer
                double[] outp = new double[1470];//output size(7x7x30)
                double[,,] outp_3d = new double[7, 7, 30];//create 3d array
               double tmpp = 0.0;
                for (int ff = 0; ff < inp.Count(); ff++)
                {
                    tmpp += inp[ff];
                }
                for (int ff = 0; ff < inp.Count(); ff++)
                {
                    inp[ff] = inp[ff] / tmpp;
                }
                int tmp = 0;
                for (int i = 0; i < 4096; i++)//hidden layer size
                {
                    for (int x = 0; x < inp.Count(); x++)//7x7x1024 = 50176 inputs
                {
                        hiddenlayer[i] += inp[x] * w1[tmp]; //works out the hidden layer's value
                        tmp++;
                    }
                }
                tmp = 0;
                for (int i = 0; i < 1470; i++)
                {
                    for (int x = 0; x < 4096; x++)
                    {
                        outp[i] += hiddenlayer[x] * w2[tmp];
                        tmp++;
                    }
                }
                tmp = 0;
                for (int i = 0; i < 30; i++)
                {
                    for (int y = 0; y < 7; y++)
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            outp_3d[x, y, i] = outp[tmp];//simply stores the 1d double array into a 3d double array
                            tmp++;
                        }
                    }
                }


                return outp_3d;
        }

        private void label2_objectdetector_Click(object sender, EventArgs e)
        {
            Setuptrain sr = new Setuptrain();
            sr.Show();
        }

        private void label3_imagerecognition_Click(object sender, EventArgs e)
        {
            Neuralnetworktrainer nw = new Neuralnetworktrainer();
            nw.Show();
        }
    }
}
