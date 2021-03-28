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
        void AddConfig(IConfiguration add);

        IServiceProvider Services { get; }
    }
}
