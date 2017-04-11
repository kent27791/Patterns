using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Singleton
{
    #region Create a Singleton Class
    public class SingleObject 
    {
        //create an object of SingleObject
        public static SingleObject instance = new SingleObject();

        //make the constructor private so that this class cannot be
        //instantiated
        private SingleObject() { }

        //Get the only object available
        public static SingleObject getInstance() 
        {
            return instance;
        }
        public void ShowMessage()
        {
          Console.WriteLine("Hello World!");
        }
    }
    #endregion

    #region Get the only object from the singleton class.
    class Program
    {
        static void Main(string[] args)
        {
              //illegal construct
              //Compile Time Error: The constructor SingleObject() is not visible
              //SingleObject obj = new SingleObject();
              //Get the only object available
              SingleObject obj = SingleObject.getInstance();

              //show the message
              obj.ShowMessage();

              Console.ReadKey();
        }
    }
    #endregion
}
