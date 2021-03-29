using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 内置帮助命令的可选参数
    /// </summary>
    public class HelpCmdOptions
    {
        /// <summary>
        /// 获取具体命令的帮助
        /// </summary>
        [SwitchMapKey("c", "cmd")]
        [Description("获取具体命令的帮助")]
        [DefaultValue(null)]
        public string CmdCode { get; set; }
    }
}
