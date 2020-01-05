using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleSolver
{
    class Program
    {
        static string TargetWord = "aee";
        static readonly Random rnd = new Random();
        static int[] LetterBag = { 9, 2, 2, 4, 12, 2, 3, 2, 9, 1, 1, 4, 2, 6, 8, 2, 1, 6, 4, 6, 4, 2, 2, 1, 2, 1, 2 };

        static void Main(string[] args)
        {

            double playerOneSuccess = 0;
            double playerTwoSuccess = 0;



            for (int trials = 0; trials < 1000; trials++)
            {
                playerOneSuccess = 0;
                playerTwoSuccess = 0;

                for (int i = 0; i < 100000; i++)
                {
                    char[] PlayerOneDraw = DrawTile(3).ToCharArray();
                    Array.Sort(PlayerOneDraw);
                    string playerOneHand = new string(PlayerOneDraw);

                    char[] PlayerTwoDraw = DrawTile(3).ToCharArray();
                    Array.Sort(PlayerTwoDraw);
                    string playerTwoHand = new string(PlayerTwoDraw);

                    if (playerOneHand.Equals(TargetWord))
                    {
                        playerOneSuccess++;
                    }

                    if (playerTwoHand.Equals(TargetWord))
                    {
                        playerTwoSuccess++;
                    }

                    // Reset the letterbag
                    ResetLetterBag();
                }

                //Console.WriteLine("Take All:");
                //Console.WriteLine("Player One: " + playerOneSuccess);
                //Console.WriteLine("Player Two: " + playerTwoSuccess);

                //for (int i = 0; i < 100000; i++)
                //{
                //    string PlayerOneDraw = "";
                //    string PlayerTwoDraw = "";

                //    for (int x = 0; x < 3; x++)
                //    {
                //        PlayerOneDraw += DrawTile(1);
                //        PlayerTwoDraw += DrawTile(1);
                //    }

                //    char[] PlayerOneTemp = PlayerOneDraw.ToCharArray();
                //    Array.Sort(PlayerOneTemp);
                //    string playerOneHand = new string(PlayerOneTemp);

                //    char[] PlayerTwoTemp = PlayerTwoDraw.ToCharArray();
                //    Array.Sort(PlayerTwoTemp);
                //    string playerTwoHand = new string(PlayerTwoTemp);

                //    if (playerOneHand.Equals(TargetWord))
                //    {
                //        playerOneSuccess++;
                //    }

                //    if (playerTwoHand.Equals(TargetWord))
                //    {
                //        playerTwoSuccess++;
                //    }

                //    // Reset the letterbag
                //    ResetLetterBag();
                //}

                double ratio = playerOneSuccess / playerTwoSuccess;
                Console.WriteLine(ratio);
            }

            //Console.WriteLine("One By One:");
            //Console.WriteLine("Player One: " + playerOneSuccess);
            //Console.WriteLine("Player Two: " + playerTwoSuccess);

            Console.ReadLine();
        }

        static void ResetLetterBag()
        {
            LetterBag[0] = 9;
            LetterBag[1] = 2;
            LetterBag[2] = 2;
            LetterBag[3] = 4;
            LetterBag[4] = 12;
            LetterBag[5] = 2;
            LetterBag[6] = 3;
            LetterBag[7] = 2;
            LetterBag[8] = 9;
            LetterBag[9] = 1;
            LetterBag[10] = 1;
            LetterBag[11] = 4;
            LetterBag[12] = 2;
            LetterBag[13] = 6;
            LetterBag[14] = 8;
            LetterBag[15] = 2;
            LetterBag[16] = 1;
            LetterBag[17] = 6;
            LetterBag[18] = 4;
            LetterBag[19] = 6;
            LetterBag[20] = 4;
            LetterBag[21] = 2;
            LetterBag[22] = 2;
            LetterBag[23] = 1;
            LetterBag[24] = 2;
            LetterBag[25] = 1;
            LetterBag[26] = 2;
        }

        static string DrawTile(int numberToDraw)
        {
            string returnedTiles = "";

            for (int i = 0; i < numberToDraw; i++)
            {
                //pick a tile
                int drawnTile = rnd.Next(0, 26);

                //if there are no left reroll
                while (LetterBag[drawnTile] <= 0)
                {
                    drawnTile = rnd.Next(0, 26);
                }

                if (drawnTile == 26) //if the tile is blank
                {
                    returnedTiles += " ";                    
                }
                else
                {
                    returnedTiles += Convert.ToChar('a' + drawnTile);
                }

                LetterBag[drawnTile] = LetterBag[drawnTile] - 1;
            }

            return returnedTiles;
        }
    }
}
