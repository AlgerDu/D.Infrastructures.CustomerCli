using System;
using System.Collections.Generic;
using System.Text;

namespace D.Example.TestCli
{
    public class CmdOperation
    {
        public string Name { get; set; }

        public Dictionary<string, string> Condition { get; set; }


        public string[] Inner_Cmds { get; set; }
    }
}
