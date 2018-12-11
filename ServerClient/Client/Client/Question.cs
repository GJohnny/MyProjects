using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Client
{
    static class Question
    {
       

        public static void Start()
        {
            while (true)
            {
                WriteQuestion();

                EventWaitHandle start = EventWaitHandle.OpenExisting("Server");
                start.Set();

                EventWaitHandle wait = new EventWaitHandle(false, EventResetMode.AutoReset,"Client");
                wait.WaitOne();

                ReadAnswer();
                Console.ReadLine();
            }
        }
        
        private static void WriteQuestion()
        {
            Console.Clear();
            Console.WriteLine("Enter your question");
            using (StreamWriter writer = new StreamWriter(@"D:\Visual Studio 2017\Projects\BootCamp\GitHub\ServerClient\Server\Server\bin\Debug\QuestionAnswer.txt"))
            {
                writer.WriteLine(Console.ReadLine());
            }
        }
        private static void ReadAnswer()
        {
            Console.WriteLine("Answer is ");
            using (StreamReader reader = new StreamReader(@"D:\Visual Studio 2017\Projects\BootCamp\GitHub\ServerClient\Server\Server\bin\Debug\QuestionAnswer.txt"))
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
    }
}
