using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    public class CmdDescription
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public List<CmdOptionsDescription> Options { get; set; } = new List<CmdOptionsDescription>();
    }

    public class CmdOptionsDescription
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Maps { get; set; } = new List<string>();
    }
}
