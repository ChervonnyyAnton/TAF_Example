using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace Keywords.UI.Provider
{
    public static class DriverProvider
    {
        public static ChromeDriver SetupChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--inprivate");
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("resolution", "1920x1080");
            browserstackOptions.Add("seleniumVersion", "4.0.0");
            options.AddAdditionalOption("bstack:options", browserstackOptions);
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");
            ChromeDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }
    }
}