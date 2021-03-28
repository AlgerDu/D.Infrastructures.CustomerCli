using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 命令
    /// </summary>
    public interface ICmd
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="context"></param>
        void Execute(ICmdContext context);
    }
}
