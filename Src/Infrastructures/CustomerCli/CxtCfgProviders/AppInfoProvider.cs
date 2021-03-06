using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 获取应用程序相关的一些信息
    /// </summary>
    public class AppInfoProvider : ICmdContextConfigProvider
    {
        /// <inheritdoc/>
        public IConfiguration Get()
        {
            var entry = Assembly.GetEntryAssembly();

            var attr = entry.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            return new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "app:name", entry.GetName().Name },
                    { "app:version", attr == null? entry.GetName().Version.ToString() : attr.InformationalVersion },
                    { "app:location", entry.Location }
                })
                .Build();
        }
    }

    /// <summary>
    /// 有关配置的一些读取
    /// </summary>
    public static class ICmdContextExtensions_AppInfo
    {
        /// <summary>
        /// 获取命令码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ToolAppDescription GetAppDescription(this ICmdContext context)
        {
            return context.GetSection("app").Get<ToolAppDescription>();
        }
    }
}
