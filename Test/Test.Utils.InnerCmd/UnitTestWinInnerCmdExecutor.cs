using D.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Utils
{
    [TestClass]
    public class UnitTestWinInnerCmdExecutor
    {
        [TestMethod]
        public void TestMethodPing()
        {
            var cmd = new InnerCmd() { Arguments = "ipconfig" };

            var success = new WinInnerCmdExecutor().Execute(cmd);
        }

        [TestMethod]
        public void Test_cmd_notExist()
        {
            var cmd = new InnerCmd() { Arguments = "xx" };

            var success = new WinInnerCmdExecutor().Execute(cmd);
        }

        [TestMethod]
        public void Test_docker()
        {
            var cmd = new InnerCmd() { Arguments = "docker ps -a" };

            var success = new WinInnerCmdExecutor().Execute(cmd);
        }
    }
}
