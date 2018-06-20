using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProekt
{
    public class DazzlingHot
    {

        public int[][] Mat { get; set; }
        public int Bet { get; set; }
        public int Credits { get; set; }
        public static Random rand = new Random();

        public DazzlingHot(int credits, int bet)
        {
            Bet = bet;
            Credits = credits;
            Mat = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                Mat[i] = new int[5];
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Mat[i][j] = rand.Next(0, 6);

                }
            }
        }

        public void Spin()
        {

            int[] temp1 = Mat[0];
            int[] temp2 = Mat[1];
            int[] temp3 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                temp3[i] = rand.Next(0, 6);
            }
            Mat[0] = temp3;
            Mat[1] = temp1;
            Mat[2] = temp2;


        }

        private int win(int znak,int l)
        {
            //l 1=3linii, 2=4linii, 3=5,linii
            int w = 0;
            if (znak == 0 || znak == 1)
            {
                w = (Bet * 2);
            }
            else if (znak == 2)
            {
                w = (Bet * 4);
            }
            else if (znak == 3 || znak == 4)
            {
                w = (Bet * 8);
            }
            else if (znak == 5)
            {
                w = (Bet * 20);
            }
            return w*l;
        }

        public int[] Stop()
        {
            int[] l = new int[16];
            for (int i = 0; i < 16; i++)
            {
                l[i] = -1;
            }


            int Win = 0;
            if (Mat[0][0] == Mat[1][1] && Mat[1][1] == Mat[2][2])
            {
                if(Mat[2][2] == Mat[1][3])
                {
                    if(Mat[1][3] == Mat[0][4])
                    {
                        Win += win(Mat[0][0], 3);
                        l[0] = 1;
                        l[6] = 1;
                        l[12] = 1;
                        l[8] = 1;
                        l[4] = 1;
                    }
                    else
                    {
                        Win += win(Mat[0][0], 2);
                        l[0] = 1;
                        l[6] = 1;
                        l[12] = 1;
                        l[8] = 1;
                    }
                }
                else
                {
                    Win += win(Mat[0][0],1);
                    l[0] = 1;
                    l[6] = 1;
                    l[12] = 1;
                }
            }




            if (Mat[2][0] == Mat[1][1] && Mat[1][1] == Mat[0][2])
            {
                if(Mat[0][2] == Mat[1][3])
                {
                    if(Mat[1][3] == Mat[2][4])
                    {
                        Win += win(Mat[2][0], 3);
                        l[2] = 1;
                        l[6] = 1;
                        l[10] = 1;
                        l[8] = 1;
                        l[14] = 1;
                    }
                    else
                    {
                        Win += win(Mat[2][0],2);
                        l[2] = 1;
                        l[6] = 1;
                        l[10] = 1;
                        l[8] = 1;
                    }
                }
                else
                {
                    Win += win(Mat[2][0],1);
                    l[2] = 1;
                    l[6] = 1;
                    l[10] = 1;
                }

            }





            if (Mat[0][0] == Mat[0][1] && Mat[0][1] == Mat[0][2])
            {
                if(Mat[0][2] == Mat[0][3])
                {
                    if(Mat[0][3] == Mat[0][4])
                    {
                        Win += win(Mat[0][0], 3);
                        l[0] = 1;
                        l[1] = 1;
                        l[2] = 1;
                        l[3] = 1;
                        l[4] = 1;
                    }
                    else
                    {
                        Win += win(Mat[0][0], 2);
                        l[0] = 1;
                        l[1] = 1;
                        l[2] = 1;
                        l[3] = 1;
                    }
                }
                else
                {
                    Win += win(Mat[0][0],1);
                    l[0] = 1;
                    l[1] = 1;
                    l[2] = 1;
                }

            }





            if (Mat[1][0] == Mat[1][1] && Mat[1][1] == Mat[1][2])
            {
                if(Mat[1][2] == Mat[1][3])
                {
                    if(Mat[1][3] == Mat[1][4])
                    {
                        Win += win(Mat[1][0], 3);
                        l[5] = 1;
                        l[6] = 1;
                        l[7] = 1;
                        l[8] = 1;
                        l[9] = 1;
                    }
                    else
                    {
                        Win += win(Mat[1][0], 2);
                        l[5] = 1;
                        l[6] = 1;
                        l[7] = 1;
                        l[8] = 1;
                    }
                }
                else
                {
                    Win += win(Mat[1][0],1);
                    l[5] = 1;
                    l[6] = 1;
                    l[7] = 1;
                }

            }





            if (Mat[2][0] == Mat[2][1] && Mat[2][0] == Mat[2][2])
            {
                if(Mat[2][2] == Mat[2][3])
                {
                    if(Mat[2][3] == Mat[2][4])
                    {
                        Win += win(Mat[2][0],3);
                        l[10] = 1;
                        l[11] = 1;
                        l[12] = 1;
                        l[13] = 1;
                        l[14] = 1;
                    }
                    else
                    {
                        Win += win(Mat[2][0],2);
                        l[10] = 1;
                        l[11] = 1;
                        l[12] = 1;
                        l[13] = 1;
                    }
                }
                else
                {
                    Win += win(Mat[2][0],1);
                    l[10] = 1;
                    l[11] = 1;
                    l[12] = 1;
                }

            }



            this.Credits += Win;
            l[15] = Win;
            return l;
        }


    }
}
