using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Filter
{
    #region Create a class on which criteria is to be applied.
    public class Person 
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
    }
    #endregion
    #region Create an interface for Criteria.
    public interface ICriteria 
    {
        List<Person> meetCriteria(List<Person> persons);
    }
    #endregion
    #region Create concrete classes implementing the Criteria interface.
    public class CriteriaMale : ICriteria 
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //linq
            List<Person> malePersons = persons.Where(p => p.Gender.Equals("Male")).ToList();
            return malePersons;

            //List<Person> malePersons = new List<Person>();
            //foreach (Person person in persons)
            //{
            //    if (person.Gender.Equals("Male")) 
            //    {
            //        malePersons.Add(person);
            //    }
            //}
            //return malePersons;
        }
    }
    public class CriteriaFemale : ICriteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //linq
            List<Person> femalePersons = persons.Where(p => p.Gender.Equals("Female")).ToList();
            return femalePersons;
        }
    }
    public class CriteriaSingle : ICriteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //linq
            List<Person> singlePersons = persons.Where(p => p.MaritalStatus.Equals("Single")).ToList();
            return singlePersons;
        }
    }
    public class AndCriteria : ICriteria 
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.meetCriteria(persons);
            return otherCriteria.meetCriteria(firstCriteriaPersons);
        }
    }
    public class OrCriteria : ICriteria 
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.meetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);
            foreach (var person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person)) 
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name = "Robert", Gender = "Male", MaritalStatus = "Single" });
            persons.Add(new Person { Name = "John", Gender = "Male", MaritalStatus = "Married" });
            persons.Add(new Person { Name = "Laura", Gender = "Female", MaritalStatus = "Married" });
            persons.Add(new Person { Name = "Diana", Gender = "Female", MaritalStatus = "Single" });
            persons.Add(new Person { Name = "Mike", Gender = "Male", MaritalStatus = "Single" });
            persons.Add(new Person { Name = "Bobby", Gender = "Male", MaritalStatus = "Single" });

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males: ");
              printPersons(male.meetCriteria(persons));

              Console.WriteLine("\nFemales: ");
              printPersons(female.meetCriteria(persons));

              Console.WriteLine("\nSingle Males: ");
              printPersons(singleMale.meetCriteria(persons));

              Console.WriteLine("\nSingle Or Females: ");
              printPersons(singleOrFemale.meetCriteria(persons));

              Console.ReadKey();
        }
        public static void printPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine("Person : Name = {0}, Gender = {1}, Marital Status = {2}", person.Name, person.Gender, person.MaritalStatus);
            }
        }
    }
}
