using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 控制台输出
    /// </summary>
    public interface IConsoleOutput
    {
        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Write(String format, params object[] args);
    }
}
