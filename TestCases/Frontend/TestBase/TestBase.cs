using Keywords.Frontend.Keywords;
using Keywords.Frontend.Provider;
using Helpers;

namespace TestCases.Frontend
{
    public class TestBase : IDisposable
    {
        public IWebDriver Driver;
        public CoreKeywords Keywords;
        public int ProcessId { get; set; }

        public TestBase()
        {
            Driver = DriverProvider.SetupChromeDriver();
            ProcessId = Environment.ProcessId;
            Keywords = new CoreKeywords(Driver, 5);
        }

        public void Dispose()
        {
            TestCleanup.CloseDriver(Driver);
            TestCleanup.KillProcessById(ProcessId);
        }
    }
}