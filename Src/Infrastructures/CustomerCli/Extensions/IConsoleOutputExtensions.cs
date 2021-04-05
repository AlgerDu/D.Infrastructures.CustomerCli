using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    public static class IConsoleOutputExtensions
    {
        public static IConsoleOutput BeginScope(this IConsoleOutput output)
        {
            output.ScopeLevel++;

            return output;
        }

        public static IConsoleOutput EndScope(this IConsoleOutput output)
        {
            output.ScopeLevel--;

            return output;
        }

        public static IConsoleOutput NewLine(this IConsoleOutput output)
        {
            output.WriteLine("");

            return output;
        }
    }
}
