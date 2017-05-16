using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitraHistogramRGB
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBoxInput.Image = objBitmap;
            }

            histogramRed.Series["Series1"].Points.Clear();
            histogramGreen.Series["Series1"].Points.Clear();
            histogramBlue.Series["Series1"].Points.Clear();
        }

        private void btnHR_Click(object sender, EventArgs e)
        {
            float[] h = new float[256];
            int i;
            for (i = 0; i < 256; i++) h[i] = 0;
            for(int x = 0; x < objBitmap.Width; x++)
                for(int y = 0; y<objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = w.R;
                    h[xg] = h[xg] + 1;
                }
            float hmax = h[0];
            for (i = 0; i < 256; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 256; i++)
                h[i] = 120 * h[i] / hmax;

            for(i = 0; i < 256; i++)
            {
                histogramRed.Series["Series1"].Points.AddXY(i, h[i]);
            }

            histogramRed.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            histogramRed.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void btnHG_Click(object sender, EventArgs e)
        {
            float[] h = new float[256];
            int i;
            for (i = 0; i < 256; i++) h[i] = 0;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = w.G;
                    h[xg] = h[xg] + 1;
                }
            float hmax = h[0];
            for (i = 0; i < 256; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 256; i++)
                h[i] = 120 * h[i] / hmax;

            for (i = 0; i < 256; i++)
            {
                histogramGreen.Series["Series1"].Points.AddXY(i, h[i]);
            }
            histogramGreen.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            histogramGreen.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void btnHB_Click(object sender, EventArgs e)
        {
            float[] h = new float[256];
            int i;
            for (i = 0; i < 256; i++) h[i] = 0;
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int xg = w.B;
                    h[xg] = h[xg] + 1;
                }
            float hmax = h[0];
            for (i = 0; i < 256; i++)
            {
                if (h[i] > hmax)
                    hmax = h[i];
            }
            for (i = 0; i < 256; i++)
                h[i] = 120 * h[i] / hmax;

            for (i = 0; i < 256; i++)
            {
                histogramBlue.Series["Series1"].Points.AddXY(i, h[i]);
            }

            histogramBlue.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            histogramBlue.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }
    }
}
