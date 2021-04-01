using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 用来传递 命令行参数
    /// </summary>
    public class ArgsOptions
    {
        /// <summary>
        /// 原始参数
        /// </summary>
        public string[] Args { get; set; }
    }
}
