using System;
using System.Collections.Generic;
using System.Text;
using D.Utils;
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
                services.AddCustomerCliCore();
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

        private static IServiceCollection AddCustomerCliCore(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleOutput, ConsoleOutput>();
            services.AddSingleton<ICmdContext, CmdContext>();

            services.AddCmdProvider();
            services.CollectAllProvider();

            services.AddInnerCmd();

            return services;
        }

        private static IServiceCollection AddCmdProvider(this IServiceCollection services)
        {
            var provider = new CmdProvider();

            foreach (var cmdType in provider.Supports.Values)
            {
                services.AddTransient(cmdType);
            }

            services.AddSingleton<ICmdProvider>(provider);

            return services;
        }

        private static IServiceCollection CollectAllProvider(this IServiceCollection services)
        {
            var assembly = typeof(ICliAppBuilderExtensions).Assembly;

            foreach (var t in assembly.GetTypes())
            {
                if (t.IsClass && typeof(ICmdContextConfigProvider).IsAssignableFrom(t))
                {
                    services.AddSingleton(typeof(ICmdContextConfigProvider), t);
                }
            }

            return services;
        }

        private static IServiceCollection AddInnerCmd(this IServiceCollection services)
        {
            services.AddSingleton<IInnerCmdExecutor>(provider =>
            {
                var context = provider.GetService<ICmdContext>();

                var os = context.OS();

                switch (os)
                {
                    case "win": return new WinInnerCmdExecutor();
                    case "linux": return new LinuxInnerCmdExecutor();
                    default:
                        return null;
                }
            });

            return services;
        }
    }
}
