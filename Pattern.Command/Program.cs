using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pattern.Command
{
    #region Create a command interface.
    public interface IOrder 
    {
        void Excute();
    }
    #endregion

    #region Create a request class
    public class Stock 
    {
        private string name = "ABC";
        private int quantity = 10;

        public void Buy() 
        {
            Console.WriteLine("Stock[Name : {0}, Quantity : {1}] bought", name, quantity);
        }
        public void Sell()
        {
            Console.WriteLine("Stock[Name : {0}, Quantity : {1}] sold", name, quantity);
        }
    }
    #endregion

    #region Create concrete classes implementing the Order interface.
    public class BuyStock : IOrder 
    {
        private Stock abcStock;
        public BuyStock(Stock stock) 
        {
            this.abcStock = stock;
        }

        public void Excute()
        {
            abcStock.Buy();
        }
    }
    public class SellStock : IOrder
    {
        private Stock abcStock;
        public SellStock(Stock stock)
        {
            this.abcStock = stock;
        }

        public void Excute()
        {
            abcStock.Sell();
        }
    }
    #endregion

    #region Create command invoker class.
    public class Broker 
    {
        private List<IOrder> orders = new List<IOrder>();
        public void TakeOrder(IOrder order) 
        {
            orders.Add(order);
        }
        public void PlaceOrders() 
        {
            foreach (var order in orders)
            {
                order.Excute();
            }
            orders.Clear();
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Stock abcStock = new Stock();
            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.PlaceOrders();

           

            Console.ReadKey();
        }
    }
}
