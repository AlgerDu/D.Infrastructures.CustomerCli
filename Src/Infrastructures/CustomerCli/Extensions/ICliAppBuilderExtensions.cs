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
                services.AddLogging();
            });

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IConsoleOutput, ConsoleOutput>();
                services.AddSingleton<ICmdContext, CmdContext>();
            });

            builder.ConfigureServices(services =>
            {
                var provider = new CmdProvider();

                foreach (var cmdType in provider.Supports.Values)
                {
                    services.AddTransient(cmdType);
                }

                services.AddSingleton<ICmdProvider>(provider);
            });

            builder.CollectAllProvider();

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

        private static ICliAppBuilder CollectAllProvider(this ICliAppBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var assembly = typeof(ICliAppBuilderExtensions).Assembly;

                foreach (var t in assembly.GetTypes())
                {
                    if (t.IsClass && typeof(ICmdContextConfigProvider).IsAssignableFrom(t))
                    {
                        services.AddSingleton(typeof(ICmdContextConfigProvider), t);
                    }
                }
            });

            return builder;
        }
    }
}
