using D.Infrastructures.CustomerCli;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace D.VersionTool
{
    [Cmd("update", OptionType = typeof(UpdateCmdOptions))]
    [Description("初始化配置文件")]
    public class UpdateCmd : BaseCmd
    {
        DvtModel _dvtConfig;

        public UpdateCmd(
            ILogger<UpdateCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            ) : base(logger, output, context)
        {
        }

        public override void Execute()
        {
            var options = _context.GetCmdOptions<UpdateCmdOptions>();
            _dvtConfig = _context.GetConfig(options.File);

            switch (options.Type)
            {
                case "nuget": UpateNugetVersion(options); break;
                case "group": UpdateGroupVersion(options); break;
                default:
                    _output.WriteLine($"not support type = {options.Type}");
                    break;
            }
        }

        private void UpdateGroupVersion(UpdateCmdOptions options)
        {
            var versionConfig = _dvtConfig.Config["Group"];

            if (!_dvtConfig.Groups.ContainsKey(options.Name))
            {
                _output.WriteLine($"group [{options.Name}] not exist");
                return;
            }

            var groupProjects = _dvtConfig.Groups[options.Name];

            foreach (var name in groupProjects)
            {
                UpdateProjectVersion(name, versionConfig, options.Version);
            }
        }

        public void UpateNugetVersion(UpdateCmdOptions options)
        {
            var config = _context.GetConfig(options.File);
            var versionConfig = config.Config["Nuget"];

            List<string> toUpdateProject = new List<string>();

            toUpdateProject.Add(options.Name);

            while (toUpdateProject.Count > 0)
            {
                var name = toUpdateProject[0];

                var project = UpdateProjectVersion(name, versionConfig, options.Version);

                if (project != null)
                {
                    toUpdateProject.AddRange(project.Supports);
                }

                toUpdateProject.RemoveAt(0);
            }
        }

        public ProjectModel UpdateProjectVersion(string projectName, VersionConfig config, string newVersion)
        {
            var project = _dvtConfig.Projects.FirstOrDefault(pp => pp.Name == projectName);

            if (project == null)
            {
                _output.WriteLine($"project [{projectName}] not exist");
                return null;
            }

            if (_dvtConfig.Stashs.Contains(projectName))
            {
                _output.WriteLine($"project [{projectName}] stashed");

                return project;
            }

            var xml = project.GetXmlData();
            var oldVersion = xml.GetCurrVersion();

            if (string.IsNullOrEmpty(newVersion))
            {

                var tmp = config.Template.Split('.');

                var bulidIndex = tmp.Length;

                var buildNo = oldVersion.Nums[bulidIndex];

                var index = "01";

                if (Convert.ToInt32(buildNo) > Convert.ToInt32($"{DateTimeOffset.Now.ToString("MMdd")}00"))
                {
                    index = (Convert.ToInt32(buildNo) % 100 + 1).ToString().PadLeft(2, '0');
                }

                newVersion = config.Template
                   .Replace("{major}", oldVersion.Major)
                   .Replace("{minor}", oldVersion.Minor)
                   .Replace("{fix}", oldVersion.Fix)
                   .Replace("{date}", DateTimeOffset.Now.ToString("MMdd"))
                   .Replace("{index}", index);
            }

            _output.WriteLine($"{project.Name} {oldVersion.Version} => {newVersion}");

            xml.SetVersion(new ProjectVersionModel { Version = newVersion });

            project.SaveXmlData(xml);

            return project;
        }
    }

    public class UpdateCmdOptions : BaseCmdOptions
    {
        [SwitchMapKey("stash")]
        [Description("将变更了版本号的项目缓存起来，后面统一推送")]
        public bool Stash { get; set; }

        [SwitchMapKey("support")]
        [Description("同步升级 support 项目的版本号")]
        public bool UpdateSupport { get; set; }

        [SwitchMapKey("v", "version")]
        [Description("更新使用的版本号；未配置则按照规则自动更新")]
        public string Version { get; set; }

        [SwitchMapKey("n", "name")]
        [Description("需要更新版本号的项目")]
        public string Name { get; set; }

        [SwitchMapKey("t", "type")]
        [Description("nuget 或者 group")]
        public string Type { get; set; }

        public UpdateCmdOptions()
        {
            Stash = false;
            UpdateSupport = false;
            Type = "nuget";
        }
    }
}
