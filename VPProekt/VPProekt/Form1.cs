using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProekt
{
    public partial class Form1 : Form
    {
        Image slotImage;
        public Form1()
        {
            InitializeComponent();
            slotImage = VPProekt.Properties.Resources.Penny_Slot_Machines_1;
            label1.BackColor = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            this.BackgroundImage = ResizeImg(slotImage, this.Width, this.Height);
            button1.BackgroundImage = ResizeImg(VPProekt.Properties.Resources.game1img,button1.Width,button1.Height);
            button2.BackgroundImage = ResizeImg(VPProekt.Properties.Resources.game2img, button2.Width, button2.Height);
            CenterToScreen();
        }
        public static Image ResizeImg(Image image, int width,int height)
        {
            Size newSize = new Size();
            newSize.Height = height;
            newSize.Width = width;
            Image newImage = new Bitmap(width, height);
            using(Graphics g = Graphics.FromImage((Bitmap)newImage))
            {
                g.DrawImage(image, new Rectangle(Point.Empty, newSize));
            }
            return newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game1 g = new Game1();
            g.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game2 g = new Game2();
            g.ShowDialog();
        }


    }
}
