using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 命令上下文
    /// </summary>
    public interface ICmdContext : IConfiguration
    {
        /// <summary>
        /// 通过其它的形式来附加配置信息
        /// </summary>
        /// <param name="ext"></param>
        void AddCOnfig(IConfiguration ext);
    }
}
