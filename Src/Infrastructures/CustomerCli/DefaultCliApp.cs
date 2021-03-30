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

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        /// <param name="supportCmds"></param>
        /// <param name="services"></param>
        public DefaultCliApp(
            ILogger<DefaultCliApp> logger
            , ICmdContext context
            , ICmdProvider supportCmds
            , IServiceProvider services
            )
        {
            _logger = logger;
            _context = context;
            _supportCmds = supportCmds;
            _services = services;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            var code = _context.CmdCode();

            var isSupport = _supportCmds.Supports.TryGetValue(code, out var cmdType);

            if (isSupport)
            {
                var cmd = (ICmd)_services.GetService(cmdType);

                cmd.Execute();
            }
        }
    }
}
