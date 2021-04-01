using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    public class CmdContext : ICmdContext
    {
        readonly IConfiguration _config;

        public CmdContext(
            IEnumerable<ICmdContextConfigProvider> providers
            )
        {

        }

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
    }
}
