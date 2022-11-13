using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Helpers
{
    public static class ExpectedConditions
    {
        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return (IWebDriver driver) => title == driver.Title;
        }

        public static Func<IWebDriver, bool> TitleContains(string title)
        {
            return (IWebDriver driver) => driver.Title.Contains(title);
        }

        public static Func<IWebDriver, bool> TitleMatches(string regex)
        {
            return delegate (IWebDriver driver)
            {
                string title = driver.Title;
                return new Regex(regex, RegexOptions.IgnoreCase).Match(title).Success;
            };
        }

        public static Func<IWebDriver, bool> UrlToBe(string url)
        {
            return (IWebDriver driver) => driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant());
        }

        public static Func<IWebDriver, bool> UrlContains(string fraction)
        {
            return (IWebDriver driver) => driver.Url.ToLowerInvariant().Contains(fraction.ToLowerInvariant());
        }

        public static Func<IWebDriver, bool> UrlMatches(string regex)
        {
            return delegate (IWebDriver driver)
            {
                string url = driver.Url;
                return new Regex(regex, RegexOptions.IgnoreCase).Match(url).Success;
            };
        }

        public static Func<IWebDriver, IWebElement> ElementExists(By locator)
        {
            return (IWebDriver driver) => driver.FindElement(locator);
        }

        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return ElementIfVisible(driver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
                    if (readOnlyCollection.Any((IWebElement element) => !element.Displayed))
                    {
                        return null;
                    }

                    return readOnlyCollection.Any() ? readOnlyCollection : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
        {
            return delegate
            {
                try
                {
                    if (elements.Any((IWebElement element) => !element.Displayed))
                    {
                        return null;
                    }

                    return elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
                    return readOnlyCollection.Any() ? readOnlyCollection : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> TextToBePresentInElement(IWebElement element, string text)
        {
            return delegate
            {
                try
                {
                    return element.Text.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> TextToBePresentInElementLocated(By locator, string text)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return driver.FindElement(locator).Text.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> TextToBePresentInElementValue(IWebElement element, string text)
        {
            return delegate
            {
                try
                {
                    return element.GetAttribute("value")?.Contains(text) ?? false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> TextToBePresentInElementValue(By locator, string text)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return driver.FindElement(locator).GetAttribute("value")?.Contains(text) ?? false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(string frameLocator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return driver.SwitchTo().Frame(frameLocator);
                }
                catch (NoSuchFrameException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    IWebElement frameElement = driver.FindElement(locator);
                    return driver.SwitchTo().Frame(frameElement);
                }
                catch (NoSuchFrameException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return !driver.FindElement(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementWithText(By locator, string text)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    string text2 = driver.FindElement(locator).Text;
                    if (string.IsNullOrEmpty(text2))
                    {
                        return true;
                    }

                    return !text2.Equals(text);
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return delegate (IWebDriver driver)
            {
                IWebElement webElement = ElementIfVisible(driver.FindElement(locator));
                try
                {
                    if (webElement != null && webElement.Enabled)
                    {
                        return webElement;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return delegate
            {
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            return delegate
            {
                try
                {
                    return element == null || !element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element)
        {
            return ElementSelectionStateToBe(element, selected: true);
        }

        public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element, bool selected)
        {
            return (IWebDriver driver) => element.Selected == selected;
        }

        public static Func<IWebDriver, bool> ElementSelectionStateToBe(IWebElement element, bool selected)
        {
            return (IWebDriver driver) => element.Selected == selected;
        }

        public static Func<IWebDriver, bool> ElementToBeSelected(By locator)
        {
            return ElementSelectionStateToBe(locator, selected: true);
        }

        public static Func<IWebDriver, bool> ElementSelectionStateToBe(By locator, bool selected)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return driver.FindElement(locator).Selected == selected;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (!element.Displayed)
            {
                return null;
            }

            return element;
        }
    }
}