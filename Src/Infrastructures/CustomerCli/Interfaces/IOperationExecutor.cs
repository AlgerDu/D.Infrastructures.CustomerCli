using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 执行一个自定义的操作，里面包含一系列的命令
    /// </summary>
    public interface IOperationExecutor
    {
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="code"></param>
        /// <param name="scope"></param>
        void Execute(string code, IConfiguration scope);
    }
}
