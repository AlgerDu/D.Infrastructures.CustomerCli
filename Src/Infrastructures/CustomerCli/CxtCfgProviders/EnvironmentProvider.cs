using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 提供一些基础的环境参数
    /// </summary>
    public class EnvironmentProvider : ICmdContextConfigProvider
    {

        /// <inheritdoc/>
        public IConfiguration Get()
        {
            return new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "workDir", Directory.GetCurrentDirectory() }
                })
                .Build();
        }
    }

    /// <summary>
    /// 有关配置的一些读取
    /// </summary>
    public static class ICmdContextExtensions_Env
    {
        /// <summary>
        /// 获取命令码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetWorkDir(this ICmdContext context)
        {
            return context.GetSection("workDir").Get<string>();
        }
    }
}
