using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Factory
{
    #region Create an interface.
    public interface IShape 
    {
        void draw();
    }
    #endregion

    #region Create concrete classes implementing the same interface.
    public class Circle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }
    public class Square : IShape
    {
        public void draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }
    public class Rectangle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    #endregion

    #region Create a Factory to generate object of concrete class based on given information.
    public class ShapeFactory 
    {
        public IShape getShape(string shapeType) 
        {
            if (shapeType == null) 
            {
                return null;
            }
            if (shapeType.Equals("Circle")) 
            {
                return new Circle();
            }
            else if (shapeType.Equals("Square")) 
            {
                return new Square();
            }
            else if (shapeType.Equals("Rectangle")) 
            {
                return new Rectangle();
            }
            return null;
        }
    }
    #endregion

    #region Use the Factory to get object of concrete class by passing an information such as type.
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shape1 = shapeFactory.getShape("Circle");
            shape1.draw();

            IShape shape2 = shapeFactory.getShape("Square");
            shape2.draw();

            IShape shape3 = shapeFactory.getShape("Rectangle");
            shape3.draw();

            Console.ReadLine();
        }
    }
    #endregion
}
