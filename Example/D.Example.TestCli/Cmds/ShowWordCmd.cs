using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.Example.TestCli
{
    [Cmd("show-word", OptionType = typeof(ShowWorkCmdOptions))]
    [Description("一个测试命令")]
    public class ShowWordCmd : BaseCmd
    {
        public ShowWordCmd(
            ILogger<ShowWordCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            ) : base(logger, output, context)
        {
        }

        public override void Execute()
        {
            var options = _context.GetCmdOptions<ShowWorkCmdOptions>();

            _context.AddYml(options.File);

            var oprt = _context.GetOperation("install");
        }
    }
}