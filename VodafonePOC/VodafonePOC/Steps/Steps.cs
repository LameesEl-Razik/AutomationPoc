using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using VodafonePOC.PageObject;
using VodafonePOC.Steps.Authentication;
using VodafonePOC.Steps.SignUp;

namespace VodafonePOC.Steps
{
    [Binding]
    public class Steps
    {
        static ChromeDriver driver;
        Home home;
        Authentcation authentcation;
        AccountCreation accountCreation;
        MyAccount myAccount;
        Product product;

        [BeforeScenario("UI")]
        public static void BeforeScenario()
        {
            driver = new ChromeDriver();
        }

        [AfterScenario("UI")]
        public static void AfterScenario()
        {

            driver.Dispose();
        }


        [Given(@"User on home page")]
        public void UserOnHomePage()
        {

            home = new Home(driver);
            home.navigateToURL();
        }


        [When(@"User clicks (.*) button")]
        public void UserClicksButton(string buttonName)
        {
            switch (buttonName)
            {
                case "Sign in":
                    home.clickSignInButton();
                    break;

                case "Create an account":
                    authentcation.clickCreateAnAccountButton();
                    break;

                case "Register":
                    accountCreation.clickRegisterButton();
                    break;

                default:
                    Console.WriteLine("Can't find this button");
                    break;
            }

        }

        [Then(@"User should be navigated to (.*) page")]
        public void UserShouldBeNavigatedTo(string pageName)
        {

            System.Threading.Thread.Sleep(3000);

            switch (pageName)
            {
                case "authentication":
                    authentcation = new Authentcation(driver);
                    Assert.AreEqual(authentcation.getAutenticationPageURL(), driver.Url);
                    break;

                case "Account creation":
                    accountCreation = new AccountCreation(driver);
                    Assert.AreEqual(accountCreation.getAccountCreationPageUrl(), driver.Url);
                    break;

                case "My Account":
                    myAccount = new MyAccount(driver);
                    Assert.AreEqual(myAccount.getMyAccountPageUrlPageUrl(), driver.Url);
                    break;

                case "Blouses":
                    product = new Product(driver);
                    Assert.AreEqual(product.getCategoryPageUrl(), driver.Url);
                    break;
                case "PaymentMethod":
                    Assert.AreEqual(product.getPaymentMethodUrl(), driver.Url);
                    break;

                default:
                    Console.WriteLine("Can't find this page");
                    break;
            }


        }

        [When(@"User enters a valid Email on Email Address field of create an account section")]
        public void UserEntersAValidEmailOnEmailAddressFieldOfCreateAnAccountSection()
        {
            authentcation.enterEmailAddress(SignUpTestData.emailAddress);
        }

        [When(@"User fills account creation form")]
        public void UserFillsAccountCreationForm()
        {
            accountCreation.selectTitle();
            accountCreation.enterFirstName(SignUpTestData.firstName);
            accountCreation.enterlastName(SignUpTestData.lastName);
            accountCreation.enterPassword(SignUpTestData.password);
            accountCreation.selectBirthday(SignUpTestData.birthdayValue);
            accountCreation.selectBirthMonth(SignUpTestData.birthdayMonth);
            accountCreation.selectBirthYear(SignUpTestData.birthdayYear);
            accountCreation.enterCompanyName(SignUpTestData.companyName);
            accountCreation.enterAddress(SignUpTestData.address1);
            accountCreation.enterCity(SignUpTestData.cityName);
            accountCreation.selectState(SignUpTestData.stateName);
            accountCreation.enterZipCode(SignUpTestData.zipCode);
            accountCreation.selectCountry(SignUpTestData.countryName);
            accountCreation.enterMobilePhone(SignUpTestData.mobileNumber);
        }
        [Then(@"Form fields should be filled correctly")]
        public void ThenFormFieldsShouldBeFilledCorrectly()
        {
            
                 //Assert.AreEqual(accountCreation.getTitle(), SignUpTestData.tilte);
            Assert.AreEqual(accountCreation.getFirstName(), SignUpTestData.firstName);
                Assert.AreEqual(accountCreation.getlastName(), SignUpTestData.lastName);
                Assert.AreEqual(accountCreation.getPassword(), SignUpTestData.password);
            Assert.AreEqual(accountCreation.getBirthday(), SignUpTestData.birthdayValue);
            Assert.AreEqual(accountCreation.getBirthMonth(), SignUpTestData.birthdayMonth);
            Assert.AreEqual(accountCreation.getBirthYear(), SignUpTestData.birthdayYear);
            Assert.AreEqual(accountCreation.getCompanyName(), SignUpTestData.companyName);
                Assert.AreEqual(accountCreation.getAddress(), SignUpTestData.address1);
                Assert.AreEqual(accountCreation.getCity(), SignUpTestData.cityName);
            Assert.AreEqual(accountCreation.getState(), SignUpTestData.stateNumber);
            Assert.AreEqual(accountCreation.getZipCode(), SignUpTestData.zipCode);
            Assert.AreEqual(accountCreation.getCountry(), SignUpTestData.countryNumber);
            Assert.AreEqual(accountCreation.getMobilePhone(), SignUpTestData.mobileNumber);
            
        }


