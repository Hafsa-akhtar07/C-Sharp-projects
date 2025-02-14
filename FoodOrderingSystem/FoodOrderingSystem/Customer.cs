// See https://aka.ms/new-console-template for more information

using System;
using System.Numerics;
namespace Program
{
    internal class Customer 
    {
        private string name;
        private string phone;
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
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;

            }
        }

        public override string ToString()
        {
            return $"{name},{phone}";
        }


    }

}
