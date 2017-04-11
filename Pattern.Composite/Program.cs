using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Composite
{
    #region Create Employee class having list of Employee objects.
    public class Employee 
    {
        public Employee()
        {
            this.Subordinates = new List<Employee>();
        }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public List<Employee> Subordinates { get; set; }

        public void Add(Employee employee) 
        {
            Subordinates.Add(employee);
        }
        public void Remove(Employee employee)
        {
            Subordinates.Remove(employee);
        }

        public override string ToString()
        {
            return "Employee :[ Name : " + Name + ", Dept : " + Department + ", Salary :" + Salary + " ]";
        }

    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Employee CEO = new Employee { Name = "John", Department = "CEO", Salary = 30000};

            Employee headSales = new Employee { Name = "Robert", Department = "Head Sales", Salary = 20000 };

            Employee headMarketing = new Employee { Name = "Michel", Department = "Head Marketing", Salary = 20000 };

            Employee clerk1 = new Employee { Name = "Laura", Department = "Marketing", Salary = 10000 };
            Employee clerk2 = new Employee { Name = "Bob", Department = "Marketing", Salary = 10000 };

            Employee salesExecutive1 = new Employee{ Name = "Richard", Department = "Sales", Salary = 10000 };
            Employee salesExecutive2 = new Employee{ Name = "Rob", Department = "Sales", Salary = 10000 };

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            Console.WriteLine("--------CEO---------");
            Console.WriteLine(CEO);
            foreach (Employee headerEmp in CEO.Subordinates)
            {
                Console.WriteLine("--------Header---------");
                Console.WriteLine(headerEmp);
                Console.WriteLine("--------Emp---------");
                foreach (var emp in headerEmp.Subordinates)
                {
                    
                    Console.WriteLine(emp);
                }
            }
            Console.ReadKey();
        }
    }
}
