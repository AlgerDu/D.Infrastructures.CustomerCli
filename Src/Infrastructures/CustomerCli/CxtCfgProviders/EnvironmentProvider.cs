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
}
