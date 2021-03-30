using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Infrastructures.CustomerCli
{
    public class ArgsProvider : ICmdContextConfigProvider
    {
        public ArgsProvider(params string[] args)
        {

        }

        public IConfiguration Get()
        {
            throw new NotImplementedException();
        }
    }
}
