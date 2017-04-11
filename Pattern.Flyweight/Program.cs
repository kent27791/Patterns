using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Flyweight
{
    #region Create an interface.
    public interface Shape 
    {
        void Draw();
    }
    #endregion
    #region Create concrete class implementing the same interface.
    public class Circle : Shape 
    {
        public Circle(string color) 
        {
            this.Color = color;
        }
        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public void Draw()
        {
            Console.WriteLine("Circle: Draw() - Color : {0}, X : {1}, Y : {2}, Radius : {3}", Color, X, Y, Radius);
        }
    }
    #endregion

    #region Create a Factory to generate object of concrete class based on given information.
    public class ShapeFactory 
    {
        private static Dictionary<string, Shape> circleMap = new Dictionary<string, Shape>();
        public static Shape getCircle(string color) 
        {
            Circle circle = (Circle)circleMap.SingleOrDefault(k => k.Key == color).Value;
            if (circle == null) 
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }
    #endregion
    class Program
    {
        private static string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black" };

        private static Random rand = new Random();

        private static string getRandomColor()
        {
            return colors[rand.Next(colors.Length)];
        }

        private static int getRandomX()
        {
            return rand.Next(100);
        }

        private static int getRandomY()
        {
            return rand.Next(100);
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Circle circle = (Circle)ShapeFactory.getCircle(getRandomColor());
                circle.X = getRandomX();
                circle.Y = getRandomY();
                circle.Radius = 100;
                circle.Draw();
            }
            Console.ReadKey();
        }
    }
}
