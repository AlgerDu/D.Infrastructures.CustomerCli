using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace D.Utils
{
    /// <summary>
    /// linux 下执行命令行命令
    /// </summary>
    public class LinuxInnerCmdExecutor : IInnerCmdExecutor
    {
        /// <summary>
        /// 
        /// </summary>
        public LinuxInnerCmdExecutor() { }

        /// <inheritdoc/>
        public bool Execute(IInnerCmd cmd)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "/bin/bash";

                p.StartInfo.Arguments = "-c '" + cmd.Arguments + "'";

                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;

                if (!string.IsNullOrEmpty(cmd.WorkDir))
                {
                    p.StartInfo.WorkingDirectory = cmd.WorkDir;
                }

                p.Start();

                p.StandardInput.Flush();
                p.StandardInput.Close();
                p.WaitForExit();

                cmd.Output = p.StandardOutput.ReadToEnd();

                return true;
            }
            catch (Exception ex)
            {
                cmd.Output = "[ex]" + ex.Message;
                return false;
            }
        }
    }
}
