using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Proxy
{
    #region Create an interface.
    public interface Image 
    {
        void Display();
    }
    #endregion

    #region Create concrete classes implementing the same interface.
    public class RealImage : Image 
    {
        private string filename;
        public RealImage(string filename) 
        {
            this.filename = filename;
            LoadFromDisk(filename);
        }
        private void LoadFromDisk(string filename) 
        {
            Console.WriteLine("Loading {0}", filename);
        }
        public void Display()
        {
            Console.WriteLine("Displaying " + filename);
        }
    }
    public class ProxyImage : Image 
    {
        private RealImage realImage;
        private string filename;
        public ProxyImage(string filename) 
        {
            this.filename = filename;
        }
        public void Display()
        {
            if (realImage == null) 
            {
                realImage = new RealImage(filename);
            }
            realImage.Display();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Image image = new ProxyImage("test_10mb.jpg");

            //image will be loaded from disk
            image.Display();
            Console.WriteLine("");
            //image will not be loaded from disk
            image.Display();

            Console.ReadKey();
        }
    }
}
