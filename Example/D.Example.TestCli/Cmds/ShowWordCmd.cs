using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using D.Utils;

namespace D.Example.TestCli
{
    [Cmd("show-word", OptionType = typeof(ShowWorkCmdOptions))]
    [Description("一个测试命令")]
    public class ShowWordCmd : BaseCmd
    {
        readonly IInnerCmdExecutor _cmdExecutor;

        public ShowWordCmd(
            ILogger<ShowWordCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            , IInnerCmdExecutor cmdExecutor
            ) : base(logger, output, context)
        {
            _cmdExecutor = cmdExecutor;
        }

        public override void Execute()
        {
            var options = _context.GetCmdOptions<ShowWorkCmdOptions>();

            _context.AddYml(options.File);

            var oprt = _context.GetOperation("install");

            var innerCmd = new InnerCmd(oprt.Inner_Cmds[0]);

            var ok = _cmdExecutor.Execute(innerCmd);

            _output.WriteLine(innerCmd.Output);
        }
    }
}