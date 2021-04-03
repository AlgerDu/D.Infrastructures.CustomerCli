using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 一个线程安全的控制台输出
    /// </summary>
    public class ConsoleOutput : IConsoleOutput
    {
        /// <inheritdoc/>
        public void Write(string format, params object[] args)
        {
            lock (this)
            {
                Console.WriteLine(format, args);
            }
        }
    }
}
