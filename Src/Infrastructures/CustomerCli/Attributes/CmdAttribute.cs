using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 命令的描述
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CmdAttribute : Attribute
    {
        /// <summary>
        /// 命令码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 命令的帮助描述
        /// </summary>
        public string Descriptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        public CmdAttribute(string code)
        {
            Code = code;
        }
    }
}
