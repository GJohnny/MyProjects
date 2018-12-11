using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace NotePad
{
    class MyConsole
    {
        private List<User> UsList { get; set; }
        private User Us { get; set; }

        public MyConsole()
        {
            UsList = new List<User>();
        }
        public void Start()
        {
            UsList = LoadFromFile();
            while (true)
            {
                SignIn();
                Action();
            }
        }
        private void SignIn()
        {
            ConsoleKey key;
            while (true)
            {
                Console.WriteLine("Create account : 1    Login : 2");
                key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                    Registration();
                else if (key == ConsoleKey.NumPad2)
                {
                    Login();
                    break;
                }
            } 
            Us.Blok.ContList = Bloknot.Load(Us);
        }
        private void Action()
        {
            bool b = false;
            while (true)
            {

                Console.Clear();
                ShowBloknot();
                Console.WriteLine("Add : 1    Choose : 2    File Format : 3    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        AddContact();
                        break;
                    case ConsoleKey.NumPad2:
                        ChooseContact();
                        break;
                    case ConsoleKey.NumPad3:
                        EditFileFormat();
                        break;
                    case ConsoleKey.Escape:
                        b = true;
                        break;
                    default:
                        break;
                }
                Us.Blok.Save(Us);

                if (b)
                    break;
            }
        }
        private void Registration()
        {
            Console.WriteLine("Registration");
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter your surname");
            string surname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter password");
            string password1 = Console.ReadLine();
            Console.Clear();
            string password2;
            while (true)
            {
                Console.WriteLine("Repeat password");
                password2 = Console.ReadLine();
                Console.Clear();
                if (password1 == password2)
                    break;
                Console.WriteLine("Incorrect password");
            }
            string fileFormat = FileFormat();
            UsList.Add(new User(name, surname, username, password1, fileFormat));
            Save();
            
        }
        private string FileFormat()
        {
            ConsoleKey key;
            while (true)
            {
                Console.WriteLine("Choose the file format in which will kept data");
                Console.WriteLine("JSON : 1    XML : 2");
                key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                    return "json";
                else if (key == ConsoleKey.NumPad2)
                    return "xml";
            }
        }
        private void Login()
        {
            Console.WriteLine("Login account");
            string username;
            string password;
            bool b = false;
            while (true)
            {
                Console.WriteLine("Enter Username");
                username = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter Password");
                password = Console.ReadLine();
                Console.Clear();

                foreach (User item in UsList)
                {
                    if (item.Enter(username, password))
                    {
                        Us = item;
                        b = true;
                        break;
                    }
                }
                if (b)
                    break;
                Console.WriteLine("Incorrect username or password");
            }
        }
        private void AddContact()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine().Trim(' ');
            Console.Clear();
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine().Trim(' ');
            Console.Clear();
            List<string> phone = CreatPhone();
            List<string> emailaddress = CreateEmail();
            Us.Blok.AddContact(name, surname, phone, emailaddress);
        }
        private List<string> CreatPhone()
        {
            List<string> phone = new List<string>();
            string number;
            Console.WriteLine("Enter phone number");
            number = Console.ReadLine().Trim(' ');
            phone.Add(number);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add number : 1     Continue : 2");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    number = Console.ReadLine().Trim(' ');
                    phone.Add(number);
                }
                else if (key == ConsoleKey.NumPad2)
                    break;
            }
            return phone;
        }
        private List<string> CreateEmail()
        {
            List<string> emailaddress = new List<string>();
            string email;
            Console.WriteLine("Enter email address");
            email = Console.ReadLine().Trim(' ');
            emailaddress.Add(email);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add address : 1     Continue : 2");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    email = Console.ReadLine().Trim(' ');
                    emailaddress.Add(email);
                }
                else if (key == ConsoleKey.NumPad2)
                    break;
            }
            return emailaddress;
        }
        private void ChooseContact()
        {
            if (Us.Blok.ContList.Count == 0)
                return;
            int index;
            while (true)
            {
                Console.Clear();
                ShowBloknot();
                Console.WriteLine("Enter contact index");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    Console.Clear();
                    if (index < 1 || index > Us.Blok.ContList.Count)
                    {
                        Console.WriteLine("Incorrect index");
                    }
                    else
                        break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input : press enter for continue");
                    Console.ReadLine();
                }
            }
            ChooseContactAction(index - 1);
        }
        private void ChooseContactAction(int index)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Us.Blok.ContList[index].ToString());
                Console.WriteLine("Remove : 1   Edit : 2    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    RemoveContact(index);
                    break;
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    EditContact(index);
                    break;
                }
                else if (key == ConsoleKey.Escape)
                    break;
                Console.WriteLine("Incorrect input: press enter for continue");
                Console.ReadLine();
            }
        }
        private void RemoveContact(int index)
        {
            Us.Blok.ContList.RemoveAt(index);
        }
        private void EditContact(int index)
        {
            Contact current = Us.Blok.ContList[index];
            while (true)
            {
                Console.Clear();
                Console.WriteLine(current.ToString());
                Console.WriteLine("Name : 1    Surname : 2    Phone : 3    Email : 4    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    EditName(current);
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    EditSurname(current);
                }
                else if (key == ConsoleKey.NumPad3)
                {
                    EditPhone(current);
                }
                else if (key == ConsoleKey.NumPad4)
                {
                    EditEmail(current);
                }
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }
        private void EditName(Contact c)
        {
            Console.WriteLine("Enter a new name");
            c.Name = Console.ReadLine();
        }
        private void EditSurname(Contact c)
        {
            Console.WriteLine("Enter a new surname");
            c.Surname = Console.ReadLine();
        }
        private void EditPhone(Contact c)
        {
            while (true)
            {
                Console.Clear();
                ShowList(c.Phone);
                Console.WriteLine("Add : 1    Choose : 2    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Enter phone number");
                    c.AddPhone(Console.ReadLine());
                    break;
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    if (c.Phone.Count == 0)
                    {
                        Console.WriteLine("Empty : Press Enter for continue");
                        Console.ReadLine();
                        break;
                    }
                    Console.Clear();
                    ChooseIndex(c.Phone);
                    break;
                }
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }
        private void EditEmail(Contact c)
        {
            while (true)
            {
                Console.Clear();
                ShowList(c.Email);
                Console.WriteLine("Add : 1    Choose : 2    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Email");
                    c.AddEmail(Console.ReadLine());
                    break;
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    if (c.Phone.Count == 0)
                    {
                        Console.WriteLine("Empty : Press Enter for continue");
                        Console.ReadLine();
                        break;
                    }
                    Console.Clear();
                    ChooseIndex(c.Email);
                    break;
                }
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }
        private void EditFileFormat()
        {
            ConsoleKey key;
            string fileFormat;
            while (true)
            {
                Console.WriteLine("Choose file format\n");
                Console.WriteLine("XML : 1    JSON : 2");
                key = Console.ReadKey().Key;
                Console.Clear();

                if (key == ConsoleKey.NumPad1)
                {
                    fileFormat = "xml";
                    break;
                }
                if(key == ConsoleKey.NumPad2)
                {
                    fileFormat = "json";
                    break;
                }
            }
            EditFileFormat(fileFormat);
            Console.WriteLine("The format of the file is changed \nPress any key");
            Console.ReadKey();
        }
        private void EditFileFormat(string fileFormat)
        {
            if (fileFormat == Us.FileFormat)
                return;

            File.Delete($"D:Test\\Contacts\\{Us.Name}{Us.Surname}.{Us.FileFormat}");
            Us.FileFormat = fileFormat;
            Us.Blok.Save(Us);
            Save();
        }
        private void ChooseIndex(List<string> list)
        {
            int index;
            while (true)
            {
                Console.Clear();
                ShowList(list);
                Console.WriteLine("Enter index");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index < 1 || index > list.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($"Index {index} doesn't exist : press enter for continue");
                        Console.ReadLine();
                    }
                    else
                        break;
                }
                else
                    Console.WriteLine("Incorrect input");
            }
            ChooseIndexAction(list, index - 1);
        }
        private void ChooseIndexAction(List<string> list, int index)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(list[index]);
                Console.WriteLine("Remove : 1     Edit : 2    Exit : Esc");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.NumPad1)
                {
                    list.RemoveAt(index);
                    break;
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Enter edited version");
                    list[index] = Console.ReadLine();
                    break;
                }
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }
        private void ShowList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i + 1} : {list[i]}  ");
            }
            Console.WriteLine();
        }
        private void ShowBloknot()
        {
            Console.WriteLine($"{Us.Name}  {Us.Surname}\n");
            for (int i = 0; i < Us.Blok.ContList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Us.Blok.ContList[i].ToString()}");
            }
            Console.WriteLine();
        }
        public void Save()
        {
            using (FileStream fs = new FileStream("D:Test\\Contacts\\Users.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                xml.Serialize(fs, UsList);
            }
        }
        public List<User> LoadFromFile()
        {
            using (FileStream fs = new FileStream("D:Test\\Contacts\\Users.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    return new List<User>();

                XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                return (List<User>)xml.Deserialize(fs);
            }
        }
    }
}
