using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Mediator
{
    public class User
    {
        private String name;

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public User(String name)
        {
            this.name = name;
        }

        public void sendMessage(String message)
        {
            ChatRoom.showMessage(this, message);
        }
    }
    public class ChatRoom
    {
        public static void showMessage(User user, String message)
        {
            Console.WriteLine(DateTime.Now + " [" + user.getName() + "] : " + message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User robert = new User("Robert");
            User john = new User("John");

            robert.sendMessage("Hi! John!");
            john.sendMessage("Hello! Robert!");

            Console.ReadKey();
        }
    }
}
