using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 收集操作系统的信息
    /// </summary>
    public class OsProvider : ICmdContextConfigProvider
    {
        ///<inheritdoc/>
        public IConfiguration Get()
        {
            var os = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = "win";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                os = "linux";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                os = "osx";
            }
            else
            {
                os = "unknown";
            }

            return new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "os", os }
                })
                .Build();
        }
    }

    /// <summary>
    /// 有关配置的一些读取
    /// </summary>
    public static class ICmdContextExtensions_OS
    {
        /// <summary>
        /// 获取命令码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string OS(this ICmdContext context)
        {
            return context.GetSection("os").Get<string>();
        }
    }
}
