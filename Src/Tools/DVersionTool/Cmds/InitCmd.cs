using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace D.VersionTool
{
    [Cmd("init", OptionType = typeof(InitCmdOptions))]
    [Description("初始化配置文件")]
    public class InitCmd : BaseCmd
    {
        public InitCmd(
            ILogger<InitCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            ) : base(logger, output, context)
        {
        }

        public override void Execute()
        {
            var workDir = _context.GetWorkDir();

            var data = new DvtModel();
            List<ProjectModel> projects = new List<ProjectModel>();

            AnaylseDirectory(workDir, projects);

            foreach (var project in projects)
            {
                project.Path = Path.GetRelativePath(workDir, project.Path)
                    .Replace("\\", "/")
                    .Insert(0, "./");
            }

            foreach (var project in projects)
            {
                var prps = ProjectReferencePath(project.Path);

                foreach (var prp in prps)
                {
                    var p = projects.FirstOrDefault(pp => string.Equals(pp.Path, prp, StringComparison.OrdinalIgnoreCase));

                    if (p != null)
                    {
                        p.Supports.Add(project.Name);
                    }
                }
            }
        }

        private void AnaylseDirectory(string path, List<ProjectModel> projects)
        {
            var files = Directory.GetFiles(path, "*.csproj");

            foreach (var file in files)
            {
                var project = new ProjectModel
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Path = file
                };

                _output.WriteLine("collect {0,-30}{1}", project.Name, project.Path);

                projects.Add(project);
            }

            var children = Directory.GetDirectories(path);

            foreach (var child in children)
            {
                var name = Path.GetFileName(child);

                if (name.StartsWith('.') || name == "bin" || name == "obj")
                {
                    continue;
                }

                AnaylseDirectory(child, projects);
            }
        }

        private IEnumerable<string> ProjectReferencePath(string prjectFile)
        {
            var workDir = _context.GetWorkDir();

            var xml = new XmlDocument();
            xml.Load(prjectFile);

            var nodes = xml.SelectNodes("Project/ItemGroup/ProjectReference");

            var paths = new List<string>();
            var dir = Path.GetDirectoryName(prjectFile);

            foreach (XmlNode node in nodes)
            {
                var path = node.Attributes["Include"].Value;
                path = Path.Join(dir, path);
                path = Path.GetRelativePath(workDir, path);
                path = path.Replace("\\", "/")
                    .Insert(0, "./");
                paths.Add(path);
            }

            return paths;
        }
    }

    public class InitCmdOptions
    {
        [SwitchMapKey("f", "file")]
        [Description("输出的配置文件路径")]
        public string File { get; set; }

        public InitCmdOptions()
        {
            File = "./dvt.json";
        }
    }
}
