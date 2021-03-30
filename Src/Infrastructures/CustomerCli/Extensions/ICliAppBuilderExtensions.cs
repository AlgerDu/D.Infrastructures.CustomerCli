using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// ICliAppBuilder 扩展方法
    /// </summary>
    public static class ICliAppBuilderExtensions
    {
        /// <summary>
        /// 所有的底层支持
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ICliAppBuilder UseCustomerCliCore(this ICliAppBuilder builder)
        {
            return builder;
        }
    }
}
