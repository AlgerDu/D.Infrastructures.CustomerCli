using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// ICliAppBuilder 扩展方法
    /// </summary>
    public static class ICliAppBuilderExtensions
    {
        /// <summary>
        /// 所有的底层支持
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ICliAppBuilder UseCustomerCliCore(this ICliAppBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ICmdContextConfigProvider, ArgsProvider>();
                services.AddSingleton<ICmdContextConfigProvider, OsProvider>();

                services.AddSingleton<ICmdProvider, CmdProvider>();
            });

            return builder;
        }

        /// <summary>
        /// 构造默认的 app
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ICliApp BuildDefaultApp(this ICliAppBuilder builder)
        {
            return builder.Build<DefaultCliApp>();
        }
    }
}
