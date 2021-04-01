using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// 从底层及 Program 所在的程序集收集 ICmd 的 type
    /// </summary>
    public class CmdProvider : ICmdProvider
    {
        readonly Dictionary<string, Type> _cmdTypes = new Dictionary<string, Type>();

        /// <summary>
        /// default
        /// </summary>
        public CmdProvider()
        {
            CollectCmdTypes();
        }

        /// <inheritdoc/>
        public IDictionary<string, Type> Supports => _cmdTypes;

        private void CollectCmdTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var type in assemblies.SelectMany(aa => aa.GetTypes()))
            {
                if (typeof(ICmd).IsAssignableFrom(type))
                {
                    var attr = type.GetCmdAttr();

                    if (attr != null)
                    {
                        _cmdTypes[attr.Code] = type;
                    }
                }
            }
        }
    }
}
