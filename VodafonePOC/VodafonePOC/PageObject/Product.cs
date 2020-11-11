using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace VodafonePOC.PageObject
{
    class Product
    {
        private string categoryPageUrl = "http://automationpractice.com/index.php?id_category=7&controller=category";
        private string paymentMethodSelectionUrl = "http://automationpractice.com/index.php?controller=order&multi-shipping=";
        private ChromeDriver driver;
        private IList<IWebElement> productsList;
        private IList<IWebElement> addToCartList;
        private By productAddedToCartMsg = By.XPath("(//h2)[1]");
        private By popupProceedToCheckOutButton = By.XPath("//a[@title='Proceed to checkout']//span");
        private By summeryProceedToCheckOutButton = By.XPath("//a[@title='Proceed to checkout' and @href='http://automationpractice.com/index.php?controller=order&step=1']");
        private By addressProceedToCheckOutButton = By.XPath("//button[@name='processAddress']");
        private By shippingProceedToCheckOutButton = By.XPath("//button[@name='processCarrier']");
        private By paymentConfirmOrderButton = By.XPath("(//button[@type='submit'])[2]");
        private By bankWireOption = By.ClassName("bankwire");
        private By TermOfServiceCheckBox = By.Id("cgv");
        private By orderConfirmationMsg = By.XPath("(//div//p//strong[@class='dark'])");


        public Product(ChromeDriver driver)
        {
            this.driver = driver;
            this.productsList = driver.FindElements(By.XPath("//div//h5//a[@itemprop='url']"));
            this.addToCartList = driver.FindElements(By.XPath("//a[@title='Add to cart']"));
        }

        public string getCategoryPageUrl()
        {
            return this.categoryPageUrl;
        }

        public void addProductToCart(int productNumber)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(this.productsList[productNumber - 1]).Perform();
            this.addToCartList[productNumber - 1].Click();

        }

        public string getProductAddedToCartMsg()
        {
            return driver.FindElement(this.productAddedToCartMsg).GetAttribute("innerText");
        }

        [Obsolete]
        public void ProceedToCheckout(string checkOutPage)
        {


            switch (checkOutPage)
            {
                case "Confirmation PopUp":
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                     wait.Until(ExpectedConditions.ElementToBeClickable(this.popupProceedToCheckOutButton));
                    driver.FindElement(this.popupProceedToCheckOutButton).Click();
                    break;

                case "Summary":
                    driver.FindElement(this.summeryProceedToCheckOutButton).Click();
                    break;

                case "Address":
                    driver.FindElement(this.addressProceedToCheckOutButton).Click();
                    break;

                case "Shipping":
                    driver.FindElement(this.shippingProceedToCheckOutButton).Click();
                    break;

                default:
                    Console.WriteLine("Can't find button");
                    break;
            }
        }

        public string getPaymentMethodUrl()
        {
            return this.paymentMethodSelectionUrl;
        }
        public void selectBankWirePayment()
        {

            driver.FindElement(this.bankWireOption).Click();

        }

        public void selectCheckPayment()
        {

            driver.FindElement(this.bankWireOption).Click();

        }

        public void confirmOrder()
        {

            driver.FindElement(this.paymentConfirmOrderButton).Click();

        }
        public string getOrderConfirmationMsg()
        {
            return driver.FindElement(this.orderConfirmationMsg).GetAttribute("innerText");
        }

        public void selectCheckTermOfService()
        {

            driver.FindElement(this.TermOfServiceCheckBox).Click();

        }

    }
}
