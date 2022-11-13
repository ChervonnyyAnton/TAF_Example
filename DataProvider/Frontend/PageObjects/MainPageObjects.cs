using System;
using OpenQA.Selenium;

namespace DataProvider.Frontend
{
    public static class MainPageObjects
    {
        public static By HeaderOrderButton = By.XPath("//*[contains(text(), 'Заказать')]");
        public static By AcceptCookiesButton = By.XPath("//*[@id='rcc-confirm-button']");
        public static By OrderStatusButton = By.XPath("//*[contains(text(), 'Статус заказа')]");
        public static By OrderNumberInputField = By.XPath("//*[contains(@placeholder, 'номер заказа')]");
        public static By SearchOrderNumberButton = By.XPath("//*[contains(text(), 'Go!')]");
    }
}