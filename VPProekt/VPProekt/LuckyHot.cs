using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProekt
{
    public class LuckyHot
    {
        public int[][] Mat { get; set; }
        public int Bet { get; set; }
        public int Credits { get; set; }
        public static Random rand = new Random();

        public LuckyHot(int credits,int bet)
        {
            Bet = bet;
            Credits = credits;
            Mat = new int[3][];
            for(int i = 0; i < 3; i++)
            {
                Mat[i] = new int[3];
            }
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Mat[i][j] = rand.Next(0, 6);

                }
            }
        }

        public void Spin()
        {
            
            int[] temp1 = Mat[0];
            int[] temp2 = Mat[1];
            int[] temp3= new int[3];
            for(int i = 0; i < 3; i++)
            {
                temp3[i] = rand.Next(0, 6);
            }
            Mat[0] = temp3;
            Mat[1] = temp1;
            Mat[2] = temp2;

   
        }

        private int win(int znak)
        {
            int w = 0;
            if (znak == 0 || znak == 1)
            {
                w = (Bet * 8);
            }
            else if (znak == 2)
            {
                w = (Bet * 12);
            }
            else if (znak == 3 || znak == 4)
            {
                w = (Bet * 16);
            }
            else if (znak == 5)
            {
                w = (Bet * 40);
            }
            return w;
        }

        public int[] Stop()
        {
            int[] l = new int[10];
            for(int i = 0; i < 10; i++)
            {
                l[i] = -1;
            }
            int Win=0;
            if(Mat[0][0] == Mat[1][1] && Mat[1][1] == Mat[2][2])
            {
                Win += win(Mat[0][0]);
                l[0] = 1;
                l[4] = 1;
                l[8] = 1;
            }
            if (Mat[2][0] == Mat[1][1] && Mat[1][1] == Mat[0][2])
            {
                Win += win(Mat[2][0]);
                l[6] = 1;
                l[4] = 1;
                l[2] = 1;
            }
            if (Mat[0][0] == Mat[0][1] && Mat[0][0] == Mat[0][2])
            {
                Win += win(Mat[0][0]);
                l[0] = 1;
                l[1] = 1;
                l[2] = 1;
            }
            if (Mat[1][0] == Mat[1][1] && Mat[1][0] == Mat[1][2])
            {
                Win += win(Mat[1][0]);
                l[3] = 1;
                l[4] = 1;
                l[5] = 1;
            }
            if (Mat[2][0] == Mat[2][1] && Mat[2][0] == Mat[2][2])
            {
                Win += win(Mat[2][0]);
                l[6] = 1;
                l[7] = 1;
                l[8] = 1;
            }

            this.Credits += Win;
            l[9] = Win;
            return l;
        }



        


    }
}
