using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string cap()
        {

            char[] Possibilities = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_~ ".ToCharArray();
                Random Randomizer = new Random();
                string Captcha= "";
                int length=Randomizer.Next(4,8);
                Captcha += Possibilities[Randomizer.Next(0, Possibilities.Length-1)];
                while (length > 2)
                {
                    Captcha += Possibilities[Randomizer.Next(0,Possibilities.Length)];
                    length--;
                }
                Captcha += Possibilities[Randomizer.Next(0, Possibilities.Length - 1)];//so that space do not come in start and end and is visible
                return Captcha;
        }

        public Bitmap GenerateImage()
        {
            int Width=250;
            int Height=90;
            string Phrase = cap();
            Bitmap CaptchaImg = new Bitmap(Width, Height);
            Random Randomizer = new Random();
            Graphics Graphic = Graphics.FromImage(CaptchaImg);
            Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            Graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

            Graphic.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0, Width, Height);
            //    SolidBrush(Color.FromArgb(Randomizer.Next(0, 100),
            //Randomizer.Next(0, 100), Randomizer.Next(0, 100))),
            //0, 0, Width, Height);

            Graphic.RotateTransform(Randomizer.Next(-15, 15));
            string[] font = { "Jokerman", "Lucida Calligraphy", "Comic Sans MS", "Segoe Script", "Verdana" };
            Graphic.DrawString(Phrase, new Font(font[Randomizer.Next(0,font.Length)], 20), new SolidBrush(Color.FromArgb(Randomizer.Next(150, 255), Randomizer.Next(150, 255), Randomizer.Next(150, 255))), 5, 15);

            Graphic.Flush();

            return CaptchaImg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = cap();
            pictureBox1.Image = GenerateImage();

        }



    }
}
