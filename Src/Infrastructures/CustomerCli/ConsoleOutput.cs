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
        private int _scopeLevel = 0;
        private string _space;

        /// <inheritdoc/>
        public int ScopeLevel
        {
            get => _scopeLevel;
            set
            {
                lock (this)
                {
                    _scopeLevel = value < 0 ? 0 : value;

                    _space = new StringBuilder()
                        .Append(' ', _scopeLevel * 4)
                        .ToString();
                }
            }
        }

        /// <inheritdoc/>
        public void Write(string format, params object[] args)
        {
            lock (this)
            {
                Console.Write(PreHandle(format), args);
            }
        }

        /// <inheritdoc/>
        public void WriteLine(string format, params object[] args)
        {
            lock (this)
            {
                Console.WriteLine(PreHandle(format), args);
            }
        }

        private string PreHandle(string format)
        {
            return _space + format.Replace("{", "").Replace("}", "");
        }
    }
}
