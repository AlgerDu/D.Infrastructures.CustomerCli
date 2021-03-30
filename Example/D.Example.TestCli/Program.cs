using D.Infrastructures.CustomerCli;
using System;

namespace D.Example.TestCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new DefaultCliAppBuilder(args)
                .UseCustomerCliCore()
                .BuildDefaultApp();

            app.Execute();
        }
    }
}
