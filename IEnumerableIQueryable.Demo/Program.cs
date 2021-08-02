using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableIQueryable.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enumerable is an interface that exposes an enumerator. 
            // And an enumerator is used for iteration of a generic collection (or array). 
            // The class that implements IEnumerable is responsible for exposing the enumerator and providing its implementation.

            // IQueryable interface on the other hand, is intended to be implemented by data providers. 
            // IQueryable provides functionality to execute queries against a specific data source. 
            // And IQueryable is derived from IEnumerable.

            // Data access ORM (Object Relational Mapper) framework like Entity Framework Core exposes the implementation of IQueryable.

            var context = new EmployeeContext("Data Source=localhost; Initial Catalog=AdvancedDemo; User Id=SA; Password=yourStrong(!)Password;");

            //IEnumerable<Employee> employees = context.Employees
            //    .Where(e => e.Id > 1);

            IQueryable<Employee> employees = context.Employees
                .Where(e => e.Id > 1);

            var topEmployees = employees.Take(2);

            foreach (var employee in topEmployees)
            {
                Console.WriteLine($"Name - {employee.FirstName} {employee.LastName}");
            }
        }
    }
}
