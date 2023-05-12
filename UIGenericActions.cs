using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Globalization;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace CheckTrips360
{
    public static class UIGenericActions
    {
        public enum searchType
        {
            ID,
            TAG,
            XPATH,
            CSSLOCATOR
        }

        public static bool SelectFechaSalida(IWebDriver driver, DateTime fecha) {
            //WaitUntilElementIsVisible("//bs-days-calendar-view[2]//button[@class='next']", searchType.XPATH, driver);
            
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/bs-daterangepicker-container")));
            IWebElement fullCalendario = driver.FindElement(By.XPath("/html/body/bs-daterangepicker-container"));
            bool isSelecteDate = false;
            do
            {
                // Izquiero y Derecho /  Mes actual / Mes siguiente
                IReadOnlyCollection<IWebElement> calendarios = fullCalendario.FindElements(By.TagName(PageElements.TagCalendario));
                int index = 1;
                foreach (IWebElement calendario in calendarios)
                {
                    if (ValidateCalendarioFechasVsRequerida(driver, fecha, calendario))
                    {
                        isSelecteDate = true;
                    }
                    else if (index == 2)
                    {
                        IWebElement txtCalOrigen = driver.FindElement(By.TagName("app-booker-calendar"));
                        IWebElement button = calendario.FindElement(By.XPath("//bs-days-calendar-view[2]//button[@class='next']"));
                        /*((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('disabled');", button);
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility = 'visible'; arguments[0].style.display = 'block';", button);
                        */
                        //Move the Calendar
                        IWebElement button2 = calendario.FindElement(By.XPath("//button[@class='next']"));

                        button.Click();
                    }
                    index++;
                }
            }
            while (isSelecteDate == false);
            return isSelecteDate;
        }

        private static bool ValidateCalendarioFechasVsRequerida(IWebDriver driver, DateTime requerida, IWebElement calendario)
        {
            IReadOnlyCollection<IWebElement> spanElements = calendario.FindElements(By.CssSelector(PageElements.CssBtnCalendarioFechas));

            var array = spanElements.ToArray();
            if (array.Length > 1)
            {
                string monthName = requerida.ToString("MMMM", new CultureInfo("es-ES")).ToUpper();
                if (array[0].Text.ToUpper() == monthName && array[1].Text.ToUpper() == requerida.Year.ToString())
                {
                    FindDayInCalendarToTriggerClick(driver, requerida, calendario);
                    return true;
                }
            }
            return false;
        }
        private static Boolean FindDayInCalendarToTriggerClick(IWebDriver driver, DateTime requerida, IWebElement calendario)
        {
            // Find all the span elements with class "bsdatepickerdaydecorator"
            IReadOnlyCollection<IWebElement> spans = calendario.FindElements(By.CssSelector("span[bsdatepickerdaydecorator]"));

            // Iterate over the found elements
            foreach (IWebElement span in spans)
            {
                if (span.Text.ToUpper().Trim().Equals(requerida.Day.ToString()))
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('disabled');", span);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility = 'visible'; arguments[0].style.display = 'block';", span);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].classList.remove('disabled');", span);
                    span.Click();
                    return true;
                }
            }
            return false;
        }
        public static void WaitUntilElementIsVisible(string element, searchType type, IWebDriver driver, IWebElement parent , bool waitForAllWhenMultiple = false)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By elementLocator = By.Id("");

            if (type == searchType.XPATH)
                elementLocator = By.XPath(element);
            else if (type == searchType.ID)
                elementLocator = By.Id(element);
            else if (type == searchType.TAG)
                elementLocator = By.TagName(element);
            else if (type == searchType.CSSLOCATOR)
                elementLocator = By.CssSelector(element);

            if (waitForAllWhenMultiple)
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementLocator));
            else if (parent != null)
                wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));


            if (parent != null)
                wait.Until(ExpectedConditions.ElementToBeClickable(parent.FindElement(elementLocator)));
            else
                wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

    }
}
