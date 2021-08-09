using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePattern.Demo
{
    public class User : IUser
    {
        private string name;

        private int age;

        private string address;

        public string Name { get { return name; } }

        public int Age { set { age = value; } }

        public string Address { get { return address; } }

        public User(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public object Clone()
        {
            return this.MemberwiseClone(); //Create the copy of the object
        }
    }
}
