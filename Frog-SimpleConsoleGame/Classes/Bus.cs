using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Bus : Frog_SimpleConsoleGame.Classes.Car
    {
        public StringBuilder busFirstRow;
        public StringBuilder busSecondRow;
        public StringBuilder ThirtRow;

        public Bus(int row, int coll)
            : base(row, coll)
        {
            this.busFirstRow = new StringBuilder();
            this.busSecondRow = new StringBuilder();
            this.ThirtRow = new StringBuilder();
        }

        public override void Render()
        {
            busFirstRow.Append( "   ________   ");
            busSecondRow.Append("   [][][][]-. ");
            ThirtRow.Append(    "   '0----0--' ");
            //Bus size
            this.SizeX = 14;
            this.SizeY = 3;
        }

        public override void PrintOnPosition()
        {
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.busFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.busSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.ThirtRow.ToString());
        }

        public override void Move()
        {
            this.Coll++;
            if (this.Coll + this.busFirstRow.Length == Console.WindowWidth)
            {
                this.busFirstRow.Remove(this.busFirstRow.Length - 1, 1);
                this.busSecondRow.Remove(this.busSecondRow.Length - 1, 1);
                this.ThirtRow.Remove(this.ThirtRow.Length - 1, 1);
            }
            if (this.ThirtRow.Length == 0)
            {
                this.Render();
                this.Coll = 0;
            }
        }
    }
}
