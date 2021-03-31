using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 从底层及 Program 所在的程序集收集 ICmd 的 type
    /// </summary>
    public class CmdProvider : ICmdProvider
    {
        /// <inheritdoc/>
        public IDictionary<string, Type> Supports => throw new NotImplementedException();
    }
}
