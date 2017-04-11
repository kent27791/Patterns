using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Template
{
    #region Create an abstract class with a template method being final.
    public abstract class Game 
    {
        public abstract void initialize();
        public abstract void startPlay();
        public abstract void endPlay();

        //template method
        public void play() 
        {
            initialize();

            startPlay();

            endPlay();
        }
    }
    #endregion

    #region Create concrete classes extending the above class.
    public class Cricket : Game 
    {
        public override void initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }

        public override void startPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }

        public override void endPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }
    }
    public class Football : Game 
    {
        public override void initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }

        public override void startPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }

        public override void endPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Cricket();
            game.play();
            Console.WriteLine();
            game = new Football();
            game.play();
            Console.ReadKey();
        }
    }
}
