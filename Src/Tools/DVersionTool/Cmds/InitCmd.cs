using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.VersionTool
{
    [Cmd("init", OptionType = typeof(InitCmdOptions))]
    [Description("初始化配置文件")]
    public class InitCmd : BaseCmd
    {
        public InitCmd(
            ILogger<InitCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            ) : base(logger, output, context)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class InitCmdOptions
    {
        [SwitchMapKey("f", "file")]
        [Description("输出的配置文件路径")]
        public string File { get; set; }
    }
}
