using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 提供收集好的命令
    /// </summary>
    public interface ICmdProvider
    {
        /// <summary>
        /// 支持的命令
        /// </summary>
        IDictionary<string, Type> Supports { get; }
    }
}
