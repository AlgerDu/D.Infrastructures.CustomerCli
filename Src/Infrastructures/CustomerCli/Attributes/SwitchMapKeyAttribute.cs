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
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public SwitchMapKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
