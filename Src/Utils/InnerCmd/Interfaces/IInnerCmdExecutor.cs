using System;
using System.Collections.Generic;
using System.Text;

namespace D.Utils
{
    /// <summary>
    /// 内部命令执行者，不同的操作系统实现不同的
    /// </summary>
    public interface IInnerCmdExecutor
    {
        /// <summary>
        /// 使用命令行执行一个命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>执行过程是否成功</returns>
        bool Execute(IInnerCmd cmd);
    }
}
