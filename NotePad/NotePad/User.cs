using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NotePad
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FileFormat { get; set; }
        [XmlIgnoreAttribute]
        [JsonIgnore]
        public Bloknot Blok { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname} {Username} {Password}";
        }
        public User()
        {
            Blok = new Bloknot();
        }
        public User(string name, string surname, string username, string password, string fileFormat)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            FileFormat = fileFormat;
            Blok = new Bloknot();
        }
        public bool Enter(string log, string pass)
        {
            return log == Username && pass == Password ? true : false;
        }
    }
}
