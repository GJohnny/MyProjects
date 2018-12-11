using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JumpGame
{
    class Manikin
    {
        private int x;
        private int y;
        public string Name { get; set; }

        public Manikin(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 23)
                    x = 23;
                else if (value > 76)
                    x = 76;
                else
                    x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (value < 2)
                    y = 2;
                else if (value > 25)
                    y = 25;
                else
                    y = value;
            }
        }

        public void Draw(int x, int y, bool b = true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (b)
            {
                Console.SetCursorPosition(x, y);
                Console.Write($" {(char)2}");
                Console.SetCursorPosition(x, ++y);
                Console.Write(@"/|\");
                Console.SetCursorPosition(x, ++y);
                Console.Write(@"/ \");
            }
            else
            {
                Console.SetCursorPosition(--x, y);
                Console.Write("    ");
                Console.SetCursorPosition(x, ++y);
                Console.Write("     ");
                Console.SetCursorPosition(--x, ++y);
                Console.Write("     ");
            }
            Console.ResetColor();
        }
        public void Move()
        {
                Draw(X, Y);
                if (Console.KeyAvailable)
                {
                    Draw(X, Y, false);
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.LeftArrow)
                        X -= 5;
                    else if (key == ConsoleKey.RightArrow)
                        X += 5;
                    Draw(X, Y); 
                }
                Thread.Sleep(50);
                Draw(X, Y, false);
                Y++;
        }
    }
}
