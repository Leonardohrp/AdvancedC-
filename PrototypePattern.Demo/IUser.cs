using System;

namespace PrototypePattern.Demo
{
    public interface IUser : ICloneable
    {
        string Name { get; }
        int Age { set; }
        string Address { get; }
    }
}