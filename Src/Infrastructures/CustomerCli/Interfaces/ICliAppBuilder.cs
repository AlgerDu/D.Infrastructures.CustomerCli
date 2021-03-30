using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// cli 应用构造器
    /// </summary>
    public interface ICliAppBuilder
    {
        /// <summary>
        /// 配置依赖注入
        /// </summary>
        /// <param name="configureDelegate"></param>
        /// <returns></returns>
        ICliAppBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);

        /// <summary>
        /// 构建
        /// </summary>
        /// <returns></returns>
        ICliApp Build();
    }
}
