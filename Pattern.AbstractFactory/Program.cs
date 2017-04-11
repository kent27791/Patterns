using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.AbstractFactory
{
    #region Create an interface for Shapes and for Colors.
    public interface IShape 
    {
        void draw();
    }
    public interface IColor 
    {
        void fill();
    }
    #endregion

    #region Create concrete classes implementing the same interface.
    //concrete for shape
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
    //concrete for color
    public class Red : IColor 
    {
        public void fill()
        {
            Console.WriteLine("Inside Red::fill() method.");
        }
    }
    public class Blue : IColor
    {
        public void fill()
        {
            Console.WriteLine("Inside Blue::fill() method.");
        }
    }
    public class Green : IColor
    {
        public void fill()
        {
            Console.WriteLine("Inside Green::fill() method.");
        }
    }
    #endregion

    #region Create an Abstract class to get factories for Color and Shape Objects.
    public abstract class AbstractFactory 
    {
        public abstract IShape getShape(string shape);
        public abstract IColor getColor(string color);
    }
    #endregion

    #region Create Factory classes extending AbstractFactory to generate object of concrete class based on given information.
    public class ShapeFactory : AbstractFactory 
    {
        public override IShape getShape(string shape) 
        {
            if (shape == null)
            {
                return null;
            }
            if (shape.Equals("Circle"))
            {
                return new Circle();
            }
            else if (shape.Equals("Square"))
            {
                return new Rectangle();
            }
            else if (shape.Equals("Rectangle"))
            {
                return new Square();
            }
            return null;
        }
        public override IColor getColor(string color)
        {
            return null;
        }
    }
    public class ColorFactory : AbstractFactory 
    {
        public override IShape getShape(string shape)
        {
            return null;
        }
        public override IColor getColor(string color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.Equals("Red"))
            {
                return new Red();
            }
            else if (color.Equals("Blue"))
            {
                return new Blue();
            }
            else if (color.Equals("Green"))
            {
                return new Green();
            }
            return null;
        }
    }
    #endregion

    #region Create a Factory generator/producer class to get factories by passing an information such as Shape or Color
    public class FactoryProducer 
    {
        public static AbstractFactory getFactory(string choice) 
        {
            if (choice.Equals("Shape")) 
            {
                return new ShapeFactory();
            }
            else if (choice.Equals("Color")) 
            {
                return new ColorFactory();
            }
            return null;
        }
    }
    #endregion

    #region Use the FactoryProducer to get AbstractFactory in order to get factories of concrete classes by passing an information such as type.
    class Program
    {
        static void Main(string[] args)
        {
            //get shape factory
            AbstractFactory shapeFactory = FactoryProducer.getFactory("Shape");
            //get an object of Shape Circle
            IShape shape1 = shapeFactory.getShape("Circle");
            shape1.draw();

            //get shape factory
            AbstractFactory colorFactory = FactoryProducer.getFactory("Color");
            //get an object of Color Red
            IColor color1 = colorFactory.getColor("Red");
            color1.fill();

            Console.ReadKey();
        }
    }
    #endregion
}
