using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace adaptive_thresholding
{
    public partial class Form1 : Form
    {
        Bitmap asli, gray, hasilakhir, objBitmapcrop;
        int[,] graynya, sumimage, thesum,mean,thresholdnya,gray2,sumimage2,output;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog(); if (d == DialogResult.OK) { asli = new Bitmap(openFileDialog1.FileName); pictureBox1.Image = asli; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gray = new Bitmap(asli);
            gray2 = new int[gray.Width, gray.Height]; 
            sumimage2 = new int[gray.Width , gray.Height ];
            output = new int[gray.Width, gray.Height];
            
            graynya = new int[gray.Width+1, gray.Height+1];
            sumimage = new int[gray.Width+1, gray.Height+1];
            thesum = new int[gray.Width + 1, gray.Height + 1];
            mean = new int[gray.Width + 1, gray.Height + 1];
            thresholdnya = new int[gray.Width + 1, gray.Height + 1]; 
            for (int x = 0; x < gray.Width; x++)
                for (int y = 0; y < gray.Height; y++)
                {
                    Color w = gray.GetPixel(x, y);
                    int a = w.A;
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int avg = ((r + g + b) / 3);
                    graynya[x+1,y+1]=avg;
                    sumimage[x+1, y+1] = avg;
                    gray2[x, y] = avg;
                    //sumimage2[x, y] = avg;
                    gray.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            pictureBox1.Image = gray;
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           // sumim = new Bitmap(gray);
            for (int x = 1; x <= gray.Width; x++)
                for (int y = 1; y <= gray.Height; y++)
                {
                    sumimage[x, y] = graynya[x, y] + sumimage[x, y - 1] + sumimage[x - 1, y] - sumimage[x - 1, y-1];
                  //  int hasil = gray.GetPixel(x, y).R + sumim.GetPixel(x, y - 1).R + sumim.GetPixel(x - 1, y).R - sumim.GetPixel(x - 1, y - 1).R;
                  //  sumim.SetPixel(x, y, Color.FromArgb(hasil, hasil, hasil));
                }
            label1.Text = "" + sumimage[1, 1] + " " + sumimage[1, 2] + " " + sumimage[1, 3];
            label2.Text = "" + sumimage[2, 1] + " " + sumimage[2, 2] + " " + sumimage[2, 3];
           // pictureBox2.Image = sumim;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int hasil1, hasil2, hasil3, hasil4;
            int d = Convert.ToInt32(Math.Round(23.0/ 2.0));
            label3.Text = "" + d;
            for (int x = 1; x <= gray.Width; x++)
                for (int y = 1; y <= gray.Height; y++)
                {
                    
                    try
                    {
                         hasil1 = sumimage[x + d - 1, y + d - 1];
                    }
                    catch (IndexOutOfRangeException) {
                        hasil1 = 255;
                    }
                     try
                    {
                     hasil2 = sumimage[x - d, y - d];}
                     catch (IndexOutOfRangeException) {
                        hasil2 = 255;
                    }
                     try
                    {
                     hasil3 = sumimage[x - d, y + d - 1];}
                       catch (IndexOutOfRangeException) {
                        hasil3 = 255;
                    }
                     try
                     {
                         hasil4 = sumimage[x + d - 1, y - d];
                     }
                     catch (IndexOutOfRangeException)
                     {
                         hasil4 = 255;
                     }

                    thesum[x, y] = (hasil1 + hasil2) - (hasil3 +hasil4);
                    //  int hasil = gray.GetPixel(x, y).R + sumim.GetPixel(x, y - 1).R + sumim.GetPixel(x - 1, y).R - sumim.GetPixel(x - 1, y - 1).R;
                    //  sumim.SetPixel(x, y, Color.FromArgb(hasil, hasil, hasil));
                    label1.Text = "" + thesum[gray.Width-1, 1] + " " + thesum[gray.Width-1, 2] + " " + thesum[gray.Width-1, 3];
                    label2.Text = "" + thesum[gray.Width, 1] + " " + thesum[gray.Width, 2] + " " + thesum[gray.Width, 3];
                    label4.Text = "" + sumimage[gray.Width, 1] + " " + sumimage[gray.Width, 2] + " " + sumimage[gray.Width, 3];
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
           
            for (int x = 1; x <= gray.Width; x++)
                for (int y = 1; y <= gray.Height; y++)
                {

                    mean[x, y] = thesum[x,y]/(23*23);
                    
                }

            label1.Text = "" + mean[gray.Width, 1] + " " + mean[gray.Width, 2] + " " + mean[gray.Width, 3];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float k = 1;
            
            for (int x = 1; x <= gray.Width; x++)
                for (int y = 1; y <= gray.Height; y++)
                {

                    thresholdnya[x, y] =(int) ( mean[x, y] * (1 + k * (((graynya[x, y] - mean[x, y]) / (1 - graynya[x, y] - mean[x, y]))-1)) );

                }



            label1.Text = "" + thresholdnya[gray.Width, 1] + " " + thresholdnya[gray.Width, 2] + " " + thresholdnya[gray.Width, 3];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hasilakhir = new Bitmap(gray);
            for (int x = 0; x < gray.Width; x++)
                for (int y = 0; y < gray.Height; y++)
                {
                    if (gray.GetPixel(x, y).R < thresholdnya[x + 1, y + 1])
                    {
                        hasilakhir.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else {
                        hasilakhir.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                   
                }
            pictureBox2.Image = hasilakhir;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int sum ;
            for (int x = 0; x < gray.Width; x++)
            {
                sum = 0;
                for (int y = 0; y < gray.Height; y++)
                {
                    sum = sum + gray2[x, y];
                    if (x == 0)
                    {
                        sumimage2[x, y] = sum;
                    }
                    else {

                        sumimage2[x, y] =sumimage2[x-1, y]+ sum;
                    }
                   
                }
            }

            label1.Text = "" + sumimage2[0, 0] + " " + sumimage2[0, 1] + " " + sumimage2[0, 2];
            label2.Text = "" + sumimage2[1, 0] + " " + sumimage2[1, 1] + " " + sumimage2[1, 2];
        }

        int s = 35, t = 28;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x1, x2, y1, y2,count;
            int sum;
             // ini aku ganti, aslinya 7,35
            for (int x = s / 2 + 1; x < gray.Width - s / 2; x++) //4,3
            {

                for (int y = s / 2 + 1; y < gray.Height - s / 2; y++) //4,3
                {
                    x1 = x - s / 2;
                    x2 = x + s / 2;
                    y1 = y - s / 2;
                    y2 = y + s / 2;
                    count = (x2 - x1) * (y2 - y1);
                    sum = sumimage2[x2, y2] - sumimage2[x2, y1 - 1] - sumimage2[x1 - 1, y2] + sumimage2[x1 - 1, y1 - 1];
                    if (gray2[x, y] * count <= (sum * (100 - t) / 100))
                    {
                        output[x, y] = 0;
                    }
                    else {
                        output[x, y] = 255;
                    }

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < gray.Width; x++)
                for (int y = 0; y < gray.Height; y++)
                {
                    if (x < s / 2 + 1 || x > (gray.Width - s / 2 - 1) || y < s / 2 + 1 || y > (gray.Height - s / 2 - 1))
                    {
                        gray.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else {
                        gray.SetPixel(x, y, Color.FromArgb(output[x, y], output[x, y], output[x, y]));
                    }
                    
                }
            pictureBox2.Image = gray;
            File = gray;
        }
        Image File;
        private void button11_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "JPG images (*.jpg)|*.jpg";
            DialogResult d = saveFileDialog1.ShowDialog();

            if (d == DialogResult.OK) { File.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i, j;
            int[] hx1 = new int[gray.Width];
            for (j = 0; j < gray.Width - 1; j++)
            {
                hx1[j] = 0;
                for (i = 0; i < gray.Height - 1; i++)
                {
                    Color w = gray.GetPixel(j, i);
                    hx1[j] += Convert.ToInt32((255 - w.R) / 255);


                }

            }

            int[] hy1 = new int[gray.Height];
            for (j = 0; j < gray.Height - 1; j++)
            {
                hy1[j] = 0;
                for (i = 0; i < gray.Width - 1; i++)
                {
                    Color w = gray.GetPixel(i, j);
                    hy1[j] += Convert.ToInt32((255 - w.R) / 255);


                }

            }

            int kiriatasx = 0, kiriatasy = 0, kananbawahx = 0, kananbawahy = 0;
            for (j = 0; j < hy1.Length; j++)
            {
                if (hy1[j] > 20)
                {
                    kiriatasy = j-15;
                    break;
                }
            }
            for (j = hy1.Length - 1; j >= 0; j--)
            {
                if (hy1[j] > 20)
                {
                    kananbawahy = j+15;
                    break;
                }
            }

            for (j = 0; j < hx1.Length; j++)
            {
                if (hx1[j] > 20)
                {
                    kiriatasx = j-20;
                    break;
                }
            }
            for (j = hx1.Length - 1; j >= 0; j--)
            {
                if (hx1[j] > 0)
                {
                    kananbawahx = j;
                    break;
                }
            }


            label1.Text = kiriatasx + " " + kiriatasy + " " + kananbawahx + " " + kananbawahy;
            objBitmapcrop = new Bitmap(Math.Abs(kananbawahx - kiriatasx), Math.Abs(kiriatasy - kananbawahy));
            Graphics grp = Graphics.FromImage(objBitmapcrop);
            grp.DrawImage(gray, new Rectangle(0, 0, objBitmapcrop.Width, objBitmapcrop.Height), new Rectangle(kiriatasx, kiriatasy, objBitmapcrop.Width , objBitmapcrop.Height ), GraphicsUnit.Pixel);
            pictureBox1.Image = objBitmapcrop;
            /*for (i = 0; i < hx1.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, hx1[i]);


            }*/
            File = objBitmapcrop;
            pictureBox1.Image = objBitmapcrop;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i <= objBitmapcrop.Width - 1; i++)
            {
                for (j = 0; j <= objBitmapcrop.Height - 1; j++)
                {
                    Color pixelColor = objBitmapcrop.GetPixel(i, j);
                    int nRed = pixelColor.R;
                    int nGreen = pixelColor.G;
                    int nBlue = pixelColor.B;
                    int rata = Convert.ToInt32((nRed + nBlue + nGreen) / 3);
                    if (rata < 128)
                        rata = 0;
                    else
                        rata = 255;
                    Color newpixelColor = Color.FromArgb(rata, rata, rata);
                    objBitmapcrop.SetPixel(i, j, newpixelColor);
                }
            }
            pictureBox2.Image = objBitmapcrop;


            int pembagilebar;
            String jarakbaris="lebar";
            if (jarakbaris.Equals("sempit"))
            {
                pembagilebar = 30;
            }
            else {
                pembagilebar = 17;
            }
            int pembagitinggi = 4;

            Bitmap[] isibagiangambar = new Bitmap[pembagilebar];
            int[,] titiknya = new int[pembagilebar, 5];
            int penambahx = 0, penambahx2 = 0;
            for (int d = 0; d < pembagilebar; d++)
            {

                isibagiangambar[d] = new Bitmap((int)(objBitmapcrop.Width / pembagilebar), (int)(objBitmapcrop.Height / pembagitinggi));
                Graphics grp = Graphics.FromImage(isibagiangambar[d]);
                penambahx = penambahx + (int)(objBitmapcrop.Width / pembagilebar);
                grp.DrawImage(objBitmapcrop, new Rectangle(0, 0, isibagiangambar[d].Width, isibagiangambar[d].Height), new Rectangle((0 + penambahx2), 0, (int)(objBitmapcrop.Width / pembagilebar), (int)(objBitmapcrop.Height / pembagitinggi)), GraphicsUnit.Pixel); //kiri destinasi rectangle, kanan source

                penambahx2 = penambahx + 1;


            }
            pictureBox2.Image = isibagiangambar[2];
            //croping

            for (int z = 0; z < pembagilebar; z++)
            {

                int[] hy1 = new int[isibagiangambar[z].Height];
                for (j = 0; j < isibagiangambar[z].Height; j++)
                {
                    hy1[j] = 0;
                    for (i = 0; i < isibagiangambar[z].Width - 1; i++)
                    {
                        Color w = isibagiangambar[z].GetPixel(i, j);

                        hy1[j] += Convert.ToInt32((255 - w.R) / 255);
                    }
                }



                //
                int iter = 0;
                for (i = 0; i < hy1.Length - 1; i++)
                {
                    if ((hy1[i] > 0) && (hy1[i + 1] == 0))
                    {
                        titiknya[z, iter] = i + 3;
                        iter++;
                        if (iter == 4)
                        {
                            break;
                        }
                    }


                }
                //

            }

          /*  for (i = 0; i < pembagilebar; i++)
            {
                Console.WriteLine(titiknya[i, 0]);
            }*/

            int kiri = 0, kanan = 0, kiri2, kanan2, selisihtitikdenganpucuk, selisihdengantitikberikutnya, flag = 0;

            using (Graphics g = Graphics.FromImage(objBitmapcrop))
            {
                int penambah = (int)(objBitmapcrop.Width / pembagilebar);
                for (i = 0; i < pembagilebar; i++)
                {
                    if (i != pembagilebar - 1)
                    {
                        if (i < pembagilebar / 3) //ini aku ganti
                        {
                            selisihtitikdenganpucuk = Math.Abs(titiknya[i, 0] - titiknya[0, 0]);
                        }
                        else
                        {
                            selisihtitikdenganpucuk = Math.Abs(titiknya[i, 0] - titiknya[pembagilebar / 2, 0]);
                        }

                        selisihdengantitikberikutnya = titiknya[i, 0] - titiknya[i + 1, 0];
                        kanan = kanan + penambah;


                        if (flag == 0)
                        {
                            if (!(selisihtitikdenganpucuk > 20)) //22
                            {
                                // g.DrawLine(new Pen(Color.Green), new Point(kiri, titiknya[i, 0]), new Point(kanan, titiknya[i, 0]));
                                g.DrawLine(new Pen(Color.FromArgb(255, 0, 0)), new Point(kiri, titiknya[i, 0]), new Point(kanan, titiknya[i, 0]));

                            }
                            else
                            {

                                //g.DrawLine(new Pen(Color.Blue), new Point(kiri, titiknya[i - 1, 0]), new Point(kanan, titiknya[i - 1, 0]));
                                g.DrawLine(new Pen(Color.FromArgb(255, 0, 0)), new Point(kiri, titiknya[i - 1, 0]), new Point(kanan, titiknya[i - 1, 0]));
                                titiknya[i, 0] = titiknya[i - 1, 0];
                            }
                        }
                        else
                        {
                            flag = 0;
                        }

                        kiri2 = kanan + 1;
                        kanan2 = kanan + penambah;


                        if (selisihdengantitikberikutnya > 22 && !(selisihtitikdenganpucuk > 20)) //22
                        {
                            g.DrawLine(new Pen(Color.FromArgb(255, 0, 0)), new Point(kiri2, titiknya[i, 0]), new Point(kanan2, titiknya[i, 0]));
                            titiknya[i + 1, 0] = titiknya[i, 0];

                            flag = 1;
                        }

                        kiri = kanan + 1;
                    }
                } g.DrawLine(new Pen(Color.Red), new Point(kiri, titiknya[pembagilebar - 2, 0]), new Point(objBitmapcrop.Width, titiknya[pembagilebar - 2, 0]));

            }


            pictureBox1.Image = objBitmapcrop;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int flag;
            for (int x = 0; x < objBitmapcrop.Width; x++)
            {
                flag = 0;
                for (int y = 0; y < objBitmapcrop.Height; y++)
                {

                    Color w = objBitmapcrop.GetPixel(x, y);
                    int a = w.A;
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int avg = ((r + g + b) / 3);
                    if (avg != 0 && avg != 255)
                    {
                        flag = 1;
                    }
                    //  Console.WriteLine(avg);

                    if (flag == 1)
                        objBitmapcrop.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            }
            pictureBox1.Image = objBitmapcrop;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap objBitmap2 = new Bitmap(gray);
          
            int i, j;

          
            int[] hx1 = new int[objBitmap2.Width];

            for (j = 0; j < objBitmap2.Width - 1; j++)
            {
                hx1[j] = 0;
                for (i = 0; i < objBitmap2.Height - 1; i++)
                {
                    Color w = objBitmap2.GetPixel(j, i);
                    hx1[j] += Convert.ToInt32((255 - w.R) / 255);
                

                }
                
            }

             for (i = 0; i < hx1.Length; i++)
             {
                 chart1.Series["Series1"].Points.AddXY(i, hx1[i]);


             }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap objBitmap2 = new Bitmap(gray);
           
            int i, j;

           

            int[] hy1 = new int[objBitmap2.Height];
            for (j = 0; j < objBitmap2.Height - 1; j++)
            {
                hy1[j] = 0;
                for (i = 0; i < objBitmap2.Width - 1; i++)
                {
                    Color w = objBitmap2.GetPixel(i, j);
                    hy1[j] += Convert.ToInt32((255 - w.R) / 255);
                  

                }
                
            }

            for (i = 0; i < hy1.Length; i++)
            {
              //  chart1.Series["Series1"].Points.AddXY(i, hy1[i]);


            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
