using System;
using System.Collections.Generic;
using System.Text;

namespace D.Utils
{
    public class InnerCmd : IInnerCmd
    {
        private string _output;

        public string Arguments { get; set; }

        public string WorkDir { get; set; }
        public string Output
        {
            get => _output;
            set
            {
                _output = value.Replace("{", "").Replace("}", "");
            }
        }

        public InnerCmd() { }

        public InnerCmd(string args)
        {
            Arguments = args;
        }
    }
}
