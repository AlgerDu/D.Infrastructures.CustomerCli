using System;
using System.Collections.Generic;
using System.Text;

namespace D.VersionTool
{
    public class ProjectModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public List<string> Supports { get; set; } = new List<string>();
    }
}
