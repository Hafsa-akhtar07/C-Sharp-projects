// See https://aka.ms/new-console-template for more information

using System;
namespace Program
{
    internal class CustomerDAL
    {
        public void AddCustomer(Customer c)
        {

            FileStream f = new FileStream("customers.txt", FileMode.Append);
            StreamWriter fn = new StreamWriter(f);
            string data = $"{c.Name},{c.Phone}";
            fn.WriteLine(data);
            fn.Close();
            f.Close();



        }
        public List<Customer> GetAll()
        {
            FileStream f = new FileStream("customers.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);
            string data = sr.ReadLine();
            List<Customer> list = new List<Customer>();
            while (data != null)
            {
                string[] customer = data.Split(",");
                Customer c = new Customer();
                c.Name = customer[0];
                c.Phone = customer[1];
                list.Add(c);
                data = sr.ReadLine();


            }
            return list;
        }
    }
}