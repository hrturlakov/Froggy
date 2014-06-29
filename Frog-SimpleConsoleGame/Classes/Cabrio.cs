using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Cabrio : Frog_SimpleConsoleGame.Classes.Car
    {
        public StringBuilder cabrioFirstRow;
        public StringBuilder cabrioSecondRow;
        public StringBuilder cabrioThirtRow;

        public Cabrio(int row, int coll)
            : base(row, coll)
        {
            this.cabrioFirstRow = new StringBuilder();
            this.cabrioSecondRow = new StringBuilder();
            this.cabrioThirtRow = new StringBuilder();
        }

        public override void Render()
        {

            cabrioFirstRow.Append( @"  _______/_____   ");
            cabrioSecondRow.Append(@"D'-.      | /  )  ");
            cabrioThirtRow.Append(@"'(o)'-.....'(O)'  ");
            //Cabrio size
            this.SizeX = 18;
            this.SizeY = 3;
        }

        public override void PrintOnPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.cabrioFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.cabrioSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.cabrioThirtRow.ToString());
        }

        public override void Move()
        {
           
            if (this.Coll > 1)
            {
                this.Coll--;
            }
            if (this.Coll == 1)
            {
                this.cabrioFirstRow.Remove(0, 1);
                this.cabrioSecondRow.Remove(0, 1);
                this.cabrioThirtRow.Remove(0, 1);
            }
            if (this.cabrioThirtRow.Length == 0)
            {
                this.Render();
                this.Coll = 69;
            }
        }
    }
}
