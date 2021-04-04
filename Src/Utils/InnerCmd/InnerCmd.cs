using System;
using System.Collections.Generic;
using System.Text;

namespace D.Utils
{
    public class InnerCmd : IInnerCmd
    {
        public string Arguments { get; set; }

        public string WorkDir { get; set; }
        public string Output { get; set; }
    }
}
