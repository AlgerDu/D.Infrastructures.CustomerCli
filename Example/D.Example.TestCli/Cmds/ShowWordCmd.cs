using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.Example.TestCli
{
    [Cmd("show-word")]
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
            throw new NotImplementedException();
        }
    }
}
