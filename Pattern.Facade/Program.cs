using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Facade
{
    #region Create an interface.
    public interface Shape 
    {
        void Draw();
    }
    #endregion

    #region Create concrete classes implementing the same interface.
    public class Rectangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle::draw()");
        }
    }
    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Square::draw()");
        }
    }
    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Circle::draw()");
        }
    }
    #endregion

    #region Create a facade class.
    public class ShapeMaker 
    {
        private Shape circle;
        private Shape rectangle;
        private Shape square;
        public ShapeMaker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }
        public void DrawCircle()
        {
            circle.Draw();
        }
        public void DrawRectangle()
        {
            rectangle.Draw();
        }
        public void DrawSquare()
        {
            square.Draw();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            ShapeMaker shapeMaker = new ShapeMaker();
            shapeMaker.DrawCircle();
            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();

            Console.ReadKey();
        }
    }
}
