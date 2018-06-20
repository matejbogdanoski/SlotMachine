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
    public partial class Game1 : Form
    {
        public int Bet { get; set; }
        public LuckyHot luckyHot { get; set; }
        public bool time { get; set; }
        Timer timer;
        int elapsed;

        public Game1()
        {
            InitializeComponent();
            this.Height = 600;
            this.Width = 570;
            this.BackgroundImage = Form1.ResizeImg(VPProekt.Properties.Resources.game1bg,this.Width,this.Height);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Yellow;
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Yellow;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.Yellow;
            button3.FlatAppearance.BorderSize = 1;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            CenterToScreen();
             luckyHot = new LuckyHot(500,5);
            timer = new Timer();
            timer.Interval = 130;
            timer.Tick += new EventHandler(timer_Tick);
            this.Bet = 5;
            time = true;
            elapsed = 0;
            this.DoubleBuffered = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (elapsed == 10)
            {
                timer.Stop();
                int[] niza = luckyHot.Stop();
                if (niza[9] > 0)
                {
                    if (niza[0] == 1) luckyHot.Mat[0][0] += 6;
                    if (niza[1] == 1) luckyHot.Mat[0][1] += 6;
                    if (niza[2] == 1) luckyHot.Mat[0][2] += 6;
                    if (niza[3] == 1) luckyHot.Mat[1][0] += 6;
                    if (niza[4] == 1) luckyHot.Mat[1][1] += 6;
                    if (niza[5] == 1) luckyHot.Mat[1][2] += 6;
                    if (niza[6] == 1) luckyHot.Mat[2][0] += 6;
                    if (niza[7] == 1) luckyHot.Mat[2][1] += 6;
                    if (niza[8] == 1) luckyHot.Mat[2][2] += 6;
                }
                label3.Text = "Win: " + niza[9];
                label1.Text = "Credits: " + luckyHot.Credits;
                time = !time;
                elapsed = 0;
                
            }
            else
            {
                reset();
                luckyHot.Spin();
                elapsed++;
            }
            Invalidate(true);
        }


        private void reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (luckyHot.Mat[i][j] > 5)
                    {
                        luckyHot.Mat[i][j] -= 6;
                    }

                }
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Change bet
            if (Bet == 50)
            {
                Bet = 5;
            }
            else
            {
                Bet += 5;
            }
            luckyHot.Bet = Bet;
            label2.Text = "Bet: " + Bet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //spin/stop
            if (time)
            {
                if (luckyHot.Credits >= luckyHot.Bet)
                {
                    luckyHot.Credits -= luckyHot.Bet;
                    label1.Text = "Credits: " + luckyHot.Credits;
                    reset();
                    timer.Start();
                    time = !time;
                }
                else
                {
                    MessageBox.Show("You don't have enough credits","Not enough credits",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                timer.Stop();
                elapsed = 0;
                int[] niza = luckyHot.Stop();
                if (niza[9] > 0)
                {
                    if (niza[0] == 1) luckyHot.Mat[0][0] += 6;
                    if (niza[1] == 1) luckyHot.Mat[0][1] += 6;
                    if (niza[2] == 1) luckyHot.Mat[0][2] += 6;
                    if (niza[3] == 1) luckyHot.Mat[1][0] += 6;
                    if (niza[4] == 1) luckyHot.Mat[1][1] += 6;
                    if (niza[5] == 1) luckyHot.Mat[1][2] += 6;
                    if (niza[6] == 1) luckyHot.Mat[2][0] += 6;
                    if (niza[7] == 1) luckyHot.Mat[2][1] += 6;
                    if (niza[8] == 1) luckyHot.Mat[2][2] += 6;
                }
                label3.Text = "Win: " + niza[9];
                label1.Text = "Credits: " + luckyHot.Credits;
                time = !time;
            }
            Invalidate(true);
            
        }

        private void Game1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point p = new Point();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ( j == 0)
                    { 
                        p.X = Convert.ToInt32(this.Width * 0.12);
                    }
                    if (j == 1)
                    {
                        p.X = Convert.ToInt32(this.Width * 0.42);
                    }
                    if (j == 2)
                    {
                        p.X = Convert.ToInt32(this.Width * 0.70);
                        
                    }
                    if (i == 0)
                    {
                        p.Y = Convert.ToInt32(this.Width * 0.08);
                    }
                    if (i == 1)
                    {
                        p.Y = Convert.ToInt32(this.Width * 0.30);
                    }
                    if (i == 2)
                    {
                        p.Y = Convert.ToInt32(this.Width * 0.52);
                    }

                    if(luckyHot.Mat[i][j] > 5)
                    {
                        p.Y -= 3;
                    }


                    if (luckyHot.Mat[i][j] == 0)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.lemon1,p);
                    }
                    else if (luckyHot.Mat[i][j] == 1)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.orange1, p);
                    }
                    else if (luckyHot.Mat[i][j] == 2)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.plum1, p);
                    }
                    else if (luckyHot.Mat[i][j] == 3)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.grapes1, p);
                    }
                    else if (luckyHot.Mat[i][j] == 4)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.melon1, p);
                    }
                    else if (luckyHot.Mat[i][j] == 5)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.lucky7, p);
                    }
                    else if (luckyHot.Mat[i][j] == 6)//highlight
                    {
                        
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.lemon1h, p);
                    }
                    else if (luckyHot.Mat[i][j] == 7)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.orange1h, p);
                    }
                    else if (luckyHot.Mat[i][j] == 8)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.plum1h, p);
                    }
                    else if (luckyHot.Mat[i][j] == 9)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.grapes1h, p);
                    }
                    else if (luckyHot.Mat[i][j] == 10)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.melon1h, p);
                    }
                    else if (luckyHot.Mat[i][j] == 11)
                    {
                        g.DrawImageUnscaled(VPProekt.Properties.Resources.lucky7h, p);
                    }
                }
            }

        }
    }
}
