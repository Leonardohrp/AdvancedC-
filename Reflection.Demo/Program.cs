using System;
using System.Linq;
using System.Reflection;

namespace Reflection.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Reflection is a feature of.NET which helps reflect an assembly and its types.
            //We can use reflection to dynamically browse through all the types defined inside of an assembly. 

            //Apart from just browsing through the assembly for its types, we can also create an instance of the types inside of the assembly.
            //We use the Activator class for creating an instance from a type.

            //We can also invoke the methods, set properties, and fields using reflection.
            //One fundamental difference between calling methods using reflection compared to the normal way of creating a class and calling is the method, is that using reflection, we can even call the private methods.
            //We can even access private fields and properties using reflection.

            //Using reflection, we can call both static and instance members.

            var assembly = Assembly.LoadFrom(@"C:\Users\Leonardo Pinheiro\Desktop\Dev\7-AdvancedC#\LinqInternals.Demo\PrintAll\bin\Debug\netcoreapp3.1\PrintAll.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Type: {type.Name}");
                Console.WriteLine($"=======================");

                var instance = Activator.CreateInstance(type);

                foreach (var field in type.GetFields(BindingFlags.NonPublic | 
                    BindingFlags.Instance | 
                    BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($"Field: {field.Name}");
                    field.SetValue(instance, "Frodo");
                }
                Console.WriteLine($"=======================");

                foreach (var method in type.GetMethods(BindingFlags.Public |
                   BindingFlags.NonPublic |
                   BindingFlags.Instance |
                   BindingFlags.DeclaredOnly)
                    .Where(m => !m.IsSpecialName))
                {
                    Console.WriteLine($"Method: {method.Name}");
                    if(method.GetParameters().Length > 0)
                    {
                        method.Invoke(instance, new[] { "Bilbo" });
                    }
                    else if(method.ReturnType.Name != "Void")
                    {
                        var returnedValue = method.Invoke(instance, null);
                        Console.WriteLine($"Returned value from method: {returnedValue}");
                    }
                    else
                    {
                        method.Invoke(instance, null);
                    }

                }
                Console.WriteLine($"=======================");

                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine($"Property: {property.Name}");
                    var propertyValue = property.GetValue(instance);
                    Console.WriteLine($"Property valeu: {propertyValue}");
                }

            }
        }
    }
}
