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
        /// 作用域层级（前面的空格层级）
        /// </summary>
        int ScopeLevel { get; set; }

        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Write(String format, params object[] args);

        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void WriteLine(String format, params object[] args);
    }
}
