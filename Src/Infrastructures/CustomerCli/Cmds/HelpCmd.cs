using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 内置 help 命令
    /// </summary>
    [Cmd("help", OptionType = typeof(HelpCmdOptions))]
    [Description("内置帮助命令")]
    public class HelpCmd : BaseCmd
    {
        readonly ICmdProvider _cmds;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="output"></param>
        /// <param name="cmds"></param>
        public HelpCmd(
            ILogger<HelpCmd> logger
            , IConsoleOutput output
            , ICmdProvider cmds
            ) : base(logger, output)
        {
            _cmds = cmds;
        }

        ///<inheritdoc/>
        public override void Execute(ICmdContext context)
        {

        }
    }
}
