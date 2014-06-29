using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public class FrogHome : StaticObject
    {
        public override void RenderOnPosition(int coll, int row)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(coll, row);
            Console.Write("  _________________________________________________________\"\"\"\"\"______________");
            Console.SetCursorPosition(coll, row + 1);
            Console.Write(" /^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\\");
            Console.SetCursorPosition(coll, row + 2);
            Console.Write("/^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\\");
            Console.SetCursorPosition(coll, row + 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" |                              * FROGGY HOME *                               |");
            Console.SetCursorPosition(coll, row + 4);
            Console.Write(" |");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  @@  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  @@  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  @@  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  @@  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  @@  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");

            Console.SetCursorPosition(coll, row + 5);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" |");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (~~) ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (~~) ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (~~) ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (~~) ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("********");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (~~) ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("*******");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");
            Console.WriteLine();
        }
    }
}
