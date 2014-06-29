using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Frog : MovingObject
    {
        public StringBuilder frogFirstRow;
        public StringBuilder forgSecondRow;

        private int lives;
        private int points;
        private int inHome;

        public int Lives
        {
            get { return lives; }
            set
            {
                if (this.lives < 0)
                {
                    throw new ArgumentException("Lives number must be positive!");
                }
                else
                {
                    this.lives = value;
                }
            }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public int InHome
        {
            get { return inHome; }
            set { inHome = value; }
        }

        public Frog(int row, int coll)
            : base(row, coll)
        {
            this.frogFirstRow = new StringBuilder();
            this.forgSecondRow = new StringBuilder();
        }

        public void PrintFrog(int coll, int row)
        {
            Console.SetCursorPosition(coll, row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" @@ ");
            Console.SetCursorPosition(coll, row + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(~~)");
        }

        public void Move()
        {
            this.PrintFrog(this.Coll, this.Row);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (this.Coll < MainProgram.MaxWidth - 4)
                    {
                        this.PrintFrog(this.Coll + 1, this.Row);
                        Console.SetCursorPosition(this.Coll, this.Row);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.Coll, this.Row + 1);
                        Console.Write(" ");
                        Sounds.JumpSound();
                        this.Coll++;
                    }
                }

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (this.Coll > 0)
                    {
                        this.PrintFrog(this.Coll - 1, this.Row);
                        Console.SetCursorPosition(this.Coll + 2, this.Row);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.Coll + 3, this.Row + 1);
                        Console.Write(" ");
                        Sounds.JumpSound();
                        this.Coll--;
                    }
                }

                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (this.Row > 11)
                    {
                        this.PrintFrog(this.Coll, this.Row - 1);
                        for (int i = 0; i <= 3; i++)
                        {
                            Console.SetCursorPosition(this.Coll + i, this.Row + 1);
                            Console.Write(" ");
                        }
                        Sounds.JumpSound();
                        this.Row--;
                    }
                    else if (this.Row == 11 && this.Coll == 10)
                    {
                        FrogUpTwoStep(this.Coll, this.Row);
                        this.PrintFrog(10, 9);
                        this.Coll = 48;
                        this.Row = 48;
                        this.PrintFrog(this.Coll, this.Row);
                        this.inHome++;
                    }
                    else if (this.Row == 11 && this.Coll == 24)
                    {
                        FrogUpTwoStep(this.Coll, this.Row);
                        this.PrintFrog(24, 9);
                        this.Coll = 48;
                        this.Row = 48;
                        this.PrintFrog(this.Coll, this.Row);
                        this.inHome++;
                    }
                    else if (this.Row == 11 && this.Coll == 38)
                    {
                        FrogUpTwoStep(this.Coll, this.Row);
                        this.PrintFrog(38, 9);
                        this.Coll = 48;
                        this.Row = 48;
                        this.PrintFrog(this.Coll, this.Row);
                        this.inHome++;
                    }
                    else if (this.Row == 11 && this.Coll == 52)
                    {
                        FrogUpTwoStep(this.Coll, this.Row);
                        this.PrintFrog(52, 9);
                        this.Coll = 48;
                        this.Row = 48;
                        this.PrintFrog(this.Coll, this.Row);
                        this.inHome++;
                    }
                    else if (this.Row == 11 && this.Coll == 66)
                    {
                        FrogUpTwoStep(this.Coll, this.Row);
                        this.PrintFrog(66, 9);
                        this.Coll = 48;
                        this.Row = 48;
                        this.PrintFrog(this.Coll, this.Row);
                        this.inHome++;
                    }
                }

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (this.Row < MainProgram.MaxHeight - 2)
                    {
                        this.PrintFrog(this.Coll, this.Row + 1);
                        Console.SetCursorPosition(this.Coll + 1, this.Row);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.Coll + 2, this.Row);
                        Console.Write(" ");
                        Sounds.JumpSound();
                        this.Row++;
                    }
                }
            }

        }

        public void FrogUpTwoStep(int startCol, int startRow)
        {
            this.PrintFrog(this.Coll, this.Row - 2);
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.Write("    ");
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.Write("    ");
            Sounds.JumpSound();
        }

        //public override void Render()
        //{
        //    frogFirstRow.Append(" @@ ");
        //    forgSecondRow.Append("(~~)");
        //}

        //public override void PrintOnPosition()
        //{
        //    Console.SetCursorPosition(this.Coll, this.Row);
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine(this.frogFirstRow.ToString());
        //    Console.SetCursorPosition(this.Coll, this.Row + 1);
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(this.forgSecondRow.ToString());
        //}
    }
}
