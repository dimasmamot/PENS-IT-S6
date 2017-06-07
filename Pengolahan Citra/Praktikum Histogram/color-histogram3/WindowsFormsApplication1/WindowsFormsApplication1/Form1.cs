using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        Bitmap objBitmap3;
        Bitmap objBitmap4;
        float[,] h = new float[4, 768];
        float[,] hi = new float[4,768];
        float[] gn = new float[768];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                objBitmap1 = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap1;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                objBitmap2 = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = objBitmap2;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                objBitmap3 = new Bitmap(openFileDialog1.FileName);
                pictureBox3.Image = objBitmap3;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (objBitmap1 == null)
            {
                textBox2.Text = "Masukkan gambar dahulu";
            }
            else {
                objBitmap = new Bitmap(objBitmap1);
                for (int i = 0; i < objBitmap.Width; i++)
                {
                    for (int j = 0; j < objBitmap.Height; j++)
                    {
                        Color pixel = objBitmap.GetPixel(i, j);
                        int red = pixel.R;
                        int green = pixel.G;
                        int blue = pixel.B;

                        h[0, red]++;
                        h[0, 256 + green]++;
                        h[0, 512 + blue]++;
                    }
                }
                float hmax = h[0, 0];
                for (int i = 1; i < 768; i++)
                {
                    if (h[0, i] > hmax)
                        hmax = h[0, i];
                }
                for (int i = 0; i < 768; i++)
                    h[0, i] = 120 * h[0, i] / hmax;

                //histogram
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                for (int i = 0; i < 768; i++)
                {
                    chart1.Series["Series1"].Points.AddXY(i, h[0, i]);
                }
            }   
                       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (objBitmap2 == null)
            {
                textBox3.Text = "Masukkan gambar dahulu";
            }
            else {
                objBitmap = new Bitmap(objBitmap2);
                for (int i = 0; i < objBitmap.Width; i++)
                {
                    for (int j = 0; j < objBitmap.Height; j++)
                    {
                        Color pixel = objBitmap.GetPixel(i, j);
                        int red = pixel.R;
                        int green = pixel.G;
                        int blue = pixel.B;

                        h[1, red]++;
                        h[1, 256 + green]++;
                        h[1, 512 + blue]++;
                    }
                }
                float hmax = h[1, 0];
                for (int i = 1; i < 768; i++)
                {
                    if (h[1, i] > hmax)
                        hmax = h[1, i];
                }
                for (int i = 0; i < 768; i++)
                    h[1, i] = 120 * h[1, i] / hmax;

                //histogram
                chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                for (int i = 0; i < 768; i++)
                {
                    chart2.Series["Series1"].Points.AddXY(i, h[1, i]);
                }
            }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (objBitmap3 == null)
            {
                textBox4.Text = "Masukkan gambar dahulu";
            }
            else {
                objBitmap = new Bitmap(objBitmap3);
                for (int i = 0; i < objBitmap.Width; i++)
                {
                    for (int j = 0; j < objBitmap.Height; j++)
                    {
                        Color pixel = objBitmap.GetPixel(i, j);
                        int red = pixel.R;
                        int green = pixel.G;
                        int blue = pixel.B;

                        h[2, red]++;
                        h[2, 256 + green]++;
                        h[2, 512 + blue]++;
                    }
                }
                float hmax = h[2, 0];
                for (int i = 1; i < 768; i++)
                {
                    if (h[2, i] > hmax)
                        hmax = h[2, i];
                }
                for (int i = 0; i < 768; i++)
                    h[2, i] = 120 * h[2, i] / hmax;

                //histogram
                chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                for (int i = 0; i < 768; i++)
                {
                    chart3.Series["Series1"].Points.AddXY(i, h[2, i]);
                }
            }
            

        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 768; i++) {
                gn[i] = h[0,i];
                if (h[1,i] < gn[i]) gn[i] = h[1,i];
                if (h[2,i] < gn[i]) gn[i] = h[2,i];
            }
            chart4.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart4.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            for (int i = 0; i < 768; i++)
            {
                chart4.Series["Series1"].Points.AddXY(i, gn[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i=0;i<768;i++)
                hi[0, i] = Math.Abs((h[0, i] - gn[i]));

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            foreach (var series in chart1.Series)
            { series.Points.Clear(); }

            for (int i = 0; i < 768; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, hi[0,i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 768; i++)
                hi[1,i] = (h[1,i] - gn[i]);

            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            foreach (var series in chart2.Series)
            { series.Points.Clear(); }

            for (int i = 0; i < 768; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, hi[1, i]);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 768; i++)
                hi[2,i] = Math.Abs(h[2,i] - gn[i]);

            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            foreach (var series in chart3.Series)
            { series.Points.Clear(); }

            for (int i = 0; i < 768; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, hi[2, i]);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                objBitmap4 = new Bitmap(openFileDialog1.FileName);
                pictureBox4.Image = objBitmap4;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(objBitmap4);
            for (int i = 0; i < objBitmap.Width; i++)
            {
                for (int j = 0; j < objBitmap.Height; j++)
                {
                    Color pixel = objBitmap2.GetPixel(i, j);
                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    h[3,red]++;
                    h[3, 256 + green]++;
                    h[3, 512 + blue]++;
                }
            }
            float hmax = h[3, 0];
            for (int i = 1; i < 768; i++)
            {
                if (h[3, i] > hmax)
                    hmax = h[3, i];
            }
            for (int i = 0; i < 768; i++)
                h[3, i] = 120 * h[3, i] / hmax;

            //histogram
            chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            for (int i = 0; i < 768; i++)
            {
                chart5.Series["Series1"].Points.AddXY(i, h[3, i]);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 768; i++)
                hi[3,i] = Math.Abs(h[3,i] - gn[i]);

            chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            foreach (var series in chart5.Series)
            { series.Points.Clear(); }

            for (int i = 0; i < 768; i++)
            {
                chart5.Series["Series1"].Points.AddXY(i, hi[3,i]);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            objBitmap2 = new Bitmap(objBitmap);
            float[] d = new float[3];
            float di = 0;
            int i, j, k = 0;
            long w = 0;
            char[] str = new char[5];
            char[] str2 = new char[5];

            for (i = 0; i < 3; i++) {
                d[i] = 0;
                for(j=0;j<768;j++)
                    di=di+Math.Abs ((hi[3,j]-hi[i,j]));
                di=di/768;
                d[i] = di;
                textBox1.AppendText(i.ToString() + " - " + d[i].ToString() + "\n");
                
            }
            if(d[0]<d[1]&&d[0]<d[2]){
                k=0;
                textBox1.AppendText("\n Hijau");
            }
            if(d[1]<d[0]&&d[1]<d[2]){
                k=1;
                textBox1.AppendText( "\nMerah");
            }
            if(d[2]<d[0]&&d[2]<d[1]){
                k=2;
                textBox1.AppendText("\nCampuran");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            for (int j = 0; j < 768; j++)
            {
                h[0, j] = 0;
                hi[0, j] = 0;
                gn[j] = 0;
            }
            objBitmap1 = null; 
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            for (int j = 0; j < 768; j++)
            {
                h[1, j] = 0;
                hi[1, j] = 0;
                gn[j] = 0;
            }
            objBitmap2 = null; 
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            for (int j = 0; j < 768; j++)
            {
                h[2, j] = 0;
                hi[2, j] = 0;
                gn[j] = 0;
            }
            objBitmap3 = null; 
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = null;
            foreach (var series in chart5.Series)
            {
                series.Points.Clear();
            }
            for (int j = 0; j < 768; j++)
            {
                h[3, j] = 0;
                hi[3, j] = 0;
            }
            objBitmap4 = null;
            textBox1.Text = null;
        }
    }
}
