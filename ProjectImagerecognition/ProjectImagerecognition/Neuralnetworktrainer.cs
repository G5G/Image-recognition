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
    public partial class Neuralnetworktrainer : Form
    {
        public Neuralnetworktrainer()
        {
            InitializeComponent();
        }
        double cost = 0;
        int clicks = 0;
        string location = "";
        double[] w1 = new double[205520896];
        double[] w2 = new double[6021120];
        double[] h1 = new double[4096];
        double[] inp = new double[50176];
        double[] outp = new double[1470];
        double[,,] expected = new double[7, 7, 30];
        int loading_value = 0;
        int loading_max = 0;
        string loadinglabeltxt = "";
        bool loading = false;
        bool loaded = false;
        bool saving = false;
        bool stop = true;
        double chartnum = 0;
        double chartpoint = 0;
        double chartnum_prev = 0;
        double chartpoint_prev = 0;
        Bitmap bp = new Bitmap(448, 448);
  
        Thread tr;


        private void Neuralnetworktrainer_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonAuto_detect_Click(object sender, EventArgs e)
        {
            if(loaded == true)
            {
                buttonAuto_detect.Visible = false;
                button_stop.Visible = true;
                stop = false;
                tr = new Thread(neuralnetbackprop);
                tr.IsBackground = true;
                tr.Start();
                
            }
            else
            {
                MessageBox.Show("Please load the weights first");
            }
            chart_cost.Series["Cost"].Points.AddXY(clicks,cost);
            cost--;
        }

        private void neuralnetbackprop()
        {
            while (true)
            {
                if (stop == false)//while automode is still enabled keep looping
                {
                    int f = 0;
                    while (File.Exists(location + "\\training\\" + f.ToString() + ".txt"))
                    {
                        f++; 
                    }
                    Random rn = new Random();
                    f = rn.Next(0, f);
                    while (!File.Exists(location + "\\training\\" + f.ToString() + ".txt"))
                    {
                        f = rn.Next(0, f);// checks if there are no empty spots.
                    }
                    //MessageBox.Show(f.ToString());
                    var readmisc = File.ReadAllLines(location + "\\training\\" + f.ToString() + ".txt");
                    bp = new Bitmap(location + "\\training\\" + f.ToString() + ".png");
                    pictureBox_outp.Image = bp;
                    int tmp = 0;
                    for (int i = 1470; i < readmisc.Count(); i++)
                    {
                        inp[tmp] = Convert.ToDouble(readmisc[i]);
                        tmp++;
                        //listBox1.Items.Add(readmisc[i]);
                    }
                    tmp = 0;
                    for (int i = 0; i < 30; i++)
                    {
                        for (int y = 0; y < 7; y++)
                        {
                            for (int x = 0; x < 7; x++)
                            {
                                expected[x, y, i] = Convert.ToDouble(readmisc[tmp]);
                                tmp++;
                            }
                        }
                    }
                    h1 = new double[4096];
                    outp = new double[1470];
                    //<Forward propagation so we can get the output of neural net and workout the cost(error)>
                    double tmpp = 0;
                    
                    for(int ff = 0; ff< inp.Count(); ff++)
                    {
                        tmpp += inp[ff];
                    }
                    for(int ff = 0; ff< inp.Count(); ff++)
                    {
                        inp[ff] = inp[ff] / tmpp;
                    }
                    tmp = 0;
                    tmpp = 0;
                    for (int i = 0; i < 4096; i++)
                    {
                        for (int x = 0; x < inp.Count(); x++)
                        {

                            h1[i] += inp[x] * w1[tmp];
                            tmpp += h1[i];
                            tmp++;
                        }
                    }/*
                    for(int i = 0; i< 4096; i++)
                    {
                        h1[i] = h1[i] / tmpp;
                    }*/
                    
                    tmp = 0;
                    for (int i = 0; i < 1470; i++)
                    {
                        for (int x = 0; x < h1.Count(); x++)
                        {
                            outp[i] += h1[x] * w2[tmp];
                            tmp++;
                        }
                        }
                    double[,,] outp_3d = new double[7, 7, 30];
                    tmp = 0;
                    for (int i = 0; i < 30; i++)
                    {
                        for (int y = 0; y < 7; y++)
                        {
                            for (int x = 0; x < 7; x++)
                            {
                                outp_3d[x, y, i] = outp[tmp];
                                tmp++;
                            }
                        }
                    }
                    //<   >
                    double[,,] cost = new double[7, 7, 30];
                    double cost_average = 0;
                    for (int y = 0; y < 7; y++)
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            cost[x,y,1] = expected[x, y, 1] - outp_3d[x, y, 1];//anchorbox 1
                            cost[x,y,16] = expected[x, y, 16] - outp_3d[x, y, 16];//anchorbox 2

                            cost[x,y,2] = expected[x, y, 2] - outp_3d[x, y, 2];//anchorbox1
                            cost[x,y,17] = expected[x, y, 17] - outp_3d[x, y, 17];//anchorbox2


                            cost[x,y,4] = expected[x, y, 4] - outp_3d[x, y, 4];
                            cost[x,y,19] = expected[x, y, 19] - outp_3d[x, y, 19];

                            cost[x,y,3] = expected[x, y, 3] - outp_3d[x, y, 3];
                            cost[x,y,18] = expected[x, y, 18] - outp_3d[x, y, 18];

                            for (int i = 5; i < 15; i++)
                            {
                                cost[x,y,i] = expected[x, y, i] - outp_3d[x, y, i];
                                cost[x,y,i + 15] = expected[x, y, i + 15] - outp_3d[x, y, i + 15];
                            }

                            cost[x,y,0] = expected[x, y, 0] - outp_3d[x, y, 0];
                            cost[x,y,15] = expected[x, y, 15] - outp_3d[x, y, 15];
                        
                            for(int i = 0; i< 30; i++)
                            {
                                cost_average += cost[x, y, i];
                            }

                        }
                    }
                    

                    cost_average =  cost_average / 30;
                    
                    //MessageBox.Show(cost_average.ToString());
                    chartnum = Math.Round(cost_average,3);
                    chartpoint++;
                    tmp = 0;


                    //Backpropagation


                    double[,,] delta = new double[7, 7, 30];
                    int temp = 0;
                    for(int i = 0; i< 30; i++)
                    {
                        for(int y = 0; y < 7; y++)
                        {
                            for(int x = 0; x < 7; x++)
                            {
                                delta[x, y, i] = cost[x, y, i] * reluprime(outp[temp]);
                                temp++;
                            }
                        }
                    }

                    double[] h1error = new double[4096]; //h1
                    temp = 0;
                    for(int i = 0; i< 4096; i++)
                    {
                        for(int fff = 0; fff< 30; fff++)
                        {
                            for(int y = 0; y< 7; y++)
                            {
                                for(int x = 0; x< 7; x++)
                                {
                                    h1error[i] += delta[x,y,fff] * w2[temp];
                                    temp++;
                                }
                            }
                        }   
                    }

                    double[] h1delta = new double[4096];
                    for(int i = 0; i< 4096; i++)
                    {
                        h1delta[i] = h1error[i] * reluprime(h1[i]);
                    }
                    temp = 0;
                    
                    
                    for(int fff = 0; fff< 30; fff++)
                    {
                         for(int y = 0; y< 7; y++)
                         {
                             for(int x = 0; x< 7; x++)
                             {
                                for(int i = 0; i< 4096; i++)
                                {
                                    w2[temp] += (h1[i] * delta[x, y, fff])*0.1;
                                    temp++;
                                }
                             }
                         }
                    }
                        
                    
                    temp = 0;
                    for(int i = 0; i < 4096; i++)
                    {
                        for(int fff = 0; fff < inp.Count(); fff++)
                        {
                            w1[temp] += (inp[fff] * h1delta[i])*0.1;
                            temp++;
                        }
                    }
                    temp = 0;



                }
                else
                {
                    break;//stop looping since automode is off
                }
            }
        }
        double relu(double x)
        {

            double tmp = Math.Max(0.01, x);
            return tmp;
        }
        double reluprime(double x)
        {
            double tmp = 0;
            if (x > 0)
            {
                tmp = 1;
            }
            else
            {
                tmp = 0;
            }
            return tmp;
        }
        private void load()
        {
            var readw1 = File.ReadLines(location + "\\w1.txt");//specifies the location of the file
            var readw2 = File.ReadLines(location + "\\w2.txt");//weights
            loading = true;
            loading_max = 211542016; //size of w1 + w2
            loading_value = 0;
            int teemp = 0;
            foreach (var line in readw1)//loops 205520896 times
            {

                w1[teemp] = Convert.ToDouble(line);//stores each line in w1.txt to a 1d double array
                teemp++;//incremeants the temporary value
                loading_value++;//increase the loading progressbar value
                loadinglabeltxt = "loading Weights(w1)";
            }
            teemp = 0;
            foreach (var line in readw2)//loops 205520896 times
            {

                w2[teemp] = Convert.ToDouble(line);//stores each line in w1.txt to a 1d double array
                teemp++;//incremeants the temporary value
                loading_value++;//increase the loading progressbar value
                loadinglabeltxt = "loading Weights(w2)";
            }


            for(int i = 0; i < 1470; i++)
            {

            }
            loadinglabeltxt = "";
            loading_max = 0;
            loading_value = 0;
            loading = false;//dissables loading and sets all values back to default
            loaded = true;
            tr.Abort();
        }
        private void save()
        {
            loading = true;
            loadinglabeltxt = "Saving Weights(w2)";
            loading_max = 211542016;
            loading_value = 0;
            StreamWriter sr = new StreamWriter(location+"\\w1.txt");//w1
            StreamWriter sr2 = new StreamWriter(location + "\\w2.txt");//w1
            Random rn = new Random();

            for (int f = 0; f < 205520896; f++)
            {
                //double tm = rn.NextDouble() * Math.Sqrt((2.0 / 4096.0));
                sr.WriteLine(w1[f].ToString());//once there aren't any 0's the number gets written into the filter.
                loading_value++;
            }

            for (int f = 0; f < 6021120; f++)
            {
                //double tm = rn.NextDouble() * Math.Sqrt(2.0 / 1470.0);
                sr2.WriteLine(w2[f].ToString());//once there aren't any 0's the number gets written into the filter.
                loading_value++;
            }
            sr.Close();//saves w1 file
            sr2.Close();//saves w2 file
            loading = false;
            loadinglabeltxt = "";
            loading_max = 0;
            loading_value = 0;
            saving = false;
            tr.Abort();
        }
        private void button_Open_Click(object sender, EventArgs e)
        {
            if(saving == false)
            {
                MessageBox.Show("select the data folder");


                FolderBrowserDialog fl = new FolderBrowserDialog();
                DialogResult rl = fl.ShowDialog();
                if (rl == DialogResult.OK && fl.SelectedPath != "")//checks if file was opened successfully
                {
                    location = fl.SelectedPath.ToString();//location of the data folder
                    
                    tr = new Thread(load);//creates a thread in which would load up the weights without freezing the whole program
                    tr.IsBackground = true;
                    tr.Start();
                    //var readw1 = File.ReadAllLines(location + "\\w1.txt"); 
                    //string[] sr = new string[21];
                    /*for (int i = 1; i < readw1.Count(); i++)
                    {
                        //listBox1.Items.Add(readmisc[i]);
                    }*/
                }
                else
                {
                    MessageBox.Show("Invalid file path");
                }
            }
            else
            {
                MessageBox.Show("Saving in progress, please wait...");
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            pictureBox_outp.Image = bp;
            if(chartnum_prev != chartnum || chartpoint_prev != chartpoint)
            {
                chart_cost.Series["Cost"].Points.AddXY(chartpoint, chartnum);
                chartnum_prev = chartnum;
                chartpoint_prev = chartpoint;
            }

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(loaded == true)
            {
                saving = true;
                tr = new Thread(save);
                tr.IsBackground = true;
                tr.Start();
            }
            else
            {
                MessageBox.Show("Please load up the weights first");
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            button_stop.Visible = false;
            buttonAuto_detect.Visible = true;
            stop = true;

        }

        private void pictureBox_outp_Click(object sender, EventArgs e)
        {

        }

        private void button_manualtrain_Click(object sender, EventArgs e)
        {

        }
    }
}
