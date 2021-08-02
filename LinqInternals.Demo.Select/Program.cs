using System;
using System.Linq;

namespace LinqInternals.Demo.Select
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new[]
            {
                new Customer
                {
                    Name = "Leo",
                    Phones = new[]
                    {
                        new Phone
                        {
                            Number = "123",
                            PhoneType = PhoneType.Cell
                        },
                        new Phone
                        {
                            Number = "456",
                            PhoneType = PhoneType.Home
                        }
                    } 
                },
                new Customer
                {
                    Name = "Heitor",
                    Phones = new[]
                    {
                        new Phone
                        {
                            Number = "789",
                            PhoneType = PhoneType.Cell
                        },
                        new Phone
                        {
                            Number = "101",
                            PhoneType = PhoneType.Home
                        }
                    }
                }
            };

            var customerNames = customers.SelectMany(c => c.Name);
            var customerPhones = customers.SelectMany(c => c.Phones);

            foreach (var customer in customerPhones)
            {
                Console.WriteLine($"{customer.Number} - {customer.PhoneType}");
            }
        }
    }
}
