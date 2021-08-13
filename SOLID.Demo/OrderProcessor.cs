using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Demo
{
    // Single Responsibility Principle (SRP)
    // Open/Closed Principle
    // Liskov Substitution Principle (LSP)
    // Interface Segregation Principle (ISP)
    // Dependency Inversion Principle

    public class OrderProcessor
    {
        private readonly IOrderValidator orderValidator;
        private readonly IOrderSaver[] orderSaver;
        private readonly IOrderNotificationSender orderNotificationSender;

        public OrderProcessor(IOrderValidator orderValidator, IOrderSaver[] orderSaver, IOrderNotificationSender orderNotificationSender)
        {
            this.orderValidator = orderValidator;
            this.orderSaver = orderSaver;
            this.orderNotificationSender = orderNotificationSender;
        }
        public void Process()
        {
            foreach (var item in orderSaver)
            {
                item.Save(null);
            }
            orderValidator.Validate();
            orderNotificationSender.SendNotificaition();
        }
    }

    public class OrderValidator : IOrderValidator
    {
        public void Validate() { }
    }

    public interface IOrderValidator
    {
        void Validate();
    }

    public interface IOrderSaver
    {
        void Save(string order);
    }

    public interface IOrderDeleter
    {
        void Delete(int id);
    }

    public interface IOrderReader
    {
        string Read(int id);
    }

    public class DborderSaver : IOrderSaver
    {
        public void Save(string order) { }
    }

    public class CacheOrderSaver : IOrderSaver
    {
        public void Save(string order) { }
    }

    public class OrderNotificationSender : IOrderNotificationSender
    {
        public void SendNotificaition() { }
    }

    public interface IOrderNotificationSender
    {
        void SendNotificaition();
    }
}