        [Then(@"Account welcome message should be shown")]
        public void AccountWelcomeMessageShouldBeShown()
        {
            Assert.AreEqual(SignUpTestData.expectedWelcomeToAccountMsg, myAccount.getWelcomeAccountMsg());
        }

        [When(@"User enters (.*) to login")]
        public void UserEntersCredential(string credentials)
        {

            authentcation = new Authentcation(driver);

            switch (credentials)
            {
                case "Valid Credentials":
                    authentcation.enterCredentials(AuthenticationTestData.validEmailAddress, AuthenticationTestData.validPassword);
                    break;

                case "Invalid Credentials":
                    authentcation.enterCredentials(AuthenticationTestData.inValidEmailAddress, AuthenticationTestData.validPassword);
                    break;

                default:
                    Console.WriteLine("Can't read input");
                    break;
            }
        }

        [Then(@"Authentication failed error message should be shown")]
        public void AuthenticationFailedErrorMessageShouldBeShown()
        {
            Assert.AreEqual(AuthenticationTestData.authenticationFailedErrorMsg, authentcation.getAuthenticationFailedErrorMsg());
        }

        [When(@"User hover over (.*) tab")]
        public void UserHoverOverTab(string tab)
        {
            switch (tab)
            {
                case "Women":
                    home.hoverOverWomenTab();
                    break;

                default:
                    Console.WriteLine("Can't find tab");
                    break;
            }
        }

        [When(@"User selects (.*) category")]
        public void UserSelectsSection(string category)
        {
            switch (category)
            {
                case "Blouses":
                    home.clickOnBlousesCategory();
                    break;

                default:
                    Console.WriteLine("Can't find section");
                    break;
            }
        }
        [When(@"User select product (.*) from the resulted products and add it to cart")]
        public void UserSelectAProductFromTheResultedProducts(int productNo)
        {
            product.addProductToCart(productNo);
        }

        [Then(@"Product should be added to cart")]
        public void ProductShouldBeAddedToCart()
        {
            Assert.That(product.getProductAddedToCartMsg(), Contains.Substring(ProductTestData.productAddedToCartMsg));
        }

        [When(@"User Checkouts from (.*) step")]
        [Obsolete]
        public void UserProceedToCheckout(string checkOutPage)
        {
            switch (checkOutPage)
            {
                case "Confirmation PopUp":
                    product.ProceedToCheckout(checkOutPage);
                    break;

                case "Summary":
                    product.ProceedToCheckout(checkOutPage);
                    break;

                case "Address":
                    product.ProceedToCheckout(checkOutPage);
                    break;

                case "Shipping":
                    product.ProceedToCheckout(checkOutPage);
                    break;

                default:
                    Console.WriteLine("Can't find button");
                    break;
            }

        }

        [When(@"User Select (.*) payment option")]
        public void UserSelectBankWireOption(string paymentOption)
        {
            switch (paymentOption)
            {
                case "Bank wire":
                    product.selectBankWirePayment();
                    break;
                case "Check":
                    product.selectCheckPayment();
                    break;

                default:
                    Console.WriteLine("Not a valid payment Option");
                    break;
            }
        }

        [When(@"User confirms the order")]
        public void UserConfirmsTheOrder()
        {
            product.confirmOrder();
        }

        [When(@"User agrees to Terms of service")]
        public void UserAgreesToTermsOfService()
        {
            product.selectCheckTermOfService();
        }

        [Then(@"Order should be confirmed")]
        public void OrderShouldBeConfirmed()
        {
            Assert.AreEqual(ProductTestData.orderConfirmationMsg, product.getOrderConfirmationMsg());

        }

    }
}
