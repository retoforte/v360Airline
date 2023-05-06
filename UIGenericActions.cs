using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
namespace CheckTrips360
{
    public static class UIGenericActions
    {
        public enum searchType
        {
            ID,
            TAG,
            XPATH
        }

        public static bool SelectFechaSalida(IWebDriver driver, DateTime fecha) {
            WaitUntilElementIsVisible("bs-daterangepicker-container", searchType.TAG, driver);
            IWebElement fullCalendario = driver.FindElement(By.TagName(PageElements.TagFullCalendarios));
            bool isSelecteDate = false;
            do
            {
                // Izquiero y Derecho /  Mes actual / Mes siguiente
                IReadOnlyCollection<IWebElement> calendarios = fullCalendario.FindElements(By.TagName(PageElements.TagCalendario));
                int index = 1;
                foreach (IWebElement calendario in calendarios)
                {
                    if (ValidateCalendarioFechasVsRequerida(fecha, calendario))
                    {
                        isSelecteDate = true;
                    }
                    else if (index == 2)
                    {
                        //Move the Calendar
                        IWebElement button = calendario.FindElement(By.CssSelector("button.next")); 
                        button.Click();
                    }
                    index++;
                }
            }
            while (isSelecteDate == false);
            return isSelecteDate;
        }

        private static bool ValidateCalendarioFechasVsRequerida(DateTime requerida, IWebElement calendario)
        {
            IReadOnlyCollection<IWebElement> spanElements = calendario.FindElements(By.CssSelector(PageElements.CssBtnCalendarioFechas));

            var array = spanElements.ToArray();
            if (array.Length > 1)
            {
                string monthName = requerida.ToString("MMMM", new CultureInfo("es-ES")).ToUpper();
                if (array[0].Text.ToUpper() == monthName && array[1].Text.ToUpper() == requerida.Year.ToString())
                {
                    FindDayInCalendarToTriggerClick(requerida, calendario);
                    return true;
                }
            }
            return false;
        }
        private static Boolean FindDayInCalendarToTriggerClick(DateTime requerida, IWebElement calendario)
        {
            // Find all the span elements with class "bsdatepickerdaydecorator"
            IReadOnlyCollection<IWebElement> spans = calendario.FindElements(By.CssSelector("span[bsdatepickerdaydecorator]"));

            // Iterate over the found elements
            foreach (IWebElement span in spans)
            {
                if (span.Text.ToUpper().Trim().Equals(requerida.Day.ToString()))
                {
                    span.Click();
                    return true;
                }
            }
            return false;
        }
        public static void WaitUntilElementIsVisible(string element, searchType type, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            By elementLocator = By.Id("");

            if (type == searchType.XPATH)
                elementLocator = By.XPath(element);
            else if (type == searchType.ID)
                elementLocator = By.Id(element);
            else if (type == searchType.TAG)
                elementLocator = By.TagName(element);

            wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(elementLocator);
                return element.Displayed;
            });
        }

    }
}
