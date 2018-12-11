using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace NotePad
{
    class Program
    {

        static void Main(string[] args)
        {
            MyConsole consloe = new MyConsole();
            consloe.Start();

            //NewMethod();
        }

        private static void NewMethod()
        {
            //User u1 = new User("hovo", "guloyan", "sdf", "ds");
            //User u2 = new User("goq", "hak", "sdf", "ds");

            //List<User> list = new List<User>() { u1, u2 };

            //File.WriteAllText("D:Test//cont.json", JsonConvert.SerializeObject(list));
            //Console.ReadLine();
            List<User> newlist = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("D:Test//cont.json"));
            foreach (var item in newlist)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
