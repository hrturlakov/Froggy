using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class Island : StaticObject
    {
        public override void RenderOnPosition(int coll, int row)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(coll, row);
            string island = "=";
            Console.WriteLine(island.PadLeft(MainProgram.MaxWidth, '='));
            Console.WriteLine(island.PadLeft(MainProgram.MaxWidth, '='));
        }
    }
}
