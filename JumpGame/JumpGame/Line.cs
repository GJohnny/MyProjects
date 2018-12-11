using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Line
    {
        public static Random rd = new Random();
        private int y;
        private int r = rd.Next(22, 70);
        private static int count_of_lines = 0;
        public int X { get; set; }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (y > 22)
                {
                    y = 5;
                    X = rd.Next(22, 70);
                }
                else y = value;
            }
        }

        public Line()
        {
            count_of_lines++;
            X = r;
            Y = 2 + 4 * count_of_lines;
        }
        public void Draw(bool b = true)
        {
            if (b)
            {
                Console.SetCursorPosition(X, y);
                Console.Write("________");
            }
            else
            {
                Console.SetCursorPosition(22, --y);
                Console.Write("                                                         ");
                Console.SetCursorPosition(22, ++y);
                Console.Write("                                                         ");
                Console.SetCursorPosition(22, ++y);
                Console.Write("                                                         ");

            }
        }
    }
}