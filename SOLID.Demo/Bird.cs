using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Demo
{
    // LSP
    public class Bird
    {

    }

    public class FlyingBird: Bird
    {
        public void Fly() { }
    }

    public class Ostrich : Bird { }
    public class Piegon : FlyingBird { }
}
