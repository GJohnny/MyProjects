using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NotePad
{
    public class Bloknot
    {
        public List<Contact> ContList { get; set; }


        public void AddContact(string name, string surname, List<string> phone, List<string> email)
        {
            ContList.Add(new Contact(name, surname, phone, email));
            ContList.Sort();
        }
        public void RemoveContact(int index)
        {
            if (index < 1 || index > ContList.Count)
                throw new IndexOutOfRangeException($"Index {index} doesn't exist");
            ContList.RemoveAt(index - 1);
        }
        public void Save(User us)
        {
            using (StreamWriter writer = new StreamWriter($"D:Test\\Contacts\\{us.Name}{us.Surname}.{us.FileFormat}"))
            {
                if (us.FileFormat == "json")
                {
                    writer.WriteLine(JsonConvert.SerializeObject(ContList));

                }
                else
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                    xml.Serialize(writer, ContList);
                }

            }
        }
        public static List<Contact> Load(User us)
        {
            string contacts;

            using (FileStream fs = new FileStream($"D:Test\\Contacts\\{us.Name}{us.Surname}.{us.FileFormat}",
                                                  FileMode.OpenOrCreate,FileAccess.Read,FileShare.Read))
            {
                contacts = File.ReadAllText(fs.Name);
                if (contacts.Length == 0)
                    return new List<Contact>();

                if (us.FileFormat == "xml")
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                    return (List<Contact>)xml.Deserialize(fs);
                }

                return JsonConvert.DeserializeObject<List<Contact>>(contacts);
            }
        }
        public List<Contact> Search(string name)
        {
            List<Contact> list = new List<Contact>();
            for (int i = 0; i < ContList.Count; i++)
            {
                if (name == ContList[i].Name)
                    list.Add(ContList[i]);
            }
            return list;
        }
    }
}
