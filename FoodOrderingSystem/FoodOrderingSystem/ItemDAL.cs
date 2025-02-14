// See https://aka.ms/new-console-template for more information

using System;
namespace Program
{
    internal class ItemDAL
    {
        public void AddItem(Item x)
        {

            FileStream f = new FileStream("items.txt", FileMode.Append);
            StreamWriter fn = new StreamWriter(f);
            string data = $"{x.Name},{x.Price}";
            fn.WriteLine(data);
            fn.Close();
            f.Close();



        }
        public List<Item> GetAll()
        {
            FileStream f = new FileStream("items.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(f);
                string data = sr.ReadLine();
            List<Item> list = new List<Item>();
            while (data != null)
            {
                string[] items = data.Split(",");
                Item it = new Item();
                it.Name = items[0];
                it.Price = items[1];
                list.Add(it);
                data = sr.ReadLine();


            }
            return list;
        }
    }
}