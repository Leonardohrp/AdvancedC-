using System;

namespace IDisposable.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var serviceProxy = new ServiceProxy(null);

            serviceProxy.Get();
            // Do something
            serviceProxy.Post("");
            // Other code
        }
    }
}
