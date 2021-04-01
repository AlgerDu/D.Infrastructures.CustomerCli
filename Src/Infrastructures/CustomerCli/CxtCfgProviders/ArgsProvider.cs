using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 解析命令行参数
    /// </summary>
    public class ArgsProvider : ICmdContextConfigProvider
    {
        IConfiguration _configs;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="options"></param>
        /// <param name="supportCmds"></param>
        public ArgsProvider(
            IOptions<ArgsOptions> options
            , ICmdProvider supportCmds
            )
        {
            var cmdCode = AnaylseCmdCode(options.Value?.Args);
            var map = AnaylseCmdParamMap(cmdCode, supportCmds);

            _configs = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { { "cmd", cmdCode } })
                .AddCommandLine(options.Value.Args, map)
                .Build();
        }

        /// <inheritdoc/>
        public IConfiguration Get()
        {
            return _configs;
        }

        private string AnaylseCmdCode(string[] args)
        {
            var cmd = "help";

            if (args != null && args.Length > 0)
            {
                cmd = args.FirstOrDefault();
            }

            return cmd;
        }

        private Dictionary<string, string> AnaylseCmdParamMap(string cmdCode, ICmdProvider supportCmds)
        {
            var map = new Dictionary<string, string>();

            if (supportCmds.Supports.ContainsKey(cmdCode))
            {
                var cmdType = supportCmds.Supports[cmdCode];

                var cmdAddr = cmdType.GetCmdAttr();

                if (cmdAddr != null)
                {
                    var optionsType = cmdAddr.OptionType;

                    foreach (var p in optionsType.GetProperties())
                    {
                        var name = p.Name;

                        var sk = (SwitchMapKeyAttribute)p.GetCustomAttributes(typeof(SwitchMapKeyAttribute), true).SingleOrDefault();

                        if (sk == null)
                        {
                            continue;
                        }

                        foreach (var k in sk.Keys)
                        {
                            if (k.Length == 1)
                            {
                                map.Add($"-{k}", $"options:{name}");
                            }
                            else
                            {
                                map.Add($"--{k}", $"options:{name}");
                            }
                        }
                    }
                }
            }

            return map;
        }
    }

    /// <summary>
    /// 有关配置的一些读取
    /// </summary>
    public static class ICmdContextExtensions_Arg
    {
        /// <summary>
        /// 获取命令码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string CmdCode(this ICmdContext context)
        {
            return context.GetSection("cmd").Get<string>();
        }
    }
}
