// See https://aka.ms/new-console-template for more information

using System;
namespace Program
{
    internal class Item : System.Object
    {
        private string name;
        //private string iName;
        private string price;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;

            }
        }

        public override string ToString()
        {
            return $"{name},{price}";
        }

        public static Boolean GetByNames(string name)
        {
            ItemDAL it = new ItemDAL();
            List<Item> items = new List<Item>();
            items = it.GetAll();
            foreach (Item item in items)
            {
                if (item.Name == name)
                {
                    return true;
                    break;
                }
            }
            return false;
        }


    }

}
