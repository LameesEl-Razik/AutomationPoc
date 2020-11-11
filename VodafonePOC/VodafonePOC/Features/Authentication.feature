Feature: Authentication
	As a user I want to access sign in module
  So that I can login to the website

@SignIn @ValidLogin @UI
Scenario: Valid user login
	Given User on home page
	When User clicks Sign in button
	And User enters Valid Credentials to login
	Then User should be navigated to My Account page

    

@SignIn @InValidLogin @UI
Scenario: Invalid user login
	Given User on home page
	When User clicks Sign in button
	And User enters Invalid Credentials to login
	Then Authentication failed error message should be shown
