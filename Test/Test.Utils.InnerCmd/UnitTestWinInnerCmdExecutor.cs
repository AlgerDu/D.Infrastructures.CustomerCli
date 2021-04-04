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
    }
}
