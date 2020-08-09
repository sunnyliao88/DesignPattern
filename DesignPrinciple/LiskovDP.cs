using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPrinciple
{
    class LiskovDP
    {
        public static void Demo()
        {
            Console.WriteLine("--Followed");
            Apple item1 = new Orange();
            Console.WriteLine(item1.GetColor());
            Orange item2 = new Orange();
            Console.WriteLine(item2.GetColor());

            Console.WriteLine("\n--Not followed");
            Apple item3 = new Banana();
            Console.WriteLine(item3.GetColor());
            Banana item4 = new Banana();
            Console.WriteLine(item4.GetColor());
        }
    }


    public class Apple
    {
        public virtual string GetColor()
        {
            return "Apple";
        }
    }
    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
    public class Banana : Apple
    {
        public new string GetColor()
        {
            return "Banana";
        }
    }


}
