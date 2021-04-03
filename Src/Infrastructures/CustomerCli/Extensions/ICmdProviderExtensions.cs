using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    /// <summary>
    /// ICmdProvider 的扩展
    /// </summary>
    public static class ICmdProviderExtensions
    {
        public static CmdDescription GetDescription(
            this ICmdProvider cmds
            , string code)
        {
            if (!cmds.Supports.ContainsKey(code))
            {
                return null;
            }

            var cmdType = cmds.Supports[code];

            var attr = cmdType.GetAttr<CmdAttribute>();

            if (attr == null)
            {
                return null;
            }

            var description = new CmdDescription
            {
                Code = attr.Code,
                Description = cmdType.GetAttr<DescriptionAttribute>()?.Description
            };

            var optionsType = attr.OptionType;

            if (optionsType != null)
            {
                foreach (var p in optionsType.GetProperties())
                {
                    var option = new CmdOptionsDescription
                    {
                        Name = p.Name,
                        Description = p.GetAttr<DescriptionAttribute>()?.Description
                    };

                    var maps = p.GetAttr<SwitchMapKeyAttribute>();

                    if (maps != null)
                    {
                        foreach (var k in maps.Keys)
                        {
                            option.Maps.Add(k.Length <= 1 ? $"-{k}" : $"--{k}");
                        }
                    }

                    description.Options.Add(option);
                }
            }

            return description;
        }
    }
}
