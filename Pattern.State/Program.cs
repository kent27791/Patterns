using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.State
{
    #region Create Context Class.
    public class Context
    {
        private State state;
        public Context()
        {
            this.state = null;
        }
        public void setState(State state)
        {
            this.state = state;
        }
        public State getState()
        {
            return this.state;
        }
    }
    #endregion

    #region Create an interface.
    public interface State
    {
        void doAction(Context context);
    }
    #endregion

    #region Create concrete classes implementing the same interface.
    public class StartState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Start State";
        }

    }
    public class StopState : State
    {

        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Stop State";
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);

            Console.WriteLine(context.getState().ToString());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.getState().ToString());

            Console.ReadKey();
        }
    }
}
