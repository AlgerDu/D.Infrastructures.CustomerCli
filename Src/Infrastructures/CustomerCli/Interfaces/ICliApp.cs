using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 命令应用
    /// </summary>
    public interface ICliApp
    {
        /// <summary>
        /// 执行当前上下文对应的命令
        /// </summary>
        void Execute();
    }
}
