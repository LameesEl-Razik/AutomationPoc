using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace VodafonePOC.PageObject
{

    class Authentcation
    {
        private string AuthenticationPageUrl = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private ChromeDriver driver;
        private IWebElement createAnAccountButton;
        private IWebElement emailAddressTextBox;
        private IWebElement loginEmailAddressTextBox;
        private IWebElement loginPasswordTextBox;
        private By authenticationFailedErrorMessage = By.XPath("//div[@class='alert alert-danger']//li");
        private IWebElement loginButton;

        public Authentcation(ChromeDriver driver)
        {
            this.driver = driver;
            this.createAnAccountButton = driver.FindElement(By.Id("SubmitCreate"));
            this.emailAddressTextBox = driver.FindElement(By.Id("email_create"));
            this.loginEmailAddressTextBox = driver.FindElement(By.Id("email"));
            this.loginPasswordTextBox = driver.FindElement(By.Id("passwd"));
            this.loginButton = driver.FindElement(By.Id("SubmitLogin"));
        }

        public string getAutenticationPageURL()
        {
            return AuthenticationPageUrl;
        }
        public void clickCreateAnAccountButton()
        {
            this.createAnAccountButton.Click();
        }

        public void enterEmailAddress(string email)
        {
            
            this.emailAddressTextBox.SendKeys(email);
        }
        public void enterCredentials(string username, string password)
        {

            this.loginEmailAddressTextBox.SendKeys(username);
            this.loginPasswordTextBox.SendKeys(password);
            this.loginButton.Click();
        }
        public string getAuthenticationFailedErrorMsg()
        {
            return driver.FindElement(this.authenticationFailedErrorMessage).GetAttribute("innerText");
        }
    }
}
