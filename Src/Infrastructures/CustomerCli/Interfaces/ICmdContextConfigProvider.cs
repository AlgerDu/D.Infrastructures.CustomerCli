using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 通过不同的途径，读取或者设置配置，给上下文使用
    /// </summary>
    public interface ICmdContextConfigProvider
    {
        /// <summary>
        /// 获取 config
        /// </summary>
        /// <returns></returns>
        IConfiguration Get();
    }
}
