using System;
using OpenQA.Selenium;

namespace DataProvider.Frontend.DataObjects
{
    public class OrderStatusPageOgjects
    {
        public static By TrackNumberInputField = By.XPath("//*[contains(@class, 'Input') and contains(@class, 'Track')]");
        public static By FindOrderByNumberButton = By.XPath("//*[contains(text(), 'Посмотреть')]");
    }
}