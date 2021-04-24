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

    public class ProjectVersionModel
    {
        private string _version;

        public string Version
        {
            get => _version;
            set
            {
                var arr = value.Split('.');

                Nums[0] = arr[0];
                Nums[1] = arr[1];
                Nums[2] = arr.Length > 3 ? arr[2] : "0";
                Nums[3] = arr.Length > 4 ? arr[3] : "0";

                _version = value;
            }
        }

        public string[] Nums { get; private set; } = new string[4];

        public string AssemblyVersion => $"{Major}.{Minor}.0.0";

        public string FileVersion => $"{Major}.{Minor}.0.0";

        public string Major => Nums[0];

        public string Minor => Nums[1];

        public string Fix => Nums[2];

        public string Build => Nums[3];
    }
}
