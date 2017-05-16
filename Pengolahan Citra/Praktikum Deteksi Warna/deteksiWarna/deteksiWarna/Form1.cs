using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deteksiWarna
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap;
        Bitmap objBitmap1;
        Bitmap objBitmap2;

        int red, green, blue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objBitmap1 = new Bitmap(objBitmap);

            for(int x=0; x<objBitmap.Width; x++)
            {
                for(int y=0; y < objBitmap1.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;

                    //if (((r > 188) && (r < 239)) && ((g > 139) && (g < 211)) && ((b > 106) && (b < 200)))
                    //if (((r > 213) && (r < 239)) && ((g > 45) && (g < 118)) && ((b > 28) && (b < 87)))
                    if (((r >= 162) && (r <= 194)) && ((g >= 125) && (g <= 176)) && ((b >= 117) && (b <= 164)))
                    {
                        continue;
                    }
                    else
                    {
                        r = 0; g = 0; b = 0;
                    }

                    Color wb = Color.FromArgb(r, g, b);
                    
                    objBitmap1.SetPixel(x, y, wb);
                }
                pictureBox2.Image = objBitmap1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int r = 162, g = 125, b = 117;
            int r = 194, g = 176, b = 164;
            double d;
            objBitmap2 = new Bitmap(objBitmap);
            for(int x=0; x < objBitmap.Width; x++)
            {
                for(int y=0; y< objBitmap2.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    int red = w.R;
                    int green = w.G;
                    int blue = w.B;

                    d = Math.Abs(red - r) + Math.Abs(green - g) + Math.Abs(blue - b);
                    if (d < 85)
                    {
                        continue;
                    } else
                    {
                        red = 0; green = 0; blue = 0;
                    }

                    Color wb = Color.FromArgb(red, green, blue);

                    objBitmap2.SetPixel(x, y, wb);
                }
                pictureBox3.Image = objBitmap2;
            }
        }
    }
}
