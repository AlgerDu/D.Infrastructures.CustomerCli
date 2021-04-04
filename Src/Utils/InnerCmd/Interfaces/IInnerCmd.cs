using System;
using System.Collections.Generic;
using System.Text;

namespace D.Utils
{
    /// <summary>
    /// 内部命令；用来调用其它的命令行等等
    /// </summary>
    public interface IInnerCmd
    {
        /// <summary>
        /// 命令参数
        /// </summary>
        string Arguments { get; }

        /// <summary>
        /// 设置执行命令的工作目录
        /// </summary>
        string WorkDir { get; set; }

        /// <summary>
        /// 命令执行过程中的输出
        /// </summary>
        string Output { get; set; }
    }
}
