using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 一个简单的上下文；收集所有的 config
    /// </summary>
    public class CmdContext : ICmdContext
    {
        IConfiguration _config;

        public CmdContext(
            IEnumerable<ICmdContextConfigProvider> providers
            )
        {
            var builder = new ConfigurationBuilder();

            foreach (var provider in providers)
            {
                builder.AddConfiguration(provider.Get());
            }

            _config = builder.Build();
        }

        /// <inheritdoc/>
        public void AddCOnfig(IConfiguration ext)
        {
            _config = new ConfigurationBuilder()
                .AddConfiguration(_config)
                .AddConfiguration(ext)
                .Build();
        }

        #region IConfiguration
        ///<inheritdoc/>
        public string this[string key] { get => _config[key]; set => _config[key] = value; }

        ///<inheritdoc/>
        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return _config.GetChildren();
        }

        ///<inheritdoc/>
        public IChangeToken GetReloadToken()
        {
            return _config.GetReloadToken();
        }

        ///<inheritdoc/>
        public IConfigurationSection GetSection(string key)
        {
            return _config.GetSection(key);
        }
        #endregion
    }
}
