using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    public static class IConsoleOutputExtensions
    {
        public static void BeginScope(this IConsoleOutput output)
        {
            output.ScopeLevel++;
        }

        public static void EndScope(this IConsoleOutput output)
        {
            output.ScopeLevel--;
        }
    }
}
