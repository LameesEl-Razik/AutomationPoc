using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace VodafonePOC.PageObject
{
    class Home
    {
        private string URL = "http://automationpractice.com/index.php";
        private ChromeDriver driver;
        private By signInButton= By.ClassName("login");
        private By womenTab = By.XPath("//a[@title='Women']");
        private By blousesCategory = By.XPath("//a[@title='Blouses']");


        public Home(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void navigateToURL()
        {
            driver.Url=this.URL;
            driver.Manage().Window.Maximize();
        }

        public void clickSignInButton()
        {
            driver.FindElement(this.signInButton).Click();
        }

        public void hoverOverWomenTab()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(this.womenTab)).Perform();
        }

        public void clickOnBlousesCategory()
        {
            driver.FindElement(this.blousesCategory).Click();
        }


    }
}
