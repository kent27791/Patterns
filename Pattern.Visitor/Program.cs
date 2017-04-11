using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Visitor
{
    #region Define an interface to represent element.
    public interface ComputerPart 
    {
       void accept(ComputerPartVisitor computerPartVisitor);
    }
    #endregion

    #region Create concrete classes extending the above class.
    public class Keyboard : ComputerPart 
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Mouse : ComputerPart
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Monitor : ComputerPart
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Computer : ComputerPart
    {
        ComputerPart[] parts;
        public Computer() 
        {
            parts = new ComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };
        }
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].accept(computerPartVisitor);
            }
            computerPartVisitor.visit(this);
        }
    }
    #endregion

    #region Define an interface to represent visitor.
    public interface ComputerPartVisitor
    {
        void visit(Computer computer);
        void visit(Mouse mouse);
        void visit(Keyboard keyboard);
        void visit(Monitor monitor);
    }
    #endregion

    #region Create concrete visitor implementing the above class.
    public class ComputerPartDisplayVisitor : ComputerPartVisitor 
    {

        public void visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }

        public void visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }

        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Keyboard.");
        }

        public void visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor.");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            ComputerPart computer = new Computer();
            computer.accept(new ComputerPartDisplayVisitor());

            Console.ReadKey();
        }
    }
}
