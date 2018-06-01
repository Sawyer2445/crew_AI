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


namespace Crew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen pen;
        Bitmap bmp1, bmp2, bmp3, bmp4;
        int sec1, sec2, sec3, sec4;
        Web NW1, NW2, NW3;
        /// <summary>
        /// Секунд перед очситкой
        /// </summary>
        int delTime;

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics gr = Graphics.FromImage(bmp4))
                {
                    gr.DrawEllipse(pen, e.X, e.Y, 11, 11);
                }
                pictureBox4.Image = bmp4;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            --sec1;
            if (sec1 < 0)
            {
                timer1.Stop();
                clearBMP(ref bmp1);
                label1.Text = "";
                pictureBox1.Image = bmp1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            --sec2;
            if (sec2 < 0)
            {
                timer2.Stop();
                clearBMP(ref bmp2);
                label2.Text = "";
                pictureBox2.Image = bmp2;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            --sec3;
            if (sec3 < 0)
            {
                timer3.Stop();
                clearBMP(ref bmp3);
                label3.Text = "";
                pictureBox3.Image = bmp3;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            --sec4;
            if (sec4 < 0)
            {
                timer4.Stop();
                clearBMP(ref bmp4);
                pictureBox4.Image = bmp4;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] inp = new int[pictureBox1.Width, pictureBox1.Height];
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    int n = (bmp1.GetPixel(x, y).R);
                    if (n >= 250)
                        n = 0;
                    else
                        n = 1;
                    inp[x, y] = n;
                }
            }
            NW1.input = inp;

            //Распознавание
            NW1.mul_w();
            NW1.Sum();
            if (NW1.Rez())
            {
                label1.Text = "ДА";
                label1.Visible = true;
            }
            else
            {
                label1.Text = "НЕТ";
                label1.Visible = true;
            }
            sec1 = delTime;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sec2 = delTime;
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!NW1.Rez())
            {
                NW1.incW();
            }
            else
                NW1.decW();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NW1.saveWeight("w1.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sec3 = delTime;
            timer3.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sec4 = delTime;
            timer4.Start();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics gr = Graphics.FromImage(bmp1))
                {
                    gr.DrawEllipse(pen, e.X, e.Y, 11, 11);
                }
                pictureBox1.Image = bmp1;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics gr = Graphics.FromImage(bmp2))
                {
                    gr.DrawEllipse(pen, e.X, e.Y, 11, 11);
                }
                pictureBox2.Image = bmp2;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics gr = Graphics.FromImage(bmp3))
                {
                    gr.DrawEllipse(pen, e.X, e.Y, 11, 11);
                }
                pictureBox3.Image = bmp3;
            }
        }

        int width, height;

        private void Form1_Load(object sender, EventArgs e)
        {
            delTime = 2;
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pen = new Pen(new SolidBrush(Color.Black), 11);

            bmp1 = new Bitmap(width, height);
            bmp2 = new Bitmap(width, height);
            bmp3 = new Bitmap(width, height);
            bmp4 = new Bitmap(width, height);

            clearBMP(ref bmp1);
            clearBMP(ref bmp2);
            clearBMP(ref bmp3);
            clearBMP(ref bmp4);

            pictureBox1.Image = bmp1;
            pictureBox2.Image = bmp2;
            pictureBox3.Image = bmp3;
            pictureBox4.Image = bmp4;
            NW1 = new Web(width, height, "w1.txt");
            


        }
        private void clearBMP(ref Bitmap bmp)
        {
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.White);
                }
            }
        }

       

    }
}
