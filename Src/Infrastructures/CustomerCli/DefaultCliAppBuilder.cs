using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 默认的构造器
    /// </summary>
    public class DefaultCliAppBuilder : ICliAppBuilder
    {
        private readonly string[] _args;

        private Action<IServiceCollection> _configureServices;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public DefaultCliAppBuilder(string[] args)
        {
            _args = args;
        }

        /// <inheritdoc/>
        public ICliAppBuilder ConfigureServices(Action<IServiceCollection> configureDelegate)
        {
            _configureServices += configureDelegate;

            return this;
        }

        /// <inheritdoc/>
        public App Build<App>() where App : class, ICliApp
        {
            var hostingServices = BuildCommonServices(out var hostingStartupErrors);

            hostingServices.AddTransient<App>(); 

            var provider = hostingServices.BuildServiceProvider();

            return provider.GetService<App>();
        }

        private IServiceCollection BuildCommonServices(out AggregateException hostingStartupErrors)
        {
            hostingStartupErrors = null;

            var services = new ServiceCollection();

            _configureServices?.Invoke(services);

            return services;
        }
    }
}
