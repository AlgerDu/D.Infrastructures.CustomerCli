using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        /// <param name="context"></param>
        public HelpCmd(
            ILogger<HelpCmd> logger
            , IConsoleOutput output
            , ICmdProvider cmds
            , ICmdContext context
            ) : base(logger, output, context)
        {
            _cmds = cmds;
        }

        ///<inheritdoc/>
        public override void Execute()
        {
            var options = _context.GetCmdOptions<HelpCmdOptions>();

            if (string.IsNullOrEmpty(options?.CmdCode))
            {
                ShowToolHelp();
            }
            else
            {
                ShowCmdHelp(options.CmdCode);
            }
        }

        private void ShowToolHelp()
        {
            _output.WriteLine($"支持的命令：");

            _output
                .NewLine()
                .BeginScope();

            foreach (var cmd in _cmds.Supports.Keys)
            {
                var info = _cmds.GetDescription(cmd);

                _output.WriteLine("{0,-15}{1}", info.Code, info.Description);
            }

            _output.EndScope();
        }

        private void ShowCmdHelp(string cmdCode)
        {
            var info = _cmds.GetDescription(cmdCode);

            if (info == null)
            {
                _output.WriteLine($"cmd [{cmdCode}] not support");

                ShowToolHelp();
                return;
            }

            _output.WriteLine($"[{cmdCode}] {info.Description}");
            _output.WriteLine($"可选参数：");

            _output
                .NewLine()
                .BeginScope();

            if (info.Options.Count == 0)
            {
                _output.WriteLine("无");
                return;
            }

            foreach (var p in info.Options)
            {
                var tmp = string.Empty;

                foreach (var m in p.Maps)
                {
                    tmp += $"{m}; ";
                }

                _output.WriteLine("{0,-20}{1}", tmp, p.Description);
            }
        }
    }
}
