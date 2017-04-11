using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Observer
{
    #region Create Subject class.
    public class Subject 
    {
        private List<Observer> observers = new List<Observer>();
        private int state;
        public int getState() 
        {
            return this.state;
        }
        public void setState(int state) 
        {
            this.state = state;
            notifyAllObservers();

        }
        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (var observer in observers)
            {
                observer.update();
            }
        } 	
    }
    #endregion
    #region Create Observer class.
	public abstract class Observer {
       protected Subject subject;
       public abstract void update();
    }	 
	#endregion

    #region Create concrete observer classes
    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Binary String: {0}", Convert.ToString(subject.getState(), 2)); 
        }
    }
    public class OctalObserver  : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Octal String: {0}", Convert.ToString(subject.getState(), 8));
        }
    }
    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Hexa String: {0}", Convert.ToString(subject.getState(), 16));
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);

            Console.WriteLine("First state change: 15");
            subject.setState(15);
            Console.WriteLine("Second state change: 10");
            subject.setState(10);

            Console.ReadKey();
        }
    }
}
