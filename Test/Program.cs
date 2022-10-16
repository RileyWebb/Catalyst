using System;
using System.Threading;
using Catalyst;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Engine.Init();

            new Game().Start();
        }
    }
}
