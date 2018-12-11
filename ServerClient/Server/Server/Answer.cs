using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Server
{
    static class Answer
    {
        private static string str;
       
        public static void Start()
        {

            while (true)
            {
                EventWaitHandle wait = new EventWaitHandle(false, EventResetMode.AutoReset, "Server");
                wait.WaitOne();

                ReadQuestion();
                WriteAnswer();

                EventWaitHandle start = EventWaitHandle.OpenExisting("Client");
                start.Set();
            }
        
        }

        private static void ReadQuestion()
        {
            using (StreamReader reader = new StreamReader("QuestionAnswer.txt"))
            {
                str = reader.ReadLine();
            }
        }
        private static void WriteAnswer()
        {
            using (StreamWriter writer = new StreamWriter("QuestionAnswer.txt"))
            {
                string answer = Solve();

                writer.WriteLine(answer);
            }
        }
        private static string Solve()
        {
            string simbol = "+-*/";
            char o = '?';

            foreach (char x in simbol)
            {
                if (str.Contains(x))
                {
                    o = x;
                    break;
                }
            }

            if (o == '?')
                throw new Exception("Operator doesn't exist");

            return SolveAction(o).ToString();
        }
        private static double SolveAction(char o)
        {
            string[] arr;

            arr = str.Split(o);
            double a = double.Parse(arr[0]);
            double b = double.Parse(arr[1]);

            switch (o)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }
            return -1;
        }
    }
}
