using D.Utils;
using System;

namespace Test.Linux
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new InnerCmd() { Arguments = "pwd" };

            var success = new LinuxInnerCmdExecutor().Execute(cmd);

            Console.WriteLine(cmd.Output);
        }
    }
}
