using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 命令可选参数的 mapkey
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SwitchMapKeyAttribute : Attribute
    {
        /// <summary>
        /// key
        /// </summary>
        public string[] Keys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public SwitchMapKeyAttribute(params string[] keys)
        {
            Keys = keys;
        }
    }
}
