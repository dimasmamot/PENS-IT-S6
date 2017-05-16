using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histogram_Warna_Kombinasi
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        Bitmap objBitmap3;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                objBitmap1 = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap1;
            }

            chart1.Series["Series1"].Points.Clear();
        }

        private void buttonLoad2_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap2 = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = objBitmap2;
            }

            chart2.Series["Series1"].Points.Clear();
        }

        private void buttonLoad3_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap3 = new Bitmap(openFileDialog1.FileName);
                pictureBox3.Image = objBitmap3;
            }

            chart3.Series["Series1"].Points.Clear();
        }

        private void buttonHistogram1_Click(object sender, EventArgs e)
        {
            float[] h = new float[384];
            int i;

            for (i = 0; i < 384; i++)
            {
                h[i] = 0;
            }

            for(int x = 0;x <objBitmap1.Width; x++)
            {
                for(int y = 0; y < objBitmap1.Height; y++)
                {
                    Color w = objBitmap1.GetPixel(x, y);
                    int xr = w.R; int xg = w.G; int xb = w.B;
                    xr = xr / 2; xg = xg / 2; xb = xb / 2;
                    h[xr]++;
                    h[128 + xg]++;
                    h[256 + xb]++;
                }
            }
            float hmax = h[0];
            for(i = 1; i< 384; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 384; i++)
                h[i] = 120 * h[i] / hmax;

            for(i = 0; i<384; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void buttonHistogram2_Click(object sender, EventArgs e)
        {
            float[] h = new float[384];
            int i;

            for (i = 0; i < 384; i++)
            {
                h[i] = 0;
            }

            for (int x = 0; x < objBitmap2.Width; x++)
            {
                for (int y = 0; y < objBitmap2.Height; y++)
                {
                    Color w = objBitmap2.GetPixel(x, y);
                    int xr = w.R; int xg = w.G; int xb = w.B;
                    xr = xr / 2; xg = xg / 2; xb = xb / 2;
                    h[xr]++;
                    h[128 + xg]++;
                    h[256 + xb]++;
                }
            }
            float hmax = h[0];
            for (i = 1; i < 384; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 384; i++)
                h[i] = 120 * h[i] / hmax;

            for (i = 0; i < 384; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, h[i]);
            }
            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void buttonHistogram3_Click(object sender, EventArgs e)
        {
            float[] h = new float[384];
            int i;

            for (i = 0; i < 384; i++)
            {
                h[i] = 0;
            }

            for (int x = 0; x < objBitmap3.Width; x++)
            {
                for (int y = 0; y < objBitmap3.Height; y++)
                {
                    Color w = objBitmap3.GetPixel(x, y);
                    int xr = w.R; int xg = w.G; int xb = w.B;
                    xr = xr / 2; xg = xg / 2; xb = xb / 2;
                    h[xr]++;
                    h[128 + xg]++;
                    h[256 + xb]++;
                }
            }
            float hmax = h[0];
            for (i = 1; i < 384; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 384; i++)
                h[i] = 120 * h[i] / hmax;

            for (i = 0; i < 384; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, h[i]);
            }

            chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }
    }
}
