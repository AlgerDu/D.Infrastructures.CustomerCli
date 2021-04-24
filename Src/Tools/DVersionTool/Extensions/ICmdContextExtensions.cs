using D.Infrastructures.CustomerCli;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace D.VersionTool
{
    public static class ICmdContextExtensions
    {
        public static DvtModel GetConfig(this ICmdContext context, string file)
        {
            var full = Path.Combine(context.GetWorkDir(), file);

            if (!File.Exists(full))
            {
                return new DvtModel();
            }

            var json = File.ReadAllText(full);

            return JsonSerializer.Deserialize<DvtModel>(json);
        }

        public static void SaveConfig(this ICmdContext context, string file, DvtModel config)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(config, jsonOptions);

            var full = Path.Combine(context.GetWorkDir(), file);

            File.WriteAllText(full, json);
        }
    }
}
