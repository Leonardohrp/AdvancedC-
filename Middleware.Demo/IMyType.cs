using System;

namespace Middleware.Demo
{
    public interface IMyType
    {
        public void Print();
    }

    public class MyType : IMyType
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }
    }
}