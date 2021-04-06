using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using D.Infrastructures.CustomerCli;

namespace D.Example.TestCli
{
    public class ShowWorkCmdOptions
    {
        [SwitchMapKey("f", "file")]
        [Description("配置文件路径")]
        public string File { get; set; }

        public ShowWorkCmdOptions()
        {
            File = "./cli.yml";
        }
    }
}
