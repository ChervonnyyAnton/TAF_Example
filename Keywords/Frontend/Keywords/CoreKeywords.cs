using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Keywords.Frontend.Keywords
{
    public class CoreKeywords
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public string NotEmptyOrWhitespaceRegex = @"(.|\s)*\S(.|\s)*";

        public CoreKeywords(IWebDriver driver, int secondsToWait)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            Wait.PollingInterval = TimeSpan.FromMilliseconds(500);
        }

        public CoreKeywords GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }

        public string GetPageUrl()
        {
            Wait.Until(ExpectedConditions.UrlMatches(NotEmptyOrWhitespaceRegex));
            return Driver.Url;
        }

        public string GetPageTitle()
        {
            Wait.Until(ExpectedConditions.TitleMatches(NotEmptyOrWhitespaceRegex));
            return Driver.Title;
        }

        public IWebElement FindElement(Func<IWebDriver, IWebElement> expectedCondition)
        {
            return Wait.Until(expectedCondition);
        }

        public IWebElement GetElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public bool IsDisplayed(By locator)
        {
            try
            {
                return FindElement(ExpectedConditions.ElementExists(locator)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsClickable(By locator)
        {
            try
            {
                return FindElement(ExpectedConditions.ElementIsVisible(locator)).Enabled;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public CoreKeywords Click(By locator)
        {
            bool isClickable = IsClickable(locator);

            if (!isClickable)
            {
                isClickable = IsClickable(locator);
            }

            if (isClickable)
            {
                GetElement(locator).Click();
            }

            return this;
        }

        public CoreKeywords Click(IWebElement element)
        {
            FindElement(ExpectedConditions.ElementToBeClickable(element)).Click();
            return this;
        }

        public CoreKeywords SendKeys(By locator, string text)
        {
            ClearKeys(locator);
            GetElement(locator).SendKeys(text);
            return this;
        }

        public CoreKeywords SendKeys(IWebElement element, string text)
        {
            ClearKeys(element);
            element.SendKeys(text);

            return this;
        }

        public CoreKeywords ClearKeys(IWebElement element)
        {
            element = FindElement(ExpectedConditions.ElementToBeClickable(element));

            element.SendKeys(Keys.LeftControl + "A");
            element.SendKeys(Keys.Backspace);
            AnimationDelay(0.3);

            return this;
        }

        public CoreKeywords ClearKeys(By locator)
        {
            IWebElement element = FindElement(ExpectedConditions.ElementToBeClickable(locator));

            element.SendKeys(Keys.LeftControl + "A");
            element.SendKeys(Keys.Backspace);
            AnimationDelay(0.3);

            return this;
        }

        public CoreKeywords AnimationDelay(int timeInSeconds)
        {
            Thread.Sleep(timeInSeconds * 1000);
            return this;
        }

        public CoreKeywords AnimationDelay(double timeInSeconds)
        {
            Thread.Sleep((int)timeInSeconds * 1000);
            return this;
        }
    }
}