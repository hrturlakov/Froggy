using Frog_SimpleConsoleGame.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Frog_SimpleConsoleGame
{
    class MainProgram
    {
        public const int MaxHeight = 50;
        public const int MaxWidth = 80;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            // main screen
            DrawingScreen.DrawMainScreen();
            Console.Clear();

            FrogHome home = new FrogHome();
            home.RenderOnPosition(0, 5);

            // main engine
            Engine();
        }

        private static void Engine()
        {
            List<Tree> treesFR = new List<Tree>();
            List<Tree> treesSR = new List<Tree>();
            List<Tree> treesTR = new List<Tree>();
            List<Flowers> flowersFR = new List<Flowers>();
            List<Flowers> flowersSR = new List<Flowers>();
            List<Car> cars = new List<Car>();

            Random randGen = new Random();
            int nextElementTr = 25;
            int nextElementFl = 48;
            int counterTr = 0;
            int counterFl = 0;
            int slower = 0;
            cars.Add(new PoliceCar(43, 2));
            cars.Add(new Cabrio(39, 60));
            cars.Add(new Truck(34, 3));
            cars.Add(new Cabrio(29, 70));

            foreach (var car in cars)
            {
                car.Render();
            }

            treesFR.Add(new Tree(MaxHeight / 2 - 2, 0));
            treesFR[0].Render();
            treesSR.Add(new Tree(MaxHeight / 2 - 8, 0));
            treesSR[0].Render();
            treesTR.Add(new Tree(MaxHeight / 2 - 14, 0));
            treesTR[0].Render();

            flowersFR.Add(new Flowers(MaxHeight / 2 - 5, Console.WindowWidth - 14));
            flowersFR[0].Render();
            flowersSR.Add(new Flowers(MaxHeight / 2 - 11, Console.WindowWidth - 14));
            flowersSR[0].Render();

            Island island = new Island();

            Frog frog = new Frog(Console.WindowHeight - 2, Console.WindowWidth / 2);
            frog.Render();
            frog.Lives = 7;
            frog.InHome = 0;

            int counterCars = 0;

            // timer
            Stopwatch time = new Stopwatch();
            time.Start();

            while (frog.Lives != 0)
            {

                counterCars++;
                counterTr++;
                counterFl++;
                slower++;
                bool onElement = false;

                // information on top
                DrawingScreen.Information(frog.Lives, time, frog.Points);

                // draw island
                island.RenderOnPosition(0, MainProgram.MaxHeight / 2 + 1);

                //Tree move
                TreeMove(treesFR, treesSR, randGen, ref nextElementTr, ref counterTr);

                // main logic for frog on the river elements
                FrogOverTheRiverMainLogic(treesFR, treesSR, treesTR, flowersFR, flowersSR,
                    randGen, ref nextElementFl, ref counterFl, slower, frog, ref onElement);

                // print flowers
                foreach (var flowerFR in flowersFR)
                {
                    flowerFR.PrintOnPosition();
                }
                foreach (var flowerSR in flowersSR)
                {
                    flowerSR.PrintOnPosition();
                }

                // implement crash of the frog with cars
                CrashWithFrog(cars, frog);

                // add cars on row
                AddMoreCarOnRow(cars, counterCars);

                frog.Move();
                // complete level
                if (frog.InHome == 5)
                {
                    break;
                }

                System.Threading.Thread.Sleep(80);
            }

            time.Stop();
            TimeSpan allTime = time.Elapsed;

            // calculated points
            int pasedTime = (int)allTime.TotalSeconds;
            int points = (pasedTime) + (frog.InHome * 2);

            if (frog.Lives == 0)
            {
                DrawingScreen.GameOver(points);
            }
            else
            {
                DrawingScreen.LevelComplete(points);
            }

            // draw position in ranklist
            DrawingScreen.WritePointsToTxt(points);
            DrawingScreen.DrawScoreBoard();
        }

        private static void AddMoreCarOnRow(List<Car> cars, int counterCars)
        {
            if (counterCars == 40)
            {
                cars.Add(new PoliceCar(43, 2));
                cars.Add(new Cabrio(39, 60));
                cars.Add(new Truck(34, 3));
                cars.Add(new Cabrio(29, 3));

            }
        }

        private static void CrashWithFrog(List<Car> cars, Frog frog)
        {
            foreach (var car in cars)
            {
                car.PrintOnPosition();
                car.Move();
                if ((car.Row <= frog.Row && frog.Row <= car.Row + car.SizeY) &&
                    (car.Coll <= frog.Coll && frog.Coll <= car.Coll + car.SizeX - 3))
                {
                    Death(frog);
                }
            }
        }

        private static void TreeMove(List<Tree> treesFR, List<Tree> treesSR, Random randGen, ref int nextElementTr, ref int counterTr)
        {
            if (treesFR.Count < 3 && counterTr == nextElementTr)
            {
                treesFR.Add(new Tree(MaxHeight / 2 - 2, 0));
                treesSR.Add(new Tree(MaxHeight / 2 - 8, 5));
                treesSR.Add(new Tree(MaxHeight / 2 - 14, 5));
                nextElementTr = randGen.Next(20, 35);
                counterTr = 0;
            }
        }

        private static void FrogOverTheRiverMainLogic(List<Tree> treesFR, List<Tree> treesSR, List<Tree> treesTR, List<Flowers> flowersFR, List<Flowers> flowersSR, Random randGen, ref int nextElementFl, ref int counterFl, int slower, Frog frog, ref bool onElement)
        {
            // frog on islands
            onElement = FrogOnTree(treesFR, frog, onElement);
            onElement = FrogOnTree(treesSR, frog, onElement);
            onElement = FrogOnTree(treesTR, frog, onElement);

            //Flower move
            onElement = FrogOnFlower(flowersFR, frog, onElement);
            onElement = FrogOnFlower(flowersSR, frog, onElement);

            if (slower % 2 == 0)
            {
                if (flowersFR.Count < 3 && counterFl == nextElementFl)
                {
                    flowersFR.Add(new Flowers(MaxHeight / 2 - 5, Console.WindowWidth - 14));
                    flowersSR.Add(new Flowers(MaxHeight / 2 - 11, Console.WindowWidth - 14));
                    nextElementFl = randGen.Next(38, 47);
                    counterFl = 0;
                }
                Console.SetCursorPosition(20, 20);
                // Console.Write(counter);
                // frog on flowers
                onElement = FrogFallsFromTheFlower(flowersFR, frog, onElement);
                onElement = FrogFallsFromTheFlower(flowersSR, frog, onElement);

            }

            if (frog.Row < MainProgram.MaxHeight / 2 && !onElement)
            {
                //Ends game
                frog.Coll = Console.WindowWidth / 2;
                frog.Row = Console.WindowHeight - 2;
                frog.Lives--;
                Sounds.End();
                Console.Clear();
                Sounds.OverTheGameSound();
                FrogHome home = new FrogHome();
                home.RenderOnPosition(0, 5);
            }
        }

        private static bool FrogFallsFromTheFlower(List<Flowers> flowersFR, Frog frog, bool onElement)
        {
            foreach (var flowerfr in flowersFR)
            {
                flowerfr.Move();

                if ((frog.Row >= flowerfr.Row - 1 && frog.Row <= flowerfr.Row + 2) && frog.Coll >= flowerfr.Coll - 1 && frog.Coll < flowerfr.Coll + 13)
                {
                    frog.Coll--;

                    if (frog.Coll == 0)
                    {
                        onElement = false;
                        Death(frog);
                        break;
                    }
                }
            }
            return onElement;
        }

        private static bool FrogOnFlower(List<Flowers> flowersFR, Frog frog, bool onElement)
        {
            foreach (var flowerfr in flowersFR)
            {
                if ((frog.Row >= flowerfr.Row - 1 && frog.Row <= flowerfr.Row + 2) && frog.Coll >= flowerfr.Coll - 1 && frog.Coll < flowerfr.Coll + 13)
                {
                    onElement = true;
                }
            }
            return onElement;
        }

        private static bool FrogOnTree(List<Tree> treesFR, Frog frog, bool onElement)
        {
            foreach (var treeFR in treesFR)
            {
                treeFR.PrintOnPosition();
                treeFR.Move();

                if ((frog.Row <= treeFR.Row + 1 && frog.Row >= treeFR.Row - 1) && frog.Coll >= treeFR.Coll - 1 && frog.Coll < treeFR.Coll + 12)
                {
                    onElement = true;
                    frog.Coll++;

                    if (frog.Coll == Console.WindowWidth - 1)
                    {
                        onElement = false;
                        Death(frog);
                        break;
                    }
                }
            }
            return onElement;
        }

        public static void Death(Frog frog)
        {
            Sounds.End();
            Console.Clear();
            Sounds.OverTheGameSound();
            FrogHome home = new FrogHome();
            home.RenderOnPosition(0, 5);
            frog.Coll = 48;
            frog.Row = 48;
            frog.PrintFrog(frog.Coll, frog.Row);
            frog.Lives--;
        }
    }
}
