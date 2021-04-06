using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D.Example.TestCli
{
    public static class ICmdContextExtensions
    {
        public static void AddYml(this ICmdContext context, string file)
        {
            var config = new ConfigurationBuilder()
                .AddYamlFile(Path.Combine(context.GetWorkDir(), file))
                .Build();

            context.AddConfig(config);
        }
    }
}
