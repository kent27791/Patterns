using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Decorator
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
            Console.WriteLine("Shape: Rectangle");
        }
    }
    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: Circle");
        }
    }
    #endregion
    #region Create abstract decorator class implementing the Shape interface.
    public abstract class ShapeDecorator : Shape 
    {
        protected Shape decoratedShape;
        public ShapeDecorator(Shape decoratedShape) 
        {
            this.decoratedShape = decoratedShape;
        }
        public virtual void Draw()
        {
            decoratedShape.Draw();
        }
    }
    #endregion
    #region Create concrete decorator class extending the ShapeDecorator class.
    public class RedShapeDecorator : ShapeDecorator 
    {
        public RedShapeDecorator(Shape decoratedShape)
            : base(decoratedShape)
        { 
        }
        public override void Draw() 
        {
            decoratedShape.Draw();
            setRedBorder(decoratedShape);
        }
        private void setRedBorder(Shape decoratedShape){
            Console.WriteLine("Border Color: Red");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle();
            Shape redCircle = new RedShapeDecorator(new Circle());

            Shape redRectangle = new RedShapeDecorator(new Rectangle());

            Console.WriteLine("-----Circle with normal border-----");
            circle.Draw();

            Console.WriteLine("-----Circle of red border-----");
            redCircle.Draw();

            Console.WriteLine("-----Rectangle of red border-----");
            redRectangle.Draw();

            Console.ReadKey();
        }
    }
}
