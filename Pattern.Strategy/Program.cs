using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Strategy
{
    #region Create an interface.
    public interface IStrategy 
    {
        int doOperation(int num1, int num2);
    }
    #endregion
    #region Create concrete classes implementing the same interface.
    public class OperationAdd : IStrategy 
    {
        public int doOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    public class OperationSubstract : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }
    public class OperationMultiply : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    #endregion

    #region Create Context Class.
    public class Context 
    {
        private IStrategy strategy;
        public Context(IStrategy strategy) 
        {
            this.strategy = strategy;
        }
        public int excuteStrategy(int num1, int num2) 
        {
            return strategy.doOperation(num1, num2);
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new OperationAdd());
            Console.WriteLine("{0} + {1} = {2}", 5, 10, context.excuteStrategy(5, 10));

            context = new Context(new OperationSubstract());
            Console.WriteLine("{0} - {1} = {2}", 5, 10, context.excuteStrategy(5, 10));

            context = new Context(new OperationMultiply());
            Console.WriteLine("{0} * {1} = {2}", 5, 10, context.excuteStrategy(5, 10));

            Console.ReadKey();
        }
    }
}
