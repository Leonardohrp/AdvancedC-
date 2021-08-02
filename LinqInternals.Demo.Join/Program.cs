using System;
using System.Linq;

namespace LinqInternals.Demo.Join
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new[]
           {
                new Customer
                {
                    Id = 1,
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
                    Id = 2,
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

            var addresses = new[]
            {
                new Address{ Id = 1, CustomerId = 2, Street = "123 Street", City = "City1" },
                new Address{ Id = 2, CustomerId = 2, Street = "345 Street", City = "City2" }
            };

            var customerWhitAddress = customers.Join(addresses,
                c => c.Id,
                a => a.CustomerId,
                (c, a) => new { c.Name, a.Street, a.City });

            foreach (var customer in customerWhitAddress)
            {
                Console.WriteLine($"{customer.Name} - {customer.Street} - {customer.City}");
            }
        }
    }
}
