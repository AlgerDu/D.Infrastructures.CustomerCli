using D.Infrastructures.CustomerCli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace D.VersionTool
{
    public abstract class BaseCmdOptions
    {
        [SwitchMapKey("f", "file")]
        [Description("输出的配置文件路径")]
        public string File { get; set; }

        public BaseCmdOptions()
        {
            File = "./dvt.json";
        }
    }
}
