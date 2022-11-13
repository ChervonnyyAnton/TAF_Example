using OpenQA.Selenium;
using System.Diagnostics;

namespace Keywords.UI.Helpers
{
    public static class TestCleanup
    {
        public static void KillProcessById(int processId)
        {
            try
            {
                Process.GetProcessById(processId).Kill(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public static void CloseDriver(IWebDriver driver)
        {
            driver?.Close();
            driver?.Quit();
        }
    }
}