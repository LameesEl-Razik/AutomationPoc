using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodafonePOC.PageObject
{
    class MyAccount
    {
        private string MyAccountPageUrl = "http://automationpractice.com/index.php?controller=my-account";
        private ChromeDriver driver;
        private IWebElement welcometoAccountMessage;

        public MyAccount(ChromeDriver driver)
        {
            this.driver = driver;
            this.welcometoAccountMessage = driver.FindElement(By.ClassName("info-account"));

        }
        public string getMyAccountPageUrlPageUrl()
        {
            return MyAccountPageUrl;
        }

        public string getWelcomeAccountMsg()
        {
            return this.welcometoAccountMessage.GetAttribute("innerText");
        }
    }
}
