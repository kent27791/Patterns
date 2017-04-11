using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.NullObject
{
    #region Create an abstract class.
    public abstract class AbstractCustomer 
    {
        protected string name;
        public abstract bool IsNil();
        public abstract string getName();
    }
    #endregion
    #region Create concrete classes extending the above class.
    public class RealCustomer : AbstractCustomer 
    {
        public RealCustomer(string name) 
        {
            this.name = name;
        }
        public override bool IsNil()
        {
            return false;
        }

        public override string getName()
        {
            return name;
        }
    }
    public class NullCustomer : AbstractCustomer 
    {
        public override bool IsNil()
        {
            return true;
        }

        public override string getName()
        {
            return "Not Available in Customer Database";
        }
    }
    #endregion
    #region Create CustomerFactory Class.
    public class CustomerFactory 
    {
        public static readonly string[] names = { "Rob", "Joe", "Julie" };
        public static AbstractCustomer getCustomer(string name) 
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name)) 
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCustomer customer1 = CustomerFactory.getCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.getCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.getCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.getCustomer("Laura");

            Console.WriteLine("Customers");
            Console.WriteLine(customer1.getName());
            Console.WriteLine(customer2.getName());
            Console.WriteLine(customer3.getName());
            Console.WriteLine(customer4.getName());

            Console.ReadKey();
        }
    }
}
