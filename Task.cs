using System;

namespace IMJunior
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            IPaymentSystem paymentHandler = null;

            var systemId = orderForm.ShowForm();

            if (systemId == "QIWI")
                paymentHandler = new QIWI();
            else if (systemId == "WebMoney")
                paymentHandler = new WebMoney();
            else if (systemId == "Card")
                paymentHandler = new Card();

            if (paymentHandler != null)
            {
                paymentHandler.Transfer();
                paymentHandler.ShowPaymentResult();
            }
            else
            {
                Console.WriteLine("Несуществующая платёжная система");
            }
        }
    }

    public interface IPaymentSystem
    {
        public void Transfer();

        public void ShowPaymentResult();
    }

    public class QIWI : IPaymentSystem
    {
        public void ShowPaymentResult()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
        }

        public void Transfer()
        {
            Console.WriteLine($"Вы оплатили с помощью QIWI");
            Console.WriteLine("Проверка платежа через QIWI...");
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class WebMoney : IPaymentSystem
    {
        public void ShowPaymentResult()
        {
            Console.WriteLine("Перевод на страницу WebMoney...");
        }

        public void Transfer()
        {
            Console.WriteLine($"Вы оплатили с помощью WebMoney");
            Console.WriteLine("Проверка платежа через WebMoney...");
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class Card : IPaymentSystem
    {
        public void ShowPaymentResult()
        {
            Console.WriteLine("Перевод на страницу Card...");
        }

        public void Transfer()
        {
            Console.WriteLine($"Вы оплатили с помощью Card");
            Console.WriteLine("Проверка платежа через Card...");
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

            //симуляция веб интерфейса
            Console.WriteLine("Какое системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }
}