using System;
using System.Collections.Generic;
using System.Text;

namespace D.VersionTool
{
    public class DvtModel
    {
        public Dictionary<string, VersionConfig> Config { get; set; }

        public List<string> Stashs { get; set; }

        public Dictionary<string, List<string>> Groups { get; set; } = new Dictionary<string, List<string>>();

        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
    }

    public class VersionConfig
    {
        public string Template { get; set; }
    }
}
