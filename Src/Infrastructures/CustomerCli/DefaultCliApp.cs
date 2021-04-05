using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 底层的一个默认实现
    /// </summary>
    public class DefaultCliApp : ICliApp
    {
        readonly ILogger _logger;
        readonly ICmdContext _context;
        readonly ICmdProvider _supportCmds;
        readonly IServiceProvider _services;
        readonly IConsoleOutput _output;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        /// <param name="supportCmds"></param>
        /// <param name="services"></param>
        /// <param name="output"></param>
        public DefaultCliApp(
            ILogger<DefaultCliApp> logger
            , ICmdContext context
            , ICmdProvider supportCmds
            , IServiceProvider services
            , IConsoleOutput output
            )
        {
            _logger = logger;
            _context = context;
            _supportCmds = supportCmds;
            _services = services;
            _output = output;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            OutputAppDescription();

            var code = _context.CmdCode();

            var isSupport = _supportCmds.Supports.TryGetValue(code, out var cmdType);

            if (isSupport)
            {
                var cmd = (ICmd)_services.GetService(cmdType);

                cmd.Execute();
            }
        }

        private void OutputAppDescription()
        {
            var tool = _context.GetAppDescription();

            _output.WriteLine($"{tool.Name}    {tool.Version}");
            _output.NewLine();

            _output.WriteLine($"location = [{tool.Location}]");
            _output.WriteLine($"workDir = [{_context.GetWorkDir()}]");
            _output.NewLine();
        }
    }
}
