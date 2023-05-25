﻿using System;
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

        public static bool SelecFechaSalidaAeroMexico(IWebDriver driver, DateTime fecha)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IWebElement fullCalendario = driver.FindElement(By.CssSelector("div.BookerCalendarPicker.calendarNewHome"));
            fullCalendario.Click();
            Thread.Sleep(500);
            //UIGenericActions.WaitUntilElementIsVisible("div.DatePickerCalendarMonthRefactored", UIGenericActions.searchType.CSSLOCATOR, null, fullCalendario, true);
            bool isSelecteDate = false;
            do
            {
                // Izquiero y Derecho /  Mes actual / Mes siguiente
                IReadOnlyCollection<IWebElement> calendarios = driver.FindElements(By.ClassName("DatePickerCalendarMonthRefactored"));
                int index = 1;
                foreach (IWebElement calendario in calendarios)
                {
                    if (ValidateCalendarioFechasVsRequeridaAeroMexico(driver, fecha, calendario))
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
                    if (isSelecteDate)
                        break;
                    index++;
                }
            }
            while (isSelecteDate == false);
            return isSelecteDate;
            return true;
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
                    if (isSelecteDate)
                        break;
                    index++;
                }
            }
            while (isSelecteDate == false);
            return isSelecteDate;
        }

        private static bool ValidateCalendarioFechasVsRequeridaAeroMexico(IWebDriver driver, DateTime requerida, IWebElement calendario)
        {
            IReadOnlyCollection<IWebElement> elementsMonths = calendario.FindElements(By.ClassName("DatePickerCalendarMonthRefactored-month"));
            IReadOnlyCollection<IWebElement> elementsYears = calendario.FindElements(By.ClassName("DatePickerCalendarMonthRefactored-year"));

            if (elementsMonths.Count() > 0)
            {
                string year = elementsYears.ElementAt(0).Text.Trim();
                string month = elementsMonths.ElementAt(0).Text.Trim();
                string monthName = requerida.ToString("MMMM", new CultureInfo("es-ES")).ToUpper().Trim();
                if (month.ToUpper() == monthName.ToUpper() && year == requerida.Year.ToString())
                {
                    FindDayInCalendarToTriggerClickAeroMexico(driver, requerida, calendario);
                    return true;
                }
            }
            return false;
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
        
        private static Boolean FindDayInCalendarToTriggerClickAeroMexico(IWebDriver driver, DateTime requerida, IWebElement calendario)
        {
            // Find all the span elements with class "bsdatepickerdaydecorator"
            IReadOnlyCollection<IWebElement> buttons = calendario.FindElements(By.ClassName("DatePickerCalendarMonthRefactored-day"));

            // Iterate over the found elements
            foreach (IWebElement button in buttons)
            {
                var datetitle = button.FindElements(By.TagName("h4")).ToArray();
                if (datetitle[0].Text.ToUpper().Trim().Equals(requerida.Day.ToString()))
                {
                    button.Click();
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
        public static IWebElement WaitUntilElementIsVisible(string element, searchType type, IWebDriver driver, IWebElement parent , bool waitForAllWhenMultiple = false, string checkTextToBePresent = "")
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
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
            {
                IWebElement found = wait.Until(ExpectedConditions.ElementToBeClickable(parent.FindElement(elementLocator)));
                if (checkTextToBePresent != null && checkTextToBePresent.Trim().Length > 0)
                    wait.Until(ExpectedConditions.TextToBePresentInElement(found, checkTextToBePresent));
                return found;
            }
            else
            {
                IWebElement found = wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
                if (checkTextToBePresent != null && checkTextToBePresent.Trim().Length > 0)
                    wait.Until(ExpectedConditions.TextToBePresentInElement(found, checkTextToBePresent));
                return found;
            }
        }

    }
}
