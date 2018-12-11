using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Field
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Field()
        {
            X1 = 20;
            Y1 = 1;
            X2 = 80;
            Y2 = 30;
        }
        public void Draw()
        {
            int x = X1;
            int y = Y1;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = Y1; i <= Y2; i++)
            {
                if (i == Y1 || i == Y2)
                {
                    for (int j = X1; j <= X2; j++)
                    {
                        Console.Write("-");
                    }
                }
                else
                {
                    Console.Write("|");
                    for (int j = X1; j < X2 - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                }
                Console.SetCursorPosition(x, ++y);
            }
            Console.ResetColor();
        }
    }
}
