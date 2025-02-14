using System;
using System.Collections.Generic;

namespace Program
{
    internal class OrderProcessing
    {
        private string cname;
        private string total;
        private List<Item> items;

        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }

        public string Total
        {
            get { return total; }
            set { total = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public override string ToString()
        {
            string itemDetails = "";
            foreach (Item i in items)
            {
                itemDetails += i.ToString() + " "; // Simple concatenation
            }
            return $"{cname}, {total}, {itemDetails}";
        }

        public static void print()
        {
            OrderDAL cd = new OrderDAL();
            List<OrderProcessing> orders = cd.Get();
            if (orders.Count == 0)
            {
                Console.WriteLine("No order yet.");
            }
            else
            {
                foreach (OrderProcessing order in orders)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        public void order(Customer c, List<Item> list)
        {
            OrderDAL od = new OrderDAL();
            OrderProcessing o = new OrderProcessing();
            o.Cname = c.Name;
            o.Items = list;
            o.Total = list.Count.ToString();
            od.Add(o);
        }
    }
}
