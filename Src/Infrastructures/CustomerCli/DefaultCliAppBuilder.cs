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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public DefaultCliAppBuilder(string[] args)
        {

        }

        /// <inheritdoc/>
        public ICliAppBuilder ConfigureServices(Action<IServiceCollection> configureDelegate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ICliApp Build()
        {
            return null;
        }
    }
}
