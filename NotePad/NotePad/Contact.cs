using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    public class Contact : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Phone { get; set; }
        public List<string> Email { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname}    {string.Join(", ",Phone.ToArray())}    {string.Join(", ", Email.ToArray())}";
        }
        public Contact()
        {

        }
        public Contact(string name, string surname, List<string> phone, List<string> email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
        }
        public void AddPhone(string phone)
        {
            Phone.Add(phone);
        }
        public void AddEmail(string email)
        {
            Email.Add(email);
        }
        public Contact Edit(string name, string surname, List<string> phone, List<string> email)
        {
            return new Contact(name, surname, phone, email);
        }
        public int CompareTo(object obj)
        {
            Contact c = (Contact)obj;
            if(c != null)
            {
                return -$"{c.Name}{c.Surname}".CompareTo($"{Name}{Surname}");
            }

            throw new Exception("Your object is not a contact!!!");
        }
        
    }
}
