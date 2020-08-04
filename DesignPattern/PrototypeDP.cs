using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class PrototypeDP
    {
        public static void Demo()
        {
            PrototypeEmployee emp1 = new PrototypeEmployee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.Address = new Address() { address = "Toronto" };

            PrototypeEmployee emp2 = emp1.Clone();
            emp2.Name = "Pranaya";
            emp2.Address.address = "Oakville";

            emp1.DateOfBirth = DateTime.Now;

            Console.WriteLine("Emplpyee 1: ");
            ShowProperties(emp1);
            Console.WriteLine("Emplpyee 2: ");
            ShowProperties(emp2);

            void ShowProperties(PrototypeEmployee e)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(nameof(e.Name) + ": ");
                sb.Append(e.Name + ",  ");
                sb.Append(nameof(e.Department) + ": ");
                sb.Append(e.Department + ",  ");
                sb.Append(nameof(e.DateOfBirth) + ": ");
                sb.Append(e.DateOfBirth + ",  ");
                sb.Append(nameof(e.Address) + ": ");

                sb.Append(e.Address.address + ",  ");

                Console.WriteLine(sb.ToString());
            }

        }
    }

    public class PrototypeEmployee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }

        public PrototypeEmployee Clone()
        {
            //return PrototypeShallowClone();
            return PrototypeDeepClone();
        }

        public PrototypeEmployee PrototypeShallowClone()
        {
            //PrototypeEmployee temp = new PrototypeEmployee();
            //temp.Name = this.Name;
            //temp.Department = this.Department;
            //temp.Address = this.Address;
            // return temp;

            PrototypeEmployee temp = (PrototypeEmployee)this.MemberwiseClone();
            return temp;
        }

        public PrototypeEmployee PrototypeDeepClone()
        {
            //PrototypeEmployee temp = new PrototypeEmployee();
            //temp.Name = this.Name;
            //temp.Department = this.Department;
            //temp.Address = new Address();
            //temp.Address.address = this.Address.address;
            //  return temp;

            PrototypeEmployee temp = (PrototypeEmployee)this.MemberwiseClone();
            temp.Address = this.Address.Clone();
            return temp;

        }

    }

    public class Address
    {
        public string address { get; set; }
        public Address Clone() {
            return (Address) this.MemberwiseClone();
        }
    }

}
