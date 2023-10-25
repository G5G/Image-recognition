using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
namespace ProjectImagerecognition
{
    class Abstractor
    {
        public static int[,,] filter_64_7x7 = new int[64, 7, 7];
        public static int[,,] filter_192_3x3 = new int[192, 3, 3];
        public static int[] filter_128_1x1 = new int[128];
        public static int[,,] filter_256_3x3 = new int[256, 3, 3];
        public static int[,] filter_256_1x1 = new int[256, 2];//changed so more different filters
        public static int[,] filter_512_1x1 = new int[512, 2];
        public static int[,,,] filter_512_3x3 = new int[512, 3, 3, 2];
        public static int[,,,] filter_1024_3x3 = new int[1024, 3, 3, 6];
        public static Bitmap bmp = new Bitmap(448,448);
        public static double[] inp = new double[50176];
        //public static int loadstatus = 0;
        public static bool finished = false;
        public static bool started = false;
        public static bool trainorform = false; // checks which one called the abstraction function false = form1 true = setuptrain
        

        public void main()
        {
            int loadstatus = 0;
            double[,,] tmp;
            tmp = convolution64_7x7(bmp);
            loadstatus++;
            Form1.loading_value = loadstatus;
            Setuptrain.loading_value = loadstatus;
            tmp = maxpool(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution192_3x3(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = maxpool(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution128_1x1(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution256_3x3(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution256_1x1(tmp, 0);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_3x3(tmp, 0);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = maxpool(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;

            tmp = convolution256_1x1(tmp, 0);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution256_1x1(tmp, 0);//ERROR sets array to 0
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution256_1x1(tmp,0);//4 times same filter
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution256_1x1(tmp, 0);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_3x3(tmp, 1);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_3x3(tmp, 1);//4 times same filter
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_3x3(tmp, 1);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_3x3(tmp, 1);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_1x1(tmp, 0);//broke
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3(tmp, 0);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = maxpool(tmp);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_1x1(tmp, 1);//2 times
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution512_1x1(tmp, 1);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3(tmp, 1);//2 times
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3(tmp, 1);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3(tmp, 2);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3_s2(tmp, 3);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;

            tmp = convolution1024_3x3(tmp, 4);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;
            tmp = convolution1024_3x3(tmp, 5);
            loadstatus++;
            Setuptrain.loading_value = loadstatus;
            Form1.loading_value = loadstatus;

            int temp = 0;//pointer
            double ttt = 0.0;
            for (int i = 0; i < 1024; i++)
            {
                for (int y = 0; y < 7; y++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        //MessageBox.Show(Math.Max(tmp[x, y, i], 0.1).ToString());

                        inp[temp] = Math.Max(tmp[x, y, i], 0.1);//stores a 3d integer array into a 1d integer array
                        ttt += inp[temp];
                        temp++;//increments the pointer
                    }
                }
            }
            temp = 0;
            /*for (int i = 0; i < 1024; i++)
            {
                for (int y = 0; y < 7; y++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        //MessageBox.Show(Math.Max(tmp[x, y, i], 0.1).ToString());

                        inp[temp] = inp[temp] / ttt;//stores a 3d integer array into a 1d integer array
                        temp++;//increments the pointer
                    }
                }
            }*/
            finished = true;

        }


        private static double[,,] convolution64_7x7(Bitmap bp)
        {
            int[,,] img = new int[448 + 500, 448 + 500, 64];//448x,448y,rgb
            double[,,] img2 = new double[224 + 500, 224 + 500, 64];//224
            int ttmp = 0;

            int pointerx = 0;
            int pointery = 0;

            for (int f = 0; f < 64; f++)
            {
                for (int y = 0; y < 448; y++)
                {
                    for (int x = 0; x < 448; x++)
                    {
                        Color cl = bp.GetPixel(x, y);
                        pointerx++;
                        switch (ttmp)
                        {
                            case 0:
                                img[pointerx, pointery, f] = cl.R;
                                ttmp++;
                                break;
                            case 1:
                                img[pointerx, pointery, f] = cl.G;
                                ttmp++;
                                break;
                            case 2:
                                img[pointerx, pointery, f] = cl.B;
                                ttmp = 0;
                                break;
                        }
                    }
                    pointerx = 0;
                    pointery++;
                }
                pointery = 0;
                pointerx = 0;
            }
            pointerx = 0;
            pointery = 0;
            for (int f = 0; f < 64; f++)
            {
                for (int y = 0; y < 448; y++)
                {
                    for (int x = 0; x < 448; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_64_7x7.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_64_7x7.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_64_7x7[f, xx, yy] * img[x + xx, y + yy, f];
                            }
                        }
                        x++;

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis

                    }

                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis
                    y++;
                }
                pointery = 0;
                pointerx = 0;


            }
            return img2;
        }
        private static double[,,] convolution192_3x3(double[,,] img)
        {

            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 192];

            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 192; f++)
            {
                for (int y = 0; y < img.GetLength(1) - 3; y++)
                {
                    for (int x = 0; x < img.GetLength(0) - 3; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_192_3x3.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_192_3x3.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_192_3x3[f, xx, yy] * img[x + xx, y + yy, tmp];

                            }
                        }

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//increments pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution256_3x3(double[,,] img)
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 256];//224
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 256; f++)
            {
                for (int y = 0; y < img.GetLength(1) - 3; y++)
                {
                    for (int x = 0; x < img.GetLength(0) - 3; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_256_3x3.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_256_3x3.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_256_3x3[f, xx, yy] * img[x + xx, y + yy, tmp];

                            }
                        }

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution256_1x1(double[,,] img, int e)//the array will be passed on and so will the filterarray to be used.
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 256];//128
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 256; f++)
            {
                for (int y = 0; y < img.GetLength(1); y++)
                {
                    for (int x = 0; x < img.GetLength(0); x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        tempor += filter_256_1x1[f, e] * img[x, y, tmp];

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution512_3x3(double[,,] img, int e)
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 512];//224
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 512; f++)
            {
                for (int y = 0; y < img.GetLength(1) - 3; y++)
                {
                    for (int x = 0; x < img.GetLength(0) - 3; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_512_3x3.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_512_3x3.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_512_3x3[f, xx, yy, e] * img[x + xx, y + yy, tmp];

                            }
                        }

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution512_1x1(double[,,] img, int e)
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 512];//128
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 512; f++)
            {
                for (int y = 0; y < img.GetLength(1); y++)
                {
                    for (int x = 0; x < img.GetLength(0); x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        tempor += filter_512_1x1[f, e] * img[x, y, tmp];

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis

                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution1024_3x3(double[,,] img, int e)
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 1024];//224
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 1024; f++)
            {
                for (int y = 0; y < img.GetLength(1) - 3; y++)
                {
                    for (int x = 0; x < img.GetLength(0) - 3; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_1024_3x3.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_1024_3x3.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_1024_3x3[f, xx, yy, e] * img[x + xx, y + yy, tmp];
                            }
                        }

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution1024_3x3_s2(double[,,] img, int e)
        {
            double[,,] img2 = new double[img.GetLength(0) / 2, img.GetLength(1) / 2, 1024];//224
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 1024; f++)
            {
                for (int y = 0; y < img.GetLength(1) - 3; y++)
                {
                    for (int x = 0; x < img.GetLength(0) - 3; x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        for (int yy = 0; yy < filter_1024_3x3.GetLength(2); yy++)
                        {
                            for (int xx = 0; xx < filter_1024_3x3.GetLength(1); xx++)//multiply image by filters
                            {
                                tempor += filter_1024_3x3[f, xx, yy, e] * img[x + xx, y + yy, tmp];
                            }
                        }
                        x++;

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    y++;
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }
        private static double[,,] convolution128_1x1(double[,,] img)
        {
            double[,,] img2 = new double[img.GetLength(0), img.GetLength(1), 128];//128
            int pointerx = 0;
            int pointery = 0;
            int tmp = 0;
            for (int f = 0; f < 128; f++)
            {
                for (int y = 0; y < img.GetLength(1); y++)
                {
                    for (int x = 0; x < img.GetLength(0); x++)
                    {
                        double tempor = 0; //temporary value to store the convolved value which will be passed into the array
                        tempor += filter_128_1x1[f] * img[x, y, tmp];

                        img2[pointerx, pointery, f] = Math.Max(tempor, 0.1);//sets the final array with the convolved values
                        pointerx++;//incremeants pointerx in which tells where in array would we store the convolved value x axis
                    }
                    pointerx = 0; //sets pointer x back to 0
                    pointery++; //incremeants pointery in which tells where in array would we store the convolved value y axis

                }
                pointery = 0;
                pointerx = 0;
                tmp++;
                if (tmp >= img.GetLength(2))
                {
                    tmp = 0;
                }
            }
            return img2;
        }


        private static double[,,] maxpool(double[,,] bmp)
        {

            double[,,] newbmp = new double[bmp.GetLength(0) / 2, bmp.GetLength(1) / 2, bmp.GetLength(2)]; //x,y,filter
            int pointy = 0; //y pointer
            int pointx = 0; //x pointer
            for (int i = 0; i < newbmp.GetLength(2); i++)//applies maxpool on every filter layer
            {
                pointy = 0;
                for (int y = 0; y < newbmp.GetLength(1); y++)//y pixels
                {

                    for (int x = 0; x < newbmp.GetLength(0); x++)//x pixels
                    {
                        double tmp1 = Math.Max(Math.Max(bmp[pointx, pointy, i], bmp[pointx + 1, pointy, i]), Math.Max(bmp[pointx, pointy + 1, i], bmp[pointx + 1, pointy + 1, i]));//gets the maximum value of the 2x2 grid 
                        newbmp[x, y, i] = tmp1;//sets the new array with the maxpooled pixels
                        pointx = pointx + 2;

                    }
                    pointy = pointy + 2;
                    pointx = 0;

                }

                pointy = 0;
                pointx = 0;
            }

            return newbmp;
        }






    }
}
