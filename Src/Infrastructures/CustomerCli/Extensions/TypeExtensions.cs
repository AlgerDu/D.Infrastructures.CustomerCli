using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 一些有关反射的扩展
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 获取类型的 cmd attr
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static CmdAttribute GetCmdAttr(this Type type)
        {
            return (CmdAttribute)type.GetCustomAttributes(typeof(CmdAttribute), true).SingleOrDefault();
        }
    }
}
