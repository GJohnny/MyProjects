using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JumpGame
{
    class Game
    {
        public int Score { get; set; }
        Manikin manikin = new Manikin(45, 5);
        Field field = new Field();
        Line l1 = new Line();
        Line l2 = new Line();
        Line l3 = new Line();
        Line l4 = new Line();
        Line l5 = new Line();
        Line l6 = new Line();


        public void DrawLines(bool b = true)
        {
            if (b)
            {
                l1.Draw();
                l2.Draw();
                l3.Draw();
                l4.Draw();
                l5.Draw();
                l6.Draw();
            }
            else
            {
                l1.Draw(false);
                l2.Draw(false);
                l3.Draw(false);
                l4.Draw(false);
                l5.Draw(false);
                l6.Draw(false);
            }
        }
        public void Start()
        {
            int n = 1;
            field.Draw();
            while (true)
            {
                if (manikin.X > l1.X - 5 && manikin.X < l1.X + 5 && manikin.Y + 4 == l1.Y ||
                    manikin.X > l2.X - 5 && manikin.X < l2.X + 5 && manikin.Y + 4 == l2.Y ||
                    manikin.X > l3.X - 5 && manikin.X < l3.X + 5 && manikin.Y + 4 == l3.Y ||
                    manikin.X > l4.X - 5 && manikin.X < l4.X + 5 && manikin.Y + 4 == l4.Y ||
                    manikin.X > l5.X - 5 && manikin.X < l5.X + 5 && manikin.Y + 4 == l5.Y ||
                    manikin.X > l6.X - 5 && manikin.X < l6.X + 5 && manikin.Y + 4 == l6.Y)
                    n = 5;
                for (int i = 0; i < n; i++)
                {
                    manikin.Move();
                    if (n > 1)
                        manikin.Y -= 3;
                }
                n = 1;
                DrawLines();
                Thread.Sleep(70);
                DrawLines(false);

                l1.Y++; l2.Y++; l3.Y++; l4.Y++; l5.Y++; l6.Y++;
                if (manikin.Y > 24)
                    break;
                Score++;
                Console.SetCursorPosition(50, 0);
                Console.Write($"Score - {Score}");
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Your score is {Score}");
            Console.WriteLine("Game over");
        }

    }
}
