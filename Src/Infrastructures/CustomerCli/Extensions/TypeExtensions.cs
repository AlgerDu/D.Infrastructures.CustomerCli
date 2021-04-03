using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// 获取某个下面的自定义 attr
        /// </summary>
        /// <typeparam name="AttrType"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static AttrType GetAttr<AttrType>(this Type type) where AttrType : Attribute
        {
            var o = type.GetCustomAttributes(typeof(AttrType), true).SingleOrDefault();

            if (o == null)
            {
                return null;
            }
            else
            {
                return o as AttrType;
            }
        }

        /// <summary>
        /// 获取某个下面的自定义 attr
        /// </summary>
        /// <typeparam name="AttrType"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static AttrType GetAttr<AttrType>(this MemberInfo member) where AttrType : Attribute
        {
            var o = member.GetCustomAttributes(typeof(AttrType), true).SingleOrDefault();

            if (o == null)
            {
                return null;
            }
            else
            {
                return o as AttrType;
            }
        }
    }
}
