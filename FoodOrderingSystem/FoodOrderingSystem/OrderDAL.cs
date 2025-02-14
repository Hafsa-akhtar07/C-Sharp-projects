using System;

namespace Program
{
    internal class OrderDAL
    {
        public void Add(OrderProcessing order)
        {
            using (StreamWriter fr = new StreamWriter("order.txt", true)) 
            {
                string itemNames = "";
                foreach (Item i in order.Items)
                {
                    itemNames += i.Name + " "; 
                }

                string data = $"{order.Cname},{order.Total},{itemNames.Trim()}";
                fr.WriteLine(data);
            }
        }

        public List<OrderProcessing> Get()
        {
            List<OrderProcessing> list = new List<OrderProcessing>();

            if (!File.Exists("order.txt"))
                return list; // Return empty list if file doesn't exist

            using (StreamReader fr = new StreamReader("order.txt"))
            {
                string data;
                while ((data = fr.ReadLine()) != null)
                {
                    string[] orders = data.Split(",");
                    if (orders.Length < 3) continue; // Skip invalid lines

                    OrderProcessing order = new OrderProcessing
                    {
                        Cname = orders[0],
                        Total = orders[1],
                        Items = new List<Item>()
                    };

                    string[] itemNames = orders[2].Split(" ");
                    foreach (string name in itemNames)
                    {
                        if (!string.IsNullOrWhiteSpace(name))
                            order.Items.Add(new Item { Name = name });
                    }

                    list.Add(order);
                }
            }
            return list;
        }
    }
}
