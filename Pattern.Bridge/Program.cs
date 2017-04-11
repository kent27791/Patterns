using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Bridge
{
    #region Create bridge implementer interface.
    public interface IDrawAPI 
    {
        void DrawCircle(int radius, int x, int y);
    }
    #endregion

    #region Create concrete bridge implementer classes implementing the DrawAPI interface.
    public class RedCircle : IDrawAPI 
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing circle. Color : {0} - Radius : {1} - X : {2} - Y : {3}", "Red", radius, x, y);
        }
    }
    public class GreenCircle : IDrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing circle. Color : {0} - Radius : {1} - X : {2} - Y : {3}", "Green", radius, x, y);
        }
    }
    #endregion

    #region Create an abstract class Shape using the DrawAPI interface.
    public abstract class Shape 
    {
        protected IDrawAPI drawAPI;
        //protected Shape(IDrawAPI drawAPI) 
        //{
        //    this.drawAPI = drawAPI;
        //}
        public abstract void Draw();
    }
    #endregion

    #region Create concrete class implementing the Shape interface.
    public class Circle : Shape 
    {
        private int radius, x, y;
        public Circle(int radius, int x, int y, IDrawAPI drawAPI)
        {
            base.drawAPI = drawAPI;
            this.radius = radius;
            this.x = x;
            this.y = y;
        }
        public override void Draw()
        {
            drawAPI.DrawCircle(radius, x, y);
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {

            Shape redCircle = new Circle(10, 100, 100, new RedCircle());
            Shape greenCircle = new Circle(10, 100, 100, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();

            Console.ReadKey();
        }
    }
}
