using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatkaGame
{
    class BatkaGame
    {

        const int ConsoleHeight = 50;
        const int ConsoleWidth = 50;
        public static Batka batka;
        public static List<Pill> pillsList;
        

        // new code from 20.02.2015 02:45
        public enum Directions { Right, Up, Left, Down }; // this Enum indcates directions of the move. Accept as an array[] - array[0]-Right, array[1]-Up, array[2]-Left, array[3]-Down
        public static Directions currentDirrection; // we'll need this in the game when batka have to move without arrows
        static void Main(string[] args)
        {
            // These are the directions
            // If we need to move Right, we have to increase the col, and the row have to be the same
            // If we need to move Up, we have to decrease the row, and the col have to be the same
            // If we need to move Left, we have to decrease the column, the row have to be the same
            // If we need to move Down, we have to increase the row, the col have to be the same
            Direction[] directionCoords = new Direction[]   
            {
                new Direction(0,1),
                new Direction(-1,0),
                new Direction(0,-1),
                new Direction(1,0)
            };

            Random rand = new Random();
            // creates all the objects we needed at the first initiallization - batka, badPill, goodPill
            Initiallize(rand);

            while (true)
            {
                int counter = 0;
                Thread.Sleep(100);
                // Checks for the user input and changes the coords of the bata. We pass as parameter the only one object batka, the cyrrent direction, and the struct where we hold all direcions coordinates
                
                    MoveBatka(batka);
                
               



                Console.Clear();

                //// After Console.Clear() we have to draw the objects. Batka is the same one, the pills will be a lot. For now there is only one pill in each collection
                batka.Draw();

                
                BadPill badPill = new BadPill(rand.Next(0, Console.WindowWidth - 1), rand.Next(0, Console.WindowHeight - 1));
                GoodPill goodPill = new GoodPill(rand.Next(0, Console.WindowWidth - 1), rand.Next(0, Console.WindowHeight - 1));

                badPill.RespondToCollision(batka);



                goodPills.Add(goodPill);
                badPills.Add(badPill);

                for (int i = 0; i < goodPills.Count; i++)
                {
                    goodPills[i].RespondToCollision(batka);
                    if (goodPills[i].Symbol=='.')
                    {
                        goodPills.RemoveAt(i);
                    }
                }
                for (int i = 0; i < badPills.Count; i++)
                {
                    badPills[i].RespondToCollision(batka);
                    if (badPills[i].Symbol == '.')
                    {
                        badPills.RemoveAt(i);
                    }
                }

                GoodPillsDraw(goodPills);
                BadPillsDraw(badPills);
            }
        }

        private static void BadPillsDraw(List<BadPill> badPills)
        {
            foreach (var badPill in badPills)
            {
                badPill.Draw();
            }
        }

        private static void GoodPillsDraw(List<GoodPill> goodPills)
        {
            foreach (var goodPill in goodPills)
            {
                goodPill.Draw();
            }
        }

        private static void Initiallize(Random rand)
        {
            Console.CursorVisible = false;
            Console.Title = "БАТКА";
            Console.SetWindowSize(69, 49);
            Console.SetBufferSize(70, 50);
            batka = new Batka(Console.WindowWidth / 2, Console.WindowHeight / 2);
            BadPill badPill = new BadPill(rand.Next(0, Console.WindowWidth - 1), rand.Next(0, Console.WindowHeight - 1));
            GoodPill goodPill = new GoodPill(rand.Next(0, Console.WindowWidth - 1), rand.Next(0, Console.WindowHeight - 1));
            badPills = new List<BadPill>();
            goodPills = new List<GoodPill>();
            badPills.Add(badPill);
            goodPills.Add(goodPill);
        }

        private static void MoveBatka(Batka myBatka)
        {

            
            List<ConsoleKeyInfo> list = new List<ConsoleKeyInfo>();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();


                while (Console.KeyAvailable)
                {
                    list.Add(userInput);
                    userInput = Console.ReadKey();



                }

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    myBatka.YCoord++;
                }


                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    myBatka.YCoord--;
                }


                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    myBatka.XCoord--;
                }

                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    myBatka.XCoord++;
                }

            }

            //}

            //list.Clear();









            //  Takes from the array directionCoords the new direction. 
            // Here it will be used public enum Directions just for clarity - assume that Right==0, Up==1, Left==2, Down==3
            // and this is an usual array operation - taking a value by its index


            // calculate the new coordinates of batka after the movement 
            //myBatka.XCoord += nextDirection.Row; // now batka have new row(xCoord) position
            //myBatka.YCoord += nextDirection.Col; // now batka have new col(yCoord) position

        }
    }
}
