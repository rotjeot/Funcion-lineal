using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
////////////////////////////////////////////
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace LINEAL
{
    public partial class Form1 : Form
    {
       static  Image<Bgr, Byte> img;
       //static double valorFuncion; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar_foto();
            pictureBox1.Image = img.ToBitmap();
            Image<Gray, Byte> grayImage = img.Convert<Gray, Byte>();
            pictureBox2.Image = grayImage.ToBitmap();

        }
        private void Buscar_foto()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string ruta;

            try
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog1.FileName;
                    img = new Image<Bgr, Byte>(ruta);
                    Console.WriteLine(ruta);
                }
            }
            catch
            {
            

            }
            

        }

        private void draw()
        {
            Byte x;
            double y;
            
            Image<Gray, Byte> grayImage = img.Convert<Gray, Byte>();
            for (int i = 0; i < img.Width - 1; i++)
            {
                for (int j = 0; j < img.Height -1; j++)
                {
                    y = trackBar1.Value * (3.1415 / 180) * grayImage.Data[j, i, 0];
                    if (y >= 255)
                    {
                        grayImage.Data[j, i, 0] = 255;
                    }

                    else
                    {
                        x = Convert.ToByte(y);
                        grayImage.Data[j, i, 0] = x;
                    }
                }
            }
            pictureBox1.Image = grayImage.ToBitmap();
        }
 

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString() + "°";
            draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
