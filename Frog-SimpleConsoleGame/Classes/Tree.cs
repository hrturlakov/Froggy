using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Tree : MovingObject
    {
        public StringBuilder buildTreeFirstRow;
        public StringBuilder buildTreeSecondRow;
        public StringBuilder buildTreeThirdRow;

        public Tree(int row, int coll)
            : base(row, coll)
        {
            this.buildTreeFirstRow = new StringBuilder();
            this.buildTreeSecondRow = new StringBuilder();
            this.buildTreeThirdRow = new StringBuilder();
        }

        public override void Render()
        {
            this.buildTreeFirstRow.Append("  ____________ ");
            this.buildTreeSecondRow.Append(" (____________)");
            this.buildTreeThirdRow.Append("               ");

        }

        public override void PrintOnPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.buildTreeFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.buildTreeSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(buildTreeThirdRow);
        }

        public override void Move()
        {
            this.Coll++;
            if (this.Coll + this.buildTreeSecondRow.Length == Console.WindowWidth)
            {
                this.buildTreeFirstRow.Remove(this.buildTreeFirstRow.Length - 1, 1);
                this.buildTreeSecondRow.Remove(this.buildTreeSecondRow.Length - 1, 1);
                this.buildTreeThirdRow.Remove(this.buildTreeThirdRow.Length - 1, 1);
            }
            if (this.buildTreeSecondRow.Length == 0)
            {
                this.Render();
                this.Coll = 0;
            }
        }
    }
}
