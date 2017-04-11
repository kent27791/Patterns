using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Prototype
{
    #region Create an abstract class implementing Clonable interface.
    public abstract class Shape : ICloneable 
    {
        private string id;
        protected string type;

        public abstract void draw();

        public string getType()
        {
            return type;
        }
        public string getId() 
        {
            return id;
        }
        public void setId(string id) 
        {
            this.id = id;
        }

        public object Clone()
        {
            object clone = null;
            try
            {
                clone = base.MemberwiseClone();
            }
            catch (Exception ex)
            {

            }
            return clone;
        }
    }
    #endregion

    #region Create concrete classes extending the above class.
    public class Rectangle : Shape 
    {
        public Rectangle()
        {
            type = "Rectangle";
        }
        public override void draw() 
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    public class Square : Shape
    {
        public Square()
        {
            type = "Square";
        }
        public override void draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }
    public class Circle : Shape
    {
        public Circle()
        {
            type = "Circle";
        }
        public override void draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }
    #endregion

    #region Create a class to get concreate classes from database and store them in a Hashtable.
    public class ShapeCache 
    {
        private static IDictionary<string, Shape> shapeMap = new Dictionary<string, Shape>();
        public static Shape getShape(string shapeId)
        {
            Shape cachedShape = shapeMap.SingleOrDefault(s => s.Key == shapeId).Value;
            return (Shape)cachedShape.Clone();
        }
        // for each shape run database query and create shape
        // shapeMap.put(shapeKey, shape);
        // for example, we are adding three shapes
        public static void loadCache()
        {
            Circle circle = new Circle();
            circle.setId("1");
            shapeMap.Add(circle.getId(), circle);

            Square square = new Square();
            square.setId("2");
            shapeMap.Add(square.getId(), square);

            Rectangle rectangle = new Rectangle();
            rectangle.setId("3");
            shapeMap.Add(rectangle.getId(), rectangle);
        }
    }
    #endregion

    #region PrototypePatternDemo uses ShapeCache class to get clones of shapes stored in a Hashtable.
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //          ShapeCache.loadCache();

    //          Shape clonedShape = (Shape) ShapeCache.getShape("1");
    //          Console.WriteLine("Shape : " + clonedShape.getType());		

    //          Shape clonedShape2 = (Shape) ShapeCache.getShape("2");
    //          Console.WriteLine("Shape : " + clonedShape2.getType());		

    //          Shape clonedShape3 = (Shape) ShapeCache.getShape("3");
    //          Console.WriteLine("Shape : " + clonedShape3.getType());

    //          Console.ReadKey();
    //    }
    //}
    #endregion
}
