using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Interpreter
{
    //Create an expression interface.
    public interface Expression
    {
        bool interpret(String context);
    }
    //Create concrete classes implementing the above interface.
    public class TerminalExpression : Expression
    {
        private String data;
        public TerminalExpression(String data)
        {
            this.data = data;
        }
        public bool interpret(string context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }

    public class OrExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;
        public OrExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool interpret(string context)
        {
            return expr1.interpret(context) || expr2.interpret(context);
        }
    }
    public class AndExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool interpret(string context)
        {
            return expr1.interpret(context) && expr2.interpret(context);
        }
    }
    class Program
    {
        //Rule: Robert and John are male
        public static Expression getMaleExpression()
        {
            Expression robert = new TerminalExpression("Robert");
            Expression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }
        //Rule: Julie is a married women
        public static Expression getMarriedWomanExpression()
        {
            Expression julie = new TerminalExpression("Julie");
            Expression married = new TerminalExpression("Married");
            return new AndExpression(julie, married);
        }
        static void Main(string[] args)
        {
            Expression isMale = getMaleExpression();
            Expression isMarriedWoman = getMarriedWomanExpression();

            Console.WriteLine("John is male? " + isMale.interpret("John"));
            Console.WriteLine("Julie is a married women? " + isMarriedWoman.interpret("Married Julie"));

            Console.ReadKey();
        }
    }
}
