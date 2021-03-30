using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace D.Infrastructures.CustomerCli
{
    public static class ICmdContextExtensions
    {
        public static string CmdCode(this ICmdContext context)
        {
            return context.GetSection("cmd").Get<string>();
        }
    }
}
