using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 基础命令
    /// </summary>
    public abstract class BaseCmd : ICmd
    {
        /// <summary>
        /// 日志输出
        /// </summary>
        readonly protected ILogger _logger;

        /// <summary>
        /// 控制台输出
        /// </summary>
        readonly protected IConsoleOutput _output;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="output"></param>
        public BaseCmd(
            ILogger logger
            , IConsoleOutput output
            )
        {
            _logger = logger;
            _output = output;
        }

        ///<inheritdoc/>
        public abstract void Execute(ICmdContext context);
    }
}
