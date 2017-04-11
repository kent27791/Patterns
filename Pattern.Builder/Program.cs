using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Builder
{
    #region Create an interface Item representing food item and packing.
    public interface IItem 
    {
        string Name();
        IPacking Packing();
        float Price();
         
    }
    public interface IPacking
    {
        string Pack();
    }
    #endregion

    #region Create concreate classes implementing the Packing interface.
    public class Wrapper : IPacking 
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }
    public class Bottle : IPacking 
    {
        public string Pack()
        {
            return "Bottle";
        }
    }
    #endregion

    #region Create abstract classes implementing the item interface providing default functionalities
    public abstract class Burger : IItem 
    {
        public IPacking Packing() 
        {
            return new Wrapper();
        }
        public abstract float Price();

        public virtual string Name()
        {
            return null;
        }
    }
    public abstract class ColdDrink : IItem 
    {
        public IPacking Packing() 
        {
           return new Bottle();
        }
        public abstract float Price();

        public virtual string Name()
        {
            return null;
        }
    }
    #endregion

    #region Create concrete classes extending Burger and ColdDrink classes
    public class VegBurger : Burger 
    {
        public override float Price()
        {
            return 25.0f;
        }
        public override string Name() 
        {
            return "Veg Burger";
        }
    }
    public class ChickenBurger : Burger 
    {
        public override float Price()
        {
            return 50.5f;
        }
        public override string Name()
        {
            return "Chicken Burger";
        }
    }

    public class Coke : ColdDrink 
    {
        public override float Price()
        {
            return 30.0f;
        }
        public override string Name()
        {
            return "Coke";
        }
    }
    public class Pepsi : ColdDrink
    {
        public override float Price()
        {
            return 35.0f;
        }
        public override string Name()
        {
            return "Pepsi";
        }
    }
    #endregion

    #region Create a Meal class having Item objects defined above.
    public class Meal 
    {
        private List<IItem> items = new List<IItem>();
        public void AddItem(IItem item) 
        {
            items.Add(item);
        }
        public float GetCost() 
        {
            float cost = 0.0f;
            foreach (IItem item in items)
            {
                cost += item.Price();
            }
            return cost;
        }
        public void ShowItem() 
        {
            foreach (IItem item in items)
            {
                Console.WriteLine("Item : {0} - Packing : {1} - Price : {2}", item.Name(), item.Packing().Pack(), item.Price());
            }
        }
    }
    #endregion

    #region Create a MealBuilder class, the actual builder class responsible to create Meal objects.
    public class MealBuilder 
    {
        public Meal PrepareVegMeal() 
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }
        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }
    #endregion

    #region BuiderPatternDemo uses MealBuider to demonstrate builder pattern.
    class Program
    {
        static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();
            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItem();
            Console.WriteLine("Total Cost : {0}", vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("Non Veg Meal");
            nonVegMeal.ShowItem();
            Console.WriteLine("Total Cost : {0}", nonVegMeal.GetCost());

            Console.ReadKey();
        }
    }
    #endregion
}
