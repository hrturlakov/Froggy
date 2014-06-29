using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Flowers : MovingObject
    {
        public StringBuilder buildFlowersFirstRow;
        public StringBuilder buildFlowersSecondRow;
        public StringBuilder buildFlowersThirdRow;

        public Flowers(int row, int coll)
            : base(row, coll)
        {
            this.buildFlowersFirstRow = new StringBuilder();
            this.buildFlowersSecondRow = new StringBuilder();
            this.buildFlowersThirdRow = new StringBuilder();
        }

        public override void Render()
        {
            this.buildFlowersFirstRow.Append(" _(\')_  _(\')_   ");
            this.buildFlowersSecondRow.Append("(_ @ _)(_ @ _)  ");
            this.buildFlowersThirdRow.Append("  (,)    (,)    ");

        }

        public override void PrintOnPosition()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.buildFlowersFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.buildFlowersSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.buildFlowersThirdRow.ToString());
        }

        public override void Move()
        {
            if (this.Coll != 0)
            {
                this.Coll--;
            }
            if (this.Coll == 0)
            {
                this.buildFlowersFirstRow.Remove(0, 1);
                this.buildFlowersSecondRow.Remove(0, 1);
                this.buildFlowersThirdRow.Remove(0, 1);
            }
            if (this.buildFlowersFirstRow.Length == 0)
            {
                this.Render();
                this.Coll = Console.WindowWidth - 14;
            }
        }
    }
}
