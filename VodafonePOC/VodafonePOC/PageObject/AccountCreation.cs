using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace VodafonePOC.PageObject
{
    class AccountCreation
    {
        private string AccountCreationPageUrl = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        private ChromeDriver driver;
        private IWebElement registerButton;
        private IWebElement mrTitleRadioButton;
        private IWebElement firstNameTextBox;
        private IWebElement lastNameTextBox;
        private IWebElement passwordTextBox;
        private IWebElement birthdayList;
        private IWebElement birthMonthList;
        private IWebElement birthYearList;
        private IWebElement companyTextBox;
        private IWebElement address1TextBox;
        private IWebElement cityTextBox;
        private IWebElement statesList;
        private IWebElement zipCodeTextBox;
        private IWebElement mobilePhoneTextBox;
        private IWebElement countryList;


        public AccountCreation(ChromeDriver driver)
        {
            this.driver = driver;
            this.registerButton = driver.FindElement(By.Id("submitAccount"));
            this.mrTitleRadioButton = driver.FindElement(By.Id("uniform-id_gender1"));
            this.firstNameTextBox = driver.FindElement(By.Name("customer_firstname"));
            this.lastNameTextBox = driver.FindElement(By.Name("customer_lastname"));
            this.passwordTextBox = driver.FindElement(By.Id("passwd"));
            this.birthdayList = driver.FindElement(By.Id("days"));
            this.birthMonthList = driver.FindElement(By.Id("months"));
            this.birthYearList = driver.FindElement(By.Id("years"));
            this.companyTextBox = driver.FindElement(By.Id("company"));
            this.address1TextBox = driver.FindElement(By.Id("address1"));
            this.cityTextBox = driver.FindElement(By.Id("city"));
            this.statesList = driver.FindElement(By.Id("id_state"));
            this.zipCodeTextBox = driver.FindElement(By.Id("postcode"));
            this.countryList = driver.FindElement(By.Id("id_country"));
            this.mobilePhoneTextBox = driver.FindElement(By.Id("phone_mobile"));
           
        }

        public string getAccountCreationPageUrl()
        {
            return AccountCreationPageUrl;
        }

        public void selectTitle()
        {

            this.mrTitleRadioButton.Click();
        }

        public void enterFirstName(string firstname)
        {

            this.firstNameTextBox.SendKeys(firstname);
        }

        public void enterlastName(string lastname)
        {

            this.lastNameTextBox.SendKeys(lastname);
        }

        public void enterPassword(string password)
        {

            this.passwordTextBox.SendKeys(password);
        }
        public void selectBirthday(string day)
        {
            SelectElement birthday = new SelectElement(birthdayList);
            birthday.SelectByValue(day);
        }
        public void selectBirthMonth(string month)
        {
            SelectElement birthMonth = new SelectElement(birthMonthList);
            birthMonth.SelectByValue(month);
        }
        public void selectBirthYear(string year)
        {
            SelectElement birthYear = new SelectElement(birthYearList);
            birthYear.SelectByValue(year);
        }

        public void enterCompanyName(string companyname)
        {

            this.companyTextBox.SendKeys(companyname);
        }

        public void enterAddress(string address)
        {

            this.address1TextBox.SendKeys(address);
        }

        public void enterCity(string cityName)
        {

            this.cityTextBox.SendKeys(cityName);
        }

        public void selectState(string selectedState)
        {
            SelectElement state = new SelectElement(statesList);
            state.SelectByText(selectedState);
        }

        public void enterZipCode(string zipCode)
        {

            this.zipCodeTextBox.SendKeys(zipCode);
        }

        public void selectCountry(string selectedCountry)
        {
            SelectElement country = new SelectElement(countryList);
            country.SelectByText(selectedCountry);
        }


        public void enterMobilePhone(string mobileNo)
        {

            this.mobilePhoneTextBox.SendKeys(mobileNo);
        }

        public void clickRegisterButton()
        {
            this.registerButton.Click();
        }

        public string getTitle()
        {
            return this.mrTitleRadioButton.GetAttribute("value");
        }
        public string getFirstName()
        {

           return this.firstNameTextBox.GetAttribute("value");
        }

        public string getlastName()
        {

            return this.lastNameTextBox.GetAttribute("value"); ;
        }

        public string getPassword()
        {

            return this.passwordTextBox.GetAttribute("value"); ;
        }
        public string getBirthday()
        {
            return this.birthdayList.GetAttribute("value");
        }
        public string getBirthMonth()
        {
           return this.birthMonthList.GetAttribute("value");
        }
        public string getBirthYear()
        {
            return this.birthYearList.GetAttribute("value");
        }

        public string getCompanyName()
        {

            return this.companyTextBox.GetAttribute("value"); 
        }

        public string getAddress()
        {

            return this.address1TextBox.GetAttribute("value");
        }

        public string getCity()
        {

            return this.cityTextBox.GetAttribute("value"); 
        }

        public string getState()
        {
            return this.statesList.GetAttribute("value");
        }

        public string getZipCode()
        {

          return  this.zipCodeTextBox.GetAttribute("value");
        }

        public string getCountry()
        {
            return this.countryList.GetAttribute("value");
  
        }


        public string getMobilePhone()
        {

            return this.mobilePhoneTextBox.GetAttribute("value");
        }
    }
}
