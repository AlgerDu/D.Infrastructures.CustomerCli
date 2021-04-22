using System;
using System.Collections.Generic;
using System.Text;

namespace D.VersionTool
{
    public class DvtModel
    {
        public Dictionary<string, string[]> Groups { get; set; }

        public ProjectModel[] Projects { get; set; }
    }
}
