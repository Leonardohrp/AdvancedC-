using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEnumerableIQueryable.Demo
{
    public class EmployeeContext : DbContext
    {
        private readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(config => config.AddConsole());
        private readonly string connectionString;

        public EmployeeContext(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
