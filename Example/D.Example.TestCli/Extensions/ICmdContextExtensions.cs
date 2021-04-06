using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static CmdOperation GetOperation(this ICmdContext context, string name)
        {
            var cmd = context.CmdCode();

            var section = context.GetSection($"cmds:{cmd}:{name}");

            if (!section.Exists())
            {
                return null;
            }

            var tmp = section.Get<Dictionary<string, CmdOperation>>();

            foreach (var t in tmp.Values)
            {
                foreach (var o in t.Condition)
                {
                    var s = context.GetSection(o.Key);

                    if (s.Exists() && s.Get<string>() == o.Value)
                    {

                    }
                    else
                    {

                    }
                }
            }

            return null;
        }
    }
}
