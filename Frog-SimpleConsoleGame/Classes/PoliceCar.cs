using Frog_SimpleConsoleGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class PoliceCar : Car
    {
        public StringBuilder policeCarFirstRow;
        public StringBuilder policeCarSecondRow;
        public StringBuilder policeCarThirtRow;

        public PoliceCar(int row, int coll)
            : base(row, coll)
        {
            this.policeCarFirstRow = new StringBuilder();
            this.policeCarSecondRow = new StringBuilder();
            this.policeCarThirtRow = new StringBuilder();
        }

        public override void Render()
        {
              policeCarFirstRow.AppendFormat("     __o     ");
              policeCarSecondRow.AppendFormat(@"  __/___\__  ");
              policeCarThirtRow.AppendFormat(" `--O----O-' ");
            //Car size
              this.SizeX = 13;
              this.SizeY = 3;
        }

        public override void PrintOnPosition()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.policeCarFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.policeCarSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.policeCarThirtRow.ToString());
        }

        public override void Move()
        {
            this.Coll++;
            if (this.Coll + this.policeCarFirstRow.Length == Console.WindowWidth)
            {
                this.policeCarFirstRow.Remove(this.policeCarFirstRow.Length - 1, 1);
                this.policeCarSecondRow.Remove(this.policeCarSecondRow.Length - 1, 1);
                this.policeCarThirtRow.Remove(this.policeCarThirtRow.Length - 1, 1);
            }
            if (this.policeCarThirtRow.Length == 0)
            {
                this.Render();
                this.Coll = 0;
            }
        }
    }
}
