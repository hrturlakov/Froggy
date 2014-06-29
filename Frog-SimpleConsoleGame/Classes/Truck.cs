using Frog_SimpleConsoleGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Truck : Car
    {
        public StringBuilder truckFirstRow;
        public StringBuilder truckSecondRow;
        public StringBuilder truckThirtRow;

        public Truck(int row, int coll)
            : base(row, coll)
        {
            this.truckFirstRow = new StringBuilder();
            this.truckSecondRow = new StringBuilder();
            this.truckThirtRow = new StringBuilder();
        }

        public override void Render()
        {

            truckFirstRow.Append( "  _________  _     ");
            truckSecondRow.Append(" |         || `--. ");
            truckThirtRow.Append( " '-OO----O-''--O-' ");
            //Truck size
            this.SizeX = 19;
            this.SizeY = 4;
        }

        public override void PrintOnPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.truckFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.truckSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.truckThirtRow.ToString());
        }

        public override void Move()
        {
            this.Coll++;
            if (this.Coll + this.truckFirstRow.Length == Console.WindowWidth)
            {
                this.truckFirstRow.Remove(this.truckFirstRow.Length - 1, 1);
                this.truckSecondRow.Remove(this.truckSecondRow.Length - 1, 1);
                this.truckThirtRow.Remove(this.truckThirtRow.Length - 1, 1);
            }
            if (this.truckThirtRow.Length == 0)
            {
                this.Render();
                this.Coll = 0;
            }
        }
    }
}
