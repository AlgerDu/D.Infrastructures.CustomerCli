using D.Infrastructures.CustomerCli;
using D.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace D.VersionTool
{
    [Cmd("nuget-push", OptionType = typeof(NugetPushCmd))]
    [Description("推送 nuget 包到服务器")]
    public class NugetPushCmd : BaseCmd
    {
        const string _build = "dotnet pack {projectPath} -c Release -o ./bin/nuget";
        const string _push = "dotnet nuget push {pak} -k {key} -s {server}";

        readonly IInnerCmdExecutor _innerCmdExecutor;

        public NugetPushCmd(
            ILogger<NugetPushCmd> logger
            , IConsoleOutput output
            , ICmdContext context
            , IInnerCmdExecutor innerCmdExecutor
            ) : base(logger, output, context)
        {
            _innerCmdExecutor = innerCmdExecutor;
        }

        public override void Execute()
        {
            var options = _context.GetCmdOptions<NugetPushCmdOptions>();
            var config = _context.GetConfig(options.File);

            foreach (var name in config.Stashs)
            {
                var project = config.Projects.FirstOrDefault(pp => pp.Name == name);
                var xml = project.GetXmlData();
                var pakName = xml.GetPackageName(project.Name);

                var innerCmd = new InnerCmd(_build.Replace("{projectPath}", project.Path));

                _output.WriteLine($"try to execute cmd [{innerCmd.Arguments}]");

                _innerCmdExecutor.Execute(innerCmd);

                _output.BeginScope()
                    .WriteLine(innerCmd.Output);
                _output.EndScope();

                innerCmd = new InnerCmd(_push
                    .Replace("{pak}", $"./bin/niget/{pakName}")
                    .Replace("{key}", options.PushKey)
                    .Replace("{server}", options.Server)
                    );

                _output.WriteLine($"try to execute cmd [{innerCmd.Arguments}]");

                _innerCmdExecutor.Execute(innerCmd);

                _output.BeginScope()
                    .WriteLine(innerCmd.Output);
                _output.EndScope();
            }
        }
    }

    public class NugetPushCmdOptions : BaseCmdOptions
    {
        [SwitchMapKey("s", "server")]
        [Description("nuget 服务器地址")]
        public string Server { get; set; }

        [SwitchMapKey("k", "key")]
        [Description("包推送使用的 key")]
        public string PushKey { get; set; }

        [SwitchMapKey("stash")]
        [Description("推送 stash 暂存的项目的包")]
        public bool PushStashs { get; set; }
    }
}
