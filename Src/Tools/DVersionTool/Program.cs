using D.Infrastructures.CustomerCli;
using System;

namespace DVersionTool
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
