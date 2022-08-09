using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выведите платёжные ссылки для трёх разных систем платежа: 
            //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}

            var order = new Order(4, 1200);
            var system1 = new System1();
            var system2 = new System2();
            var system3 = new System3();

            Console.WriteLine(system1.GetPayingLink(order));
            Console.WriteLine(system2.GetPayingLink(order));
            Console.WriteLine(system3.GetPayingLink(order));
        }
    }

    public class Order
    {
        public readonly int Id;
        public readonly int Amount;

        public Order(int id, int amount) => (Id, Amount) = (id, amount);
    }

    public interface IPaymentSystem
    {
        public string GetPayingLink(Order order);
    }

    public class System1 : IPaymentSystem
    {
        private string _link = "pay.system1.ru/order?";

        public string GetPayingLink(Order order)
        {
            return $"{_link}amount={order.Amount}RUB&hash={order.Id}";
        }
    }

    public class System2 : IPaymentSystem
    {
        private string _link = "order.system2.ru/pay?";

        public string GetPayingLink(Order order)
        {
            return $"{_link}hash={order.Amount}{order.Id}";
        }
    }

    public class System3 : IPaymentSystem
    {
        private string _link = "system3.com/pay?";
        private int _secretKey = 24;

        public string GetPayingLink(Order order)
        {
            return $"{_link}amount={order.Amount}&curency=RUB&hash={order.Id + _secretKey}";
        }
    }
}