using OpenQA.Selenium;

namespace DataProvider.Frontend.PageObjects
{
    public static class OrderPageObjects
    {
        public static By FirstNameInputField = By.XPath("//*[contains(@placeholder, 'Имя')]");
        public static By LastNameInputField = By.XPath("//*[contains(@placeholder, 'Фамилия')]");
        public static By AddressInputField = By.XPath("//*[contains(text(), 'Адрес')]");
        public static By StationSelect = By.XPath("//*[contains(@placeholder, 'Станция')]");
        public static By PhoneNumberInputField = By.XPath("//*[contains(@placeholder, 'Телефон')]");
        public static By CalendarSelect = By.XPath("//*[contains(@placeholder, 'Когда привезти')]");
        public static By RentalPeriodSelect = By.XPath("//*[contains(text(), 'Срок аренды')]");
        public static By ScooterColorCheckboxBlack = By.XPath("//*[@id='black']");
        public static By ScooterColorCheckboxGrey = By.XPath("//*[@id='grey']");
        public static By CommentInputField = By.XPath("//*[contains(@placeholder, 'Комментарий')]");
        public static By ConfirmOrderButton = By.XPath("//*[contains(text(), 'Да')]");
        public static By DenyOrderButton = By.XPath("//*[contains(text(), 'Нет')]");
        public static By MiddleOrderButton = By.XPath("//*[contains(text(), 'Заказать') and contains(@class, 'Middle')]");
        public static By StepBackButton = By.XPath("//*[contains(text(), 'Назад')]");

        public static By GetRentalPeriodDurationButton(int durationInDays)
        {
            return By.XPath($"//*[contains(text(), '{ConvertNumberInRussianText(durationInDays)}') ]");
        }

        private static object ConvertNumberInRussianText(int durationInDays)
        {
            switch (durationInDays)
            {
                case 1:
                    return "сутки";
                case 2:
                    return "двое суток";
                case 3:
                    return "трое суток";
                case 4:
                    return "четверо суток";
                case 5:
                    return "пятеро суток";
                case 6:
                    return "шестеро";
                case 7:
                    return "семеро";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static By GetCalenderDateButton(DateTime date)
        {
            return By.XPath($"//*[contains(@aria-label, '{date.Day}') and contains(@aria-label, '{GetRussianMonthNameFromNumber(date.Month)}') and contains(@aria-label, '{date.Year}')]");
        }

        public static string GetRussianMonthNameFromNumber(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "январ";
                case 2:
                    return "феврал";
                case 3:
                    return "март";
                case 4:
                    return "апрел";
                case 5:
                    return "ма";
                case 6:
                    return "июн";
                case 7:
                    return "июл";
                case 8:
                    return "август";
                case 9:
                    return "сентябр";
                case 10:
                    return "октябр";
                case 11:
                    return "ноябр";
                case 12:
                    return "декабр";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}