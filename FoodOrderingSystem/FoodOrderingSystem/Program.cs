using System;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (i > 0)
            {
                Console.WriteLine("Food Ordering System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Item");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. See Customers");
                Console.WriteLine("5. Item Menu");
                Console.WriteLine("6. Order History");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose what you want: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {

                    Console.WriteLine("Customer's Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Customer's Phone Number: ");
                    string phone = Console.ReadLine();
                    Customer cus = new Customer();
                    cus.Name = name;
                    cus.Phone = phone;
                    CustomerDAL c = new CustomerDAL();
                    c.AddCustomer(cus);

                }
                else if (option == 2)
                {
                    Console.WriteLine("Item's Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Item's Price: ");
                    string price = Console.ReadLine();
                    Item it = new Item();
                    it.Name = name;
                    it.Price = price;
                    ItemDAL x = new ItemDAL();
                    x.AddItem(it);
                }
                else if (option == 3)
                {
                    ItemDAL it = new ItemDAL();
                    List<Item> iList = it.GetAll();
                    foreach (Item items in iList)
                    {
                        Console.WriteLine($"{items}");
                    }
                    Console.WriteLine("Customer's Name: ");
                    string n = Console.ReadLine();
                    Customer cus = new Customer();
                    cus.Name = n;
                    Console.WriteLine("How many items you want: ");
                    int ni = int.Parse(Console.ReadLine());
                    List<Item> list = new List<Item>();
                    while (ni > 0)
                    {
                        Console.WriteLine("Item's Name: ");
                        string iname = Console.ReadLine();
                        if (Item.GetByNames(iname))
                        {
                            Item y = new Item();
                            y.Name = iname;
                            list.Add(y);
                        }
                        else
                        {
                            Console.WriteLine("This item is not Available.");
                        }
                        ni--;
                    }
                    OrderProcessing op = new OrderProcessing();
                    op.order(cus, list);
                }
                else if (option == 4)
                {
                    CustomerDAL cus = new CustomerDAL();
                    List<Customer> cList = cus.GetAll();
                    foreach (Customer c in cList)
                    {
                        Console.WriteLine($"{c}");
                    }

                }
                else if (option == 5)
                {
                    ItemDAL it = new ItemDAL();
                    List<Item> iList = it.GetAll();
                    foreach (Item items in iList)
                    {
                        Console.WriteLine($"{items}");
                    }

                }
                else if (option == 6)
                {
                    Console.WriteLine("Order History...");
                    OrderProcessing.print();

                }
                else if (option == 7)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    break;
                }
            }


        }


    }
}